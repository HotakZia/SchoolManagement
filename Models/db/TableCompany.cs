using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class TableCompany
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TagLine { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string FacebookName { get; set; }
        public string TwitterName { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }
        public string Location { get; set; }
        public string LogoName { get; set; }
        public string LogoType { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Type { get; set; }
        public Guid? Creator { get; set; }
    }
}
