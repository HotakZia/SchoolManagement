using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class Fee
    {
        public Guid FeeId { get; set; }
        public Guid? StudentId { get; set; }
        public decimal? Amount { get; set; }
        public string FeeType { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status { get; set; }
        public int? Number { get; set; }
    }
}
