namespace MikaFramework.MySQL.Models
{
    public class Department
    {
        public int ID { get; set; } 
        public string DepartmentName { get; set; }

        // Foreign key to Employee.ID
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }


    }
}
