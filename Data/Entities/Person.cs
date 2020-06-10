using System.ComponentModel.DataAnnotations;

namespace RPDB.Data.Entities
{
    public abstract class Person
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}
