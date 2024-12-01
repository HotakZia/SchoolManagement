using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class Attendance
    {
        public Guid AttendanceId { get; set; }
        public Guid? StudentId { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status1 { get; set; }
        public int? Number { get; set; }
    }
}
