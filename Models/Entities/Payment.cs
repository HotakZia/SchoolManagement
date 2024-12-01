using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public int? Number { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? PaymentId { get; set; }
        public string PaymentName { get; set; }
        public decimal? Amount { get; set; }
    }
}
