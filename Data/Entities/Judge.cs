using RPDB.Data.Entities.LinkingTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPDB.Data.Entities
{
    public class Judge: Person
    {
        [Key]
        public int JudgeId { get; set; }

        [Required]
        public bool IsGuest { get; set; }
        public ICollection<JudgeSeason> JudgeSeasons { get; set; }
    }
}
