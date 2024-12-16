using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class MyEnums
    {
        public enum Province
        {
            Badakhshan,
            Badghis,
            Baghlan,
            Balkh,
            Bamyan,
            Daykundi,
            Farah,
            Faryab,
            Ghazni,
            Ghor,
            Helmand,
            Herat,
            Jowzjan,
            Kabul,
            Kandahar,
            Kapisa,
            Khost,
            Kunar,
            Kunduz,
            Laghman,
            Logar,
            Nangarhar,
            Nimroz,
            Nuristan,
            Paktia,
            Paktika,
            Panjshir,
            Parwan,
            Samangan,
            SarePol,
            Takhar,
            Urozgan,
            Wardak,
            Zabul
        }
        public enum District
        {
           
            Nawzad,
            Sangin,
            Washir,
            Herat,
            Adraskan,
        }
        public enum Gender
        {
            Male,
            Female,
            Other
        }
        public enum BloodGroup
        {
            APositive,
            ANegative,
            BPositive,
            BNegative,
            ABPositive,
            ABNegative,
            OPositive,
            ONegative,
            DontKnow
        }
        public enum Shift
        {
            Morning,
            Afternoon,
            Evening
        }
        public enum Grade
        {
            FirstGrade,
            SecondGrade,
            ThirdGrade,
            FourthGrade,
            FifthGrade,
            SixthGrade,
            SeventhGrade,
            EighthGrade,
            NinthGrade,
            TenthGrade,
            EleventhGrade,
            TwelfthGrade
        }
        public enum ItemCategory
        {
            Electronics,
            Clothing,
            Books,
            Furniture,
            SportsEquipment,
            Toys,
            Groceries
        }
        public enum ItemCondition
        {
            New,
            Used,
            Refurbished,
            Damaged,
            ForParts
        }
        public enum Year
        {
            Year2022,
            Year2023,
            Year2024,
            Year2025,
            // Add more years as needed
        }
        public enum FamilyRelationship
        {
            Father,
            Mother,
            Guardian,
            Sibling,
            Grandparent,
            Other
        }
        public enum DocumentType
        {
            BirthCertificate,
            Passport,
            IDCard,
            ReportCard,
            MedicalRecords,
            RecommendationLetter,
            Other
        }

    }
}
