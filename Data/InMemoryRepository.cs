using Microsoft.Extensions.Logging;
using RPDB.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPDB.Data
{
    public class InMemoryRepository : IRPDBRepository
    {
        public RPDBContext Context => throw new NotImplementedException();

        public ILogger<RPDBRepository> Logger => throw new NotImplementedException();

        public Task<int> AddQueen(Queen queen) => throw new NotImplementedException();
        public Task<int> DeleteQueen(Queen queen) => throw new NotImplementedException();
        public Task<List<Genre>> GetAllGenres() => throw new NotImplementedException();
        public Task<List<Genre>> GetAllGenres_Slim() => throw new NotImplementedException();
        public Task<List<Judge>> GetAllJudges() => throw new NotImplementedException();
        public Task<List<Queen>> GetAllQueens() => throw new NotImplementedException();
        public Task<List<Season>> GetAllSeasons() => throw new NotImplementedException();
        public Task<List<Season>> GetAllSeasons_Slim() => throw new NotImplementedException();
        public Task<Queen> GetQueenById(int? id) => throw new NotImplementedException();
        public Task<bool> ModifyQueen(int? id, Queen queen) => throw new NotImplementedException();
    }
}
