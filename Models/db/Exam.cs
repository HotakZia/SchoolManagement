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
        public Guid? FinalApprover { get; set; }
        public Guid? DeanApprover { get; set; }
        public Guid? TeacherApprover { get; set; }
        public Guid? SubJectId { get; set; }
        public Guid? StudentId { get; set; }
        public DateTime? FinalApprovalTime { get; set; }
        public DateTime? DeanApprovalTime { get; set; }
        public DateTime? TeacherApprovalTime { get; set; }
        public string Result { get; set; }
        public int? Year { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid? ClassId { get; set; }
        public string TeacherApprovalComment { get; set; }
        public string DeanApprovalComment { get; set; }
        public string FinalApprovalComment { get; set; }
        public string TeacherApproverName { get; set; }
        public string DeanApproverName { get; set; }
        public string FinalApproverName { get; set; }
    }
}
