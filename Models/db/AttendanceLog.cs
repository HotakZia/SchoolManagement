using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class AttendanceLog
    {
        public Guid Id { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? StudentId { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public int? Number { get; set; }
        public bool? In { get; set; }
        public bool? Out { get; set; }
        public string Name { get; set; }
        public Guid? TeacherId { get; set; }
    }
}
