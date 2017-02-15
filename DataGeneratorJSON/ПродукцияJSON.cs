using System.Runtime.Serialization;

namespace DataGeneratorJSON 
{
    [DataContract]
    public class ПродукцияJSON
    {
        [DataMember]
        public int код { get; set; }

        [DataMember]
        public string наименование { get; set; }
    }
}
