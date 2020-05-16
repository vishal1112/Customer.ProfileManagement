using System;
using System.Net.Http;
using System.Configuration;
using Customer.Profile.Web.Common;
using Microsoft.Extensions.Options;

namespace Customer.Profile.Web.Services
{
    public class ServiceClient : IServiceClient
    {
        private readonly AppSettings options;

        public HttpClient Client { get; set; }
        public ServiceClient(IOptions<AppSettings> options)
        {
            Client = new HttpClient();
            this.options = options.Value;
            Client.BaseAddress = new Uri(this.options.CustomerProfileApiUrl);
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}
