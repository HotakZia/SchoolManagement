using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Hostel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status { get; set; }
        public string Number { get; set; }
        public string Block { get; set; }
        public string Room { get; set; }
        public int? RoomNo { get; set; }
        public int? RoomType { get; set; }
        public decimal? CostPerBed { get; set; }
        public int? NoOfBed { get; set; }
        public Guid? StudentId { get; set; }
        public string Student { get; set; }
    }
}
