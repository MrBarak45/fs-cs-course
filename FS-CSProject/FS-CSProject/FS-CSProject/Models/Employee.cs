using System;
using System.ComponentModel.DataAnnotations;

namespace FS_CSProject
{
    public class Employee
    {
        [Key]
        public int RowId { get; set; }

        public int EmpId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ContactDetailsId { get; set; }

        public int AddressId { get; set; }
    }
}