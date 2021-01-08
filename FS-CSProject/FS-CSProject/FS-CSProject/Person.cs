using System;
using System.Runtime.Serialization;

namespace FS_CSProject
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }
    }
}