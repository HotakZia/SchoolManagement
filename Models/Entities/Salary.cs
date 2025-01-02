using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Salary
    {
        public Guid Id { get; set; }
        public Guid? TeacherId { get; set; }
        public decimal? Amount { get; set; }
        public string Type { get; set; }
        public DateTime? Date { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public byte[] file { get; set; }
        public bool? Status { get; set; }
        public int Number { get; set; }
        public int? Year { get; set; }
        public string PaidBy { get; set; }
        public string TeacherName { get; set; }
    }
}
