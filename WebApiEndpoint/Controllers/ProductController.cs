using System.Web.Http;
using Contracts;
using MsmqProducer;

namespace WebApiEndpoint.Controllers
{
    public class ProductController : ApiController
    {
        public void Post([FromBody]Product value)
        {
            var producer = new Producer();
            producer.AddProduct(value);
        }
    }
}