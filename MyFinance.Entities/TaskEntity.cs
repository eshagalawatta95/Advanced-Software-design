using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Entities
{
    public class OneTimeTasks
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public String Comments { get; set; }
        public double Duration { get; set; }     
        public String ReferenceNumber { get; set; }
        public int CreatedUser { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime Effectivedate { get; set; }
    }

    public class ScheduledTasks
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string RepeatType { get; set; }
        public String Comments { get; set; }
        public double Duration { get; set; }
        public String ReferenceNumber { get; set; }
        public int CreatedUser { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime Effectivedate { get; set; }
    }
}
