using System.ComponentModel.DataAnnotations;
using MikaFramework.MySQL.Models;


namespace MikaFramework.MySQL.Models
{
    public class Department
    {
        public int ID { get; set; } 
        public string departmentName { get; set; }
        public int? ManagerId { get; set; }

    }

    public class UpdatedDepartment
    {
        public int ID { get; set; } = 0;
        public string departmentName { get; set;}
        public int? ManagerId { get; set;}

    }
}
