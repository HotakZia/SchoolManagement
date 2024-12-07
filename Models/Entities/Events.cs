using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Entities
{
    public class Events
    {
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string backroundColor { get; set; }
        public string boderColor { get; set; }
        public bool? allDay { get; set; }
        public string Color { get; set; }

    }
}
