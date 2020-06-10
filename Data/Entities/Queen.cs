using RPDB.Data.Entities.LinkingTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPDB.Data.Entities
{
    public class Queen: Person
    {
        public int QueenId { get; set; }

        [Required]
        [StringLength(50)]
        public string Hometown { get; set; }
        public string Notes { get; set; }

        [DisplayName("Genres")]
        public ICollection<QueenGenre> QueenGenres { get; set; }

        [DisplayName("Seasons")]
        public ICollection<QueenSeason> QueenSeasons { get; set; }

        /// <summary>
        /// Used to get the season IDs from the UI
        /// </summary>
        [NotMapped]
        public int[] SelectedSeasonIDs { get; set; }

        /// <summary>
        /// Used to get the Genre IDs from the UI
        /// </summary>
        [NotMapped]
        public int[] SelectedGenreIDs { get; set; }
    }
}
