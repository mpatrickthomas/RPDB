using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPDB.Data.Entities.LinkingTables
{
    public class JudgeSeason
    {
        public Judge Judge { get; set; }
        public int JudgeId { get; set; }

        public Season Season { get; set; }
        public int SeasonId { get; set; }
    }
}
