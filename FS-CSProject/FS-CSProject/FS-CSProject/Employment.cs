using System;
using System.Runtime.Serialization;

namespace FS_CSProject
{
    [DataContract]
    public class Employment
    {
        [DataMember]
        public DateTime JoinDate { get; set; }
    }
}