using Customer.Profile.Store.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Profile.Store.Services
{
    public interface ICustomerProfileRepository
    {
        Task<bool> CheckCustomerExist(string email);
        Task<CustomerProfile> AddCustomerProfile(CustomerProfile customer);
        Task<List<CustomerProfile>> GeCustomerProfileList();
        Task<CustomerProfile> GeCustomerProfile(int id);
        Task<bool> DeleteCustomerProfile(int id);
        Task<(CustomerProfile, string)> UpdateCustomerProfile(int id, CustomerProfile customer);

    }
}
