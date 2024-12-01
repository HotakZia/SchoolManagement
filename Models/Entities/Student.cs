using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Student
    {
        public string ClassName { get; set; }
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Contact { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public string GuardianName { get; set; }
        public string GuardianPhone { get; set; }
        public Guid? ClassId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public byte[] Attachment { get; set; }
        public bool? Status { get; set; }
        public string FatherName { get; set; }
        public string GfatherName { get; set; }
        public string Tazkira { get; set; }
        public string RoleNumber { get; set; }
        public string BloodGroup { get; set; }
    }
}
