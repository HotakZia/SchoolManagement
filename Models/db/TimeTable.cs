using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class TimeTable
    {
        public Guid Id { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? SubjectId { get; set; }
        public string HourOfDay { get; set; }
        public string DayOfWeek { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Status { get; set; }
        public int? Year { get; set; }
        public int Number { get; set; }
    }
}
