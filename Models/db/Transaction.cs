using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class Transaction
    {
        public Guid TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Amount { get; set; }
        public string TransactionType { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment1 { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status { get; set; }
        public int? Number { get; set; }
        public DateTime? Date { get; set; }
        public string PaidBy { get; set; }
    }
}
