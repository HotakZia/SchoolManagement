﻿using System;
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
            Nusery=0,
            FirstGrade=1,
            SecondGrade=2,
            ThirdGrade=3,
            FourthGrade=4,
            FifthGrade=5,
            SixthGrade=6,
            SeventhGrad=7,
            EighthGrade=8,
            NinthGrade=9,
            TenthGrade=10,
            EleventhGrade=11,
            TwelfthGrade=12
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
        public enum Position
        {
            Dean,
            Principal,
            Teacher,
            Librarian,
            Counselor,
            Administrator
        }
        public enum SubjectTaught
        {
            Mathematics,
            Science,
            English,
            History,
            Geography,
            ComputerScience,
            PhysicalEducation,
            Art,
            Music
        }
        public enum Department
        {
            Administration,
            Mathematics,
            Science,
            LanguageArts,
            SocialStudies,
            FineArts,
            PhysicalEducation,
            Technology,
            Counseling
        }
        public enum UserLoginRule
        {
            Dean,
            Principal,
            Teacher,
            Librarian,
            Counselor,
            Admin,
            Authorize,
            Student,
            Standard, // Standard login without any additional rules
            TwoFactorAuthentication, // User must authenticate using two-factor authentication
            PasswordResetRequired, // User must reset their password on next login
            AccountLocked, // User account is locked and cannot login
            AccountDisabled // User account is disabled and cannot login
        }
        public enum NoticeCategory
        {
            General,
            Academic,
            Event,
            Holiday,
            Exam,
            // Add more categories as needed
        }
        public enum ClassSubjects
        {
            Mathematics,
            Science,
            English,
            History,
            Geography,
            ComputerScience,
            Physics,
            Chemistry,
            Biology,
            Literature,
            Art,
            PhysicalEducation
        }
        public enum Alphabet
        {
            A, B, C, D, E, F, G, H, I, J, K, L, M,
            N, O, P, Q, R, S, T, U, V, W, X, Y, Z
        }
        public enum ShiftHours
        {
            FirstHour=1,
SecondHour=2,
ThirdHour=3,
FourthHour=4,
FifthHour=5,
SixthHour=6,

        }
        public enum DayOfWeek
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }
        public enum FeesType
        {
            Tuition,
            Registration,
            Library,
            Exam,
            Sports,
            Technology,
            Activity,
            Fine,
            Transportation,
            Other
        }
        public enum SchoolExpense
        {
            Tuition,
            Books,
            Supplies,
            Uniform,
            Transportation,
            Lunch,
            FieldTrip,
            Technology,
            Extracurricular
        }
    }
}
