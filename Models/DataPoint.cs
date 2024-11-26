using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SchoolManagement.Models
{

    public class Field
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    //DataContract for Serializing Data - required to serve in JSON format
    [DataContract]
    public class DataPoint
    {
        public DataPoint(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
    [DataContract]
    public class Pei_Chart
    {
        public Pei_Chart(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
    //DataContract for Serializing Data - required to serve in JSON format
    [DataContract]
    public class line
    {
        public line(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
    //DataContract for Serializing Data - required to serve in JSON format
    [DataContract]
    public class scatter
    {
        public scatter(string label, double x, double y, double z)
        {
            this.Label = label;
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public Nullable<double> X = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "z")]
        public Nullable<double> Z = null;
    }
    [DataContract]
    public class column
    {
        public column(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }
        [DataMember(Name = "_Year")]
        public int _Year = 0;
        [DataMember(Name = "_Value")]
        public int _Value = 0;
        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }

    [DataContract]
    public class lineList
    {
        public lineList(int year, int value)
        {
            this.year = year;
            this.value = value;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "year")]
        public int year =0;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "value")]
        public int value = 0;
    }
    [DataContract]
    public class lineBar
    {
        public lineBar(string townName, decimal distance,string date)
        {
            this.townName = townName;
            this.distance = distance;
            this.date = date;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "townName")]
        public string townName = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "distance")]
        public decimal distance = 0;
        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "date")]
        public string date = "";
    }
    [DataContract]
    public class range
    {
        public range(string Year, double []Value)
        {
            this.Label = Year;
            this.Y = Value;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public double[] Y = null;
    }
    public class GroupResult
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int Quantity { get; set; }

        public Nullable<decimal> decimalValue { get; set; }
        public Nullable<bool> status { get; set; }
        public double doubleValue { get; set; }

        public string Date { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public class Attandance
    {
        public string EmployeeName { get; set; }
        public string Father_Name { get; set; }
        public int? Id_Number { get; set; }
        public string Designation { get; set; }
        public int Number { get; set; }
        public bool Present { get; set; }
        public bool Absent { get; set; }

        public bool ComeLate { get; set; }
        public bool EarlyLeave { get; set; }
        public bool OffDay { get; set; }
        public bool Leave { get; set; }
        public bool Holiday { get; set; }
        public DateTime DateTime { get; set; }
        public string Extra { get; set; }
        public double TotalHours { get; set; }
        public TimeSpan IN_ { get; set; }
        public TimeSpan OUT_ { get; set; }
    }
    public class Payrol
    {
        public int? Number { get; set; }

        public int PresentCounter { get; set; }
        public int AbsentCounter { get; set; }

        public int ComeLateCounter { get; set; }
        public int EarlyLeaveCounter { get; set; }
        public int OffDayCounter { get; set; }
        public int LeaveCounter { get; set; }
        public int HolidayCounter { get; set; }
        public DateTime DateTime { get; set; }
        public string EmployeeName { get; set; }
        public int TotalDay { get; set; }
        public double? TotalHours { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Charges { get; set; }
        public decimal? Bonus { get; set; }
        public decimal? Net { get; set; }
    }
    public class Balance
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public string UserName { get; set; }
        public string Bast { get; set; }
        public string FatherName { get; set; }
        public int? Id_Number { get; set; }
        public Guid Id { get; set; }
        public string Position { get; set; }
        public decimal? Total { get; set; }
        public decimal? Taken { get; set; }
        public decimal? Remain { get; set; }
        public string BadgeNumber { get; set; }
    }
    public class _Attandance
    {
        public string Position { get; set; }
        public string Full_Name { get; set; }
        public string Father_Name { get; set; }
        public string Tazkira_Number { get; set; }
        public string Bast { get; set; }
        public string Qadam { get; set; }
        public int? Total_Days { get; set; }
        public int? Number { get; set; }
        public IList<_AttandanceList> List { get; set; }
        public string Comment { get; set; }
    }
    public class _AttandanceList
    {
        public string Name { get; set; }
        public decimal? Quantity { get; set; }
    }
}