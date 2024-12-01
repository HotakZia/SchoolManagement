using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.Models.db
{
    public partial class staff
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modefied { get; set; }
        public Guid? Creator { get; set; }
        public bool? Status { get; set; }
        public byte[] Image { get; set; }
    }
}
