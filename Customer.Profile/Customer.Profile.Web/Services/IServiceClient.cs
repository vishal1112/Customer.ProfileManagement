using System.Net.Http;

namespace Customer.Profile.Web.Services
{
    public interface IServiceClient
    {
        HttpResponseMessage GetResponse(string url);
        HttpResponseMessage PutResponse(string url, object model);
        HttpResponseMessage PostResponse(string url, object model);
        HttpResponseMessage DeleteResponse(string url);
    }
}
