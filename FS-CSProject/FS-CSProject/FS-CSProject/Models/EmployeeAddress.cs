using System.ComponentModel.DataAnnotations;

namespace FS_CSProject
{
    public class EmployeeAddress
    {
        [Key]
        public int AddressId { get; set; }

        public string PlaceName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int EmploymentId { get; set; }
    }
}
