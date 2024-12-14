using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class MultiModel
    {
        public Models.db.Student Students { get; set; }
        public List<db.Payment> Parents { get; set; }
    }
}
