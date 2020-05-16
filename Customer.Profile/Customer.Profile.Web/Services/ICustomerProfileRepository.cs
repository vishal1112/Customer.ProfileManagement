using Customer.Profile.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Profile.Web.Services
{
    public interface ICustomerProfileRepository
    {
        List<CustomerProfileViewModel> GetCustomerProfileList();
        CustomerProfileViewModel GetCustomerProfileDetails(int id);
        string CreateCustomerProfile(CustomerProfileViewModel model);
        (CustomerProfileViewModel, string) UpdateCustomerProfile(CustomerProfileViewModel model);
        bool DeleteCustomerProfile(int id);
    }
}
