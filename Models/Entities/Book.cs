using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Book
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
        public Guid? RelationId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? BookId { get; set; }
        public string BookName { get; set; }
        public string        Type { get; set; }
        public string AssigneeName { get; set; }
        public IList <Models.Entities.Book> BookAssignee { get; set; }
    }
}
