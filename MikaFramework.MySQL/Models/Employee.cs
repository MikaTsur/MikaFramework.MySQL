﻿namespace MikaFramework.MySQL.Models
{
    public class Employee
    {
        public int ID { get; set; } // Primary key
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int? startWorkYear { get; set; }

        // Foreign key to Department.ID
        public int DepartmentID { get; set; }

    }
}