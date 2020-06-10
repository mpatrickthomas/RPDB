using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPDB.Data.Entities.LinkingTables
{
    public class QueenGenre
    {
        public Queen Queen { get; set; }
        public int QueenId { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
