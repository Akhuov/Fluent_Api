using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluent_Api.Entities
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public int CompnayId { get; set; }
        [ForeignKey("CompnayId")]
        public Company Company { get; set; }
    }
}
