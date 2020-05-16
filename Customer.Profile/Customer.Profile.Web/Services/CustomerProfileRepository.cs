using Customer.Profile.Web.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace Customer.Profile.Web.Services
{
    public class CustomerProfileRepository : ICustomerProfileRepository
    {
        private readonly IServiceClient _serviceClient;
        public CustomerProfileRepository(IServiceClient serviceClient)
        {
            this._serviceClient = serviceClient;
        }

        public List<CustomerProfileViewModel> GetCustomerProfileList()
        {
            string url = @"api/Customers";
            var response = _serviceClient.GetResponse(url);
            response.EnsureSuccessStatusCode();
            List<CustomerProfileViewModel> custProfiles = response.Content.ReadAsAsync<List<CustomerProfileViewModel>>().Result;
            return custProfiles;
        }

        public CustomerProfileViewModel GetCustomerProfileDetails(int id)
        {
            string url = $"api/Customers/{id}";
            var response = _serviceClient.GetResponse(url);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            CustomerProfileViewModel custProfile = response.Content.ReadAsAsync<CustomerProfileViewModel>().Result;
            return custProfile;
        }

        public string CreateCustomerProfile(CustomerProfileViewModel model)
        {
            string url = @"api/Customers";
            var response = _serviceClient.PostResponse(url, model);
            if (response.IsSuccessStatusCode == true)
            {
                CustomerProfileViewModel custProfiles = response.Content.ReadAsAsync<CustomerProfileViewModel>().Result;
                if (custProfiles != null && custProfiles.Id > 0)
                {
                    return null;
                }
            }
            else if(response.StatusCode==System.Net.HttpStatusCode.BadRequest)
            {
              return  response.Content.ReadAsStringAsync().Result;
            }
            return "There was some error in creating customer profile";
        }

        public (CustomerProfileViewModel,string) UpdateCustomerProfile(CustomerProfileViewModel model)
        {
            string url = $"api/Customers/{model.Id}";
            var response = _serviceClient.PutResponse(url, model);
            if (response.IsSuccessStatusCode == true)
            {
                CustomerProfileViewModel custProfiles = response.Content.ReadAsAsync<CustomerProfileViewModel>().Result;
                if (custProfiles != null)
                {
                    return (custProfiles,null);
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return (null, response.Content.ReadAsStringAsync().Result);
                
            }
            return (null, "There was error in updating customer profile.");
        }

        public bool DeleteCustomerProfile(int id)
        {
            string url = $"api/Customers/{id}";
            var response = _serviceClient.DeleteResponse(url);
            response.EnsureSuccessStatusCode();
            bool result = response.Content.ReadAsAsync<bool>().Result;
            return result;
        }
    }
}
