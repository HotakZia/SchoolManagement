using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class Class
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Grad { get; set; }
        public Guid? TeacherId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status { get; set; }
        public string Shift { get; set; }
        public string Year { get; set; }
        public string Number { get; set; }
        public string Room { get; set; }
    }
}
