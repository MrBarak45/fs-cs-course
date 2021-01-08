using System.Runtime.Serialization;

namespace FS_CSProject
{
    [DataContract]
    public class ContactDetails
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}