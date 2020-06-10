using Microsoft.Extensions.Logging;
using RPDB.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPDB.Data
{
    public interface IRPDBRepository
    {
        RPDBContext Context { get; }
        ILogger<RPDBRepository> Logger { get; }

        Task<List<Genre>> GetAllGenres();
        Task<List<Season>> GetAllSeasons();
        Task<List<Judge>> GetAllJudges();

        Task<List<Queen>> GetAllQueens();
        Task<int> AddQueen(Queen queen);
        Task<Queen> GetQueenById(int? id);
        Task<bool> ModifyQueen(int? id, Queen queen);
        Task<int> DeleteQueen(Queen queen);
    }
}