using System;
using System.ComponentModel.DataAnnotations;

namespace MikaFramework.MySQL.Models
{
    public class Shift
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }


    }

}
