using System.Runtime.Serialization;

namespace FS_CSProject
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public string PlaceName { get; set; }

        [DataMember]
        public string Country { get; set; }
        
        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }
    }
}