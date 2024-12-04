using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class Library
    {
        public Guid Id { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? ToDate { get; set; }
        public DateTime? FromDate { get; set; }
        public Guid? PaymentId { get; set; }
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
