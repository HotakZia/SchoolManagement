using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class Exam
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status { get; set; }
        public int? Number { get; set; }
        public decimal? FirstExam { get; set; }
        public decimal? SecondExam { get; set; }
        public decimal? ClassActivity { get; set; }
        public decimal? HomeActivity { get; set; }
        public decimal? Attendance { get; set; }
        public Guid? ThiredApproval { get; set; }
        public Guid? SecondApproval { get; set; }
        public Guid? FirstApproval { get; set; }
        public Guid? SubJectId { get; set; }
        public Guid? StudentId { get; set; }
        public DateTime? ThiredApprovalTime { get; set; }
        public DateTime? SecondApprovalTime { get; set; }
        public DateTime? FirstApprovalTime { get; set; }
        public string Result { get; set; }
        public int? Year { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid? ClassId { get; set; }
    }
}
