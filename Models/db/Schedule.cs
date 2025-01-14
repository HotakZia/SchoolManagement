﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class Schedule
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status { get; set; }
        public int? Number { get; set; }
        public string Shift { get; set; }
        public int? Year { get; set; }
        public Guid? TeacherId { get; set; }
        public int? Grad { get; set; }
    }
}
