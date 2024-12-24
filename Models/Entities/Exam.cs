using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Exam
    {
        public string StudentName { get; set; }
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
       
        public Guid? ClassId { get; set; }
      
        public string TeacherApproverName { get; set; }
        public string DeanApproverName { get; set; }
        public string FinalApproverName { get; set; }
        public string TeacherApproverComment { get; set; }
        public string DeanApproverComment { get; set; }
        public string FinalApproverComment { get; set; }
        public Guid? TeacherApproverId { get; set; }
        public Guid? DeanApproverId { get; set; }
        public Guid? FinalApproverId { get; set; }
        public Guid? SubJectId { get; set; }
        public Guid? TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public string ClassName { get; set; }
        public Guid? StudentId { get; set; }
        public DateTime? FinalApprovalTime { get; set; }

        public DateTime? TeacherApprovalTime { get; set; }
        public DateTime? DearnApprovalTime { get; set; }
        public string Result { get; set; }
        public int? Year { get; set; }
    }
}
