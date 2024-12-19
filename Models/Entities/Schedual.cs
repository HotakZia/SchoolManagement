using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Schedual
    {
        public string Shift { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ClassId { get; set; }
        public string Subject { get; set; }
        public string HourOfDay { get; set; }
        public string DayOfWeek { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status { get; set; }
        public int? Number { get; set; }
        public string ClassName { get; set; }
        public string SubjecName { get; set; }
        public string TeacherName { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? Year { get; set; }
    }
}
