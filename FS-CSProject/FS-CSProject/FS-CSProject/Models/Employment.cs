using System;
using System.ComponentModel.DataAnnotations;

namespace FS_CSProject
{
    public class Employment
    {
        [Key]
        public int EmploymentId { get; set; }

        public DateTime JoinDate { get; set; }

        public decimal AgeInCompany { get; set; }
    }
}