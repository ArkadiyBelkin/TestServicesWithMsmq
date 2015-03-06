using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;
namespace Contracts
{
    [DataContract]
    [MessageContract]
    public class Product
    {
        private const string _productNameAttribute = "product_name";
        private const string _productPriceAttribute = "product_price";

        [DataMember(Name = _productNameAttribute)]
        [XmlElement(ElementName =_productNameAttribute)]
        public string Name { get; set; }

        [DataMember(Name=_productPriceAttribute)]
        [XmlElement(ElementName=_productPriceAttribute)]
        public double Price { get; set; }
    }
}
