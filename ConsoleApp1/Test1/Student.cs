using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonalCode { get; set; }
        public bool IsStudying { get; set; }
       public enum Status { NotStuding, Studing, Graduated, Exmatriculated, OnAcademicLeave }
        public Status StudentStatus { get; set; }
        public string GroupName { get; set; }

        public Student (string firstName, string lastName, int personalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalCode = personalCode;
            IsStudying = false;
            GroupName = "none";
        }

        public override string ToString()
        {
            return ($"{FirstName} {LastName} / {StudentStatus} ({GroupName})");
        }
    }
}
