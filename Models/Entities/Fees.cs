using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Fees
    {
        public Guid Id { get; set; }
        public Guid? StudentId { get; set; }
        public decimal? Amount { get; set; }
        public string FeeType { get; set; }
        public DateTime? Date { get; set; }
        public Guid? PaymentId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status { get; set; }
        public int? Number { get; set; }
        public Guid? ClassId { get; set; }
        public int? Year { get; set; }
        public string StudentName { get; set; }
        public String FatherName { get; set; }
        public String GrandFatherName { get; set; }
        public String RollId { get; set; }
        public String ClassName { get; set; }
        public string PaidBy { get; set; }
    }
}
