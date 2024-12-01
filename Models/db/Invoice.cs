using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class Invoice
    {
        public Guid InvoiceId { get; set; }
        public Guid? StudentId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
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
