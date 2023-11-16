using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluent_Api.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StaffId { get; set; }

        [ForeignKey("StaffId")]
        public Staff Staff { get; set;}
        
    }
}
