using RPDB.Data.Entities.LinkingTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPDB.Data.Entities
{
    public class Season
    {
        public int SeasonId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Air Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AirDate { get; set; }
        public string Notes { get; set; }
        public ICollection<QueenSeason> QueenSeasons { get; set; }
        public ICollection<JudgeSeason> JudgeSeasons { get; set; }
    }
}
