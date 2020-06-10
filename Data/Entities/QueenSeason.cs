using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPDB.Data.Entities.LinkingTables
{
    public class QueenSeason
    {
        public Queen Queen { get; set; }
        public int QueenId { get; set; }

        public Season Season { get; set; }
        public int SeasonId { get; set; }
    }
}
