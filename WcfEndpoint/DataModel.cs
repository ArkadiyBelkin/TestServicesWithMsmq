using System.Runtime.Serialization;

namespace WcfEndpoint
{
    [DataContract]
    public class DataModel
    {
        [DataMember(Name="body")]
        public string Body { get; set; }
    }
}