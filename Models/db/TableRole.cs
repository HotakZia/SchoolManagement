using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class TableRole
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string UserRole { get; set; }
        public string RoleType { get; set; }
    }
}
