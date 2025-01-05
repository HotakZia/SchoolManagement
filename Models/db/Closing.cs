using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class Closing
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
        public decimal? NewAmount { get; set; }
        public decimal? OldAmount { get; set; }
        public decimal? NewCredit { get; set; }
        public decimal? OldCredit { get; set; }
        public decimal? NewDebit { get; set; }
        public decimal? OldDebit { get; set; }
        public decimal? Total { get; set; }
    }
}
