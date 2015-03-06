using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfEndpoint
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract, WebInvoke(Method = "POST", RequestFormat= WebMessageFormat.Json)]
        void AddProduct(DataModel value);
    }
}

