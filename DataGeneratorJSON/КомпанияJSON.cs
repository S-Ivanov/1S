using System.Runtime.Serialization;

namespace DataGeneratorJSON
{
    [DataContract]
    public class КомпанияJSON
    {
        [DataMember]
        public int код { get; set; }

        [DataMember]
        public string наименование { get; set; }

        [DataMember]
        public ПродукцияJSON[] Продукция { get; set; }
    }
}
