﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class Schedule
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? SubjectId { get; set; }
        public int? HourOfDay { get; set; }
        public int? DayOfWeek { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status { get; set; }
        public int? Number { get; set; }
        public string Shift { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? Year { get; set; }
    }
}