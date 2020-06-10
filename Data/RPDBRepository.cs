using Microsoft.Extensions.Logging;
using RPDB.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RPDB.Data
{
    public class RPDBRepository : IRPDBRepository
    {
        public RPDBContext Context { get; }
        public ILogger<RPDBRepository> Logger { get; }

        public RPDBRepository(RPDBContext context, ILogger<RPDBRepository> logger)
        {
            this.Context = context;
            this.Logger = logger;
        }
        #region Queen Operations

        /// <summary>
        /// Fetches all of the queens, along with their season and genre data
        /// </summary>
        /// <returns>IEnumerable with the queen data, including the linked tables representing the season and genre data</returns>
        public Task<List<Queen>> GetAllQueens()
        {
            return this.Context.Queens
                .Include(q => q.QueenSeasons)
                   .ThenInclude(qs => qs.Season)
                .Include(q => q.QueenGenres)
                   .ThenInclude(qg => qg.Genre)
                .OrderBy(q => q.Name).ToListAsync();
        }

        public Task<Queen> GetQueenById(int? id)
        {
            return id is null
                ? null
                : this.Context.Queens
                    //.Include(q => q.QueenSeasons)
                    //    .ThenInclude(qs => qs.Season)
                    //.Include(q => q.QueenGenres)
                    //    .ThenInclude(qg => qg.Genre)
                    .FirstOrDefaultAsync(q => q.QueenId == id);
        }

        public async Task<int> AddQueen(Queen queen)
        {
            this.Context.Queens.Add(queen);
            return await this.Context.SaveChangesAsync();
        }

        public Task<bool> ModifyQueen(int? id, Queen queen)
        {
            if (!id.HasValue || id != queen.QueenId)
            {
                return Task.Run(() => false);
            }

            this.Context.Entry(queen).State = EntityState.Modified;

            try
            {
                this.Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueenExists(id.Value))
                {
                    return Task.Run(() =>false);
                }
                else
                {
                    throw;
                }
            }

            return Task.Run(() => true);
        }

        public Task<int> DeleteQueen(Queen queen)
        {
            this.Context.Queens.Remove(queen);
            return this.Context.SaveChangesAsync();
        }

        private bool QueenExists(int id)
        {
            return this.Context.Queens.Any(e => e.QueenId == id);
        }

        #endregion

        /// <summary>
        /// Fetches all of the data on the judges, including the seasons they have served on
        /// </summary>
        /// <returns>An IEnumerable representing all of the judges information, including the seasons they served on</returns>
        public Task<List<Judge>> GetAllJudges()
        {
            return this.Context.Judges
                .Include(j => j.JudgeSeasons)
                    .ThenInclude(js => js.Season)
                .OrderBy(j => j.Name).ToListAsync();
        }

        /// <summary>
        /// Fetches all of the season data, including all of the contestants and judges that served
        /// </summary>
        /// <returns>IEnumerable containing all of the queens and judges</returns>
        public Task<List<Season>> GetAllSeasons()
        {
            return this.Context.Seasons
                .Include(s => s.QueenSeasons)
                    .ThenInclude(qs => qs.Queen)
                .Include(s => s.JudgeSeasons)
                    .ThenInclude(js => js.Judge)
                .OrderBy(s => s.AirDate).ToListAsync();
        }

        /// <summary>
        /// Fetches all of the genres and the queens that fit into them
        /// </summary>
        /// <returns>IEnumerable containing all of the genres and the queens associated with them</returns>
        public Task<List<Genre>> GetAllGenres()
        {
            return this.Context.Genres
                .Include(g => g.QueenGenres)
                    .ThenInclude(gs => gs.Queen)
                .OrderBy(g => g.Name).ToListAsync();
        }

    }
}
