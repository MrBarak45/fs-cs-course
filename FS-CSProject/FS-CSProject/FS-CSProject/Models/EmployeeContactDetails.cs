using System.ComponentModel.DataAnnotations;

namespace FS_CSProject
{
    public class EmployeeContactDetails
    {
        [Key]
        public int ContactDetailsId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
