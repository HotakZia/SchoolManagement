using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Attendance
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
        public string StudentName { get; set; }
        public String TeacherName { get; set; }
        public string ClassName { get; set; }
    }
}
