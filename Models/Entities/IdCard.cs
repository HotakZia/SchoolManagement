using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class IdCard
    {
        public String Name { get; set; }
        public string IdCardNumber { get; set; }
        public String Position { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string Image { get; set; }
        public byte[] Attachment { get; set; }
        public string QRcode { get; set; }
    }
}
