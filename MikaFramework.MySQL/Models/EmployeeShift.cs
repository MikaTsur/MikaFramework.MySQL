using System;
using System.ComponentModel.DataAnnotations;

namespace MikaFramework.MySQL.Models
{
    public class EmployeeShift
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }

    }


}
