using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class GroupByResult
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Nullable<decimal> decimalValue { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Date { get; set; }
    }
}
