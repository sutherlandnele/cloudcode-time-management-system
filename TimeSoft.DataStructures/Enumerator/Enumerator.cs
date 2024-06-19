using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSoft.DataStructures.Enumerator
{
    public struct ReferenceTable
    {
        public const string BusinessUnit = "BusinessUnit";
        public const string DivisionUnit = "DivisionUnit";
        public const string Department = "Department";  
        public const string Active = "Active";
        public const string StaffLocation = "StaffLocation";
        public const string Location = "Location";
        public const string Role = "Role";  
    }

    public struct Combo
    {
        public const string Description = "ComboDesc";
        public const string ID = "ComboID";       
    }

    public struct SearchCriteria
    {
        public const string CardNo = "CardNo";
        public const string FName = "FName";
        public const string LName = "LName";
        public const string EmployeeNo = "EmployeeNo";
        public const string Active = "Active";
        public const string BusinessUnit = "BusinessUnit";
        public const string DivisionUnit = "DivisionUnit";
        public const string Department = "Department";
    }

    public enum Mode
    {
        Insert = 1,
        Update = 2,
        View = 3,
        Nothing = 4,
    }

    public enum Role
    {
        Chief = 1,
        BusinessHead = 2,
        DivisionHead = 3,
        DepartmentManager = 4,
        Admin = 5,
        MD = 6,
       
    }

}
