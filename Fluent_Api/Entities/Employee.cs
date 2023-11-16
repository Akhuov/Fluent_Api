namespace Fluent_Api.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StaffId { get; set; }

        public Staff Staff { get; set; }

    }
}
