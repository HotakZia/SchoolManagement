using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Transection
    {
        public Guid Id { get; set; }
        public decimal? Amount { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Attachment { get; set; }
        public byte[] File { get; set; }
        public bool? Status { get; set; }
        public int Number { get; set; }
        public DateTime? Date { get; set; }
        public string PaidBy { get; set; }
        public int? Year { get; set; }
        public Guid? RelationId { get; set; }
        public string RelationName { get; set; }
        public String DRCR { get; set; }
        public bool Payment { get; set; }
        public int?   PaymentQuantity { get; set; }
    }
}
