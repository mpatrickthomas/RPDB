using RPDB.Data.Entities.LinkingTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPDB.Data.Entities
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [DisplayName("Genre Name")]
        public string Name { get; set; }

        public string Notes { get; set; }

        public ICollection<QueenGenre> QueenGenres{ get; set; }
    }
}
