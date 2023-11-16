namespace Fluent_Api.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
