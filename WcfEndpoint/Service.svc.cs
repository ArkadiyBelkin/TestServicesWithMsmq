using System.Text;
using Contracts;
using MsmqProducer;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.IO;
using NLog;

namespace WcfEndpoint
{
    public class Service : IService
    {
        private Logger _log = LogManager.GetCurrentClassLogger();

        public void AddProduct(DataModel value)
        {
            string data = HttpUtility.UrlDecode(value.Body);
            Product product;
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
            try
            {
                if (data.StartsWith("<") && data.EndsWith(">"))
                {
                    var xmlSerializer = new XmlSerializer(typeof(Product));
                    product = (Product)xmlSerializer.Deserialize(stream);
                }
                else
                {
                    var jsonSerializer = new DataContractJsonSerializer(typeof(Product));
                    product = (Product)jsonSerializer.ReadObject(stream);
                }
            }
            catch
            {
                _log.Fatal("Incorrect data format in message: " + data);
                throw;
            }
            var producer = new Producer();
            producer.AddProduct(product);
            
        }
    }
}
