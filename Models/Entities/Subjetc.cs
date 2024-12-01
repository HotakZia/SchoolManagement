using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Subjetc
    {
        public string TeacherName { get; set; }
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status { get; set; }
        public int? Number { get; set; }
        public int? Grade { get; set; }
        public Guid? TeacherId { get; set; }
        public int? Year { get; set; }
    }
}
