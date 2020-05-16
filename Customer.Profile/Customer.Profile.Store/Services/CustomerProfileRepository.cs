using Customer.Profile.Store.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Profile.Store.Services
{
    public class CustomerProfileRepository : ICustomerProfileRepository
    {
        private readonly CustomerProfileContext _context;
        public CustomerProfileRepository(CustomerProfileContext context)
        {
            this._context = context;
        }

        public async Task<CustomerProfile> AddCustomerProfile(CustomerProfile customer)
        {
            _context.CustomerProfile.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> CheckCustomerExist(string email)
        {
            var custProfile = await _context.CustomerProfile
                                     .FirstOrDefaultAsync(c => c.Email == email);
            if (custProfile != null && custProfile.Id > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<CustomerProfile> GeCustomerProfile(int id)
        {
            var custProfile = await _context.CustomerProfile
                               .FirstOrDefaultAsync(c => c.Id == id);

            return custProfile;
        }

        public async Task<List<CustomerProfile>> GeCustomerProfileList()
        {
            var result = await _context.CustomerProfile.ToListAsync();
            return result;
        }

        public async Task<bool> DeleteCustomerProfile(int id)
        {
            var custProfile = await _context.CustomerProfile.SingleOrDefaultAsync(c => c.Id == id);
            if (custProfile != null)
            {
                _context.CustomerProfile.Remove(custProfile);
                int result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<(CustomerProfile,string)> UpdateCustomerProfile(int id, CustomerProfile customer)
        {
            string errorMessage = null;

            try
            {
                var custProfile = await _context.CustomerProfile.SingleOrDefaultAsync(c => c.Id == id);
                if (custProfile != null)
                {
                    var exisitingCustomer = await _context.CustomerProfile.SingleOrDefaultAsync(c => c.Id != id && c.Email == customer.Email);
                    if (exisitingCustomer != null)
                    {
                        return (null, "Sorry, you cannot use the email address to create account profile.");
                    }
                    custProfile.DOB = customer.DOB;
                    custProfile.FirstName = customer.FirstName;
                    custProfile.Email = customer.Email;
                    custProfile.LastName = customer.LastName;
                    custProfile.MobileNumber = customer.MobileNumber;
                    _context.Entry(custProfile).State = EntityState.Modified;
                    int result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return (custProfile,null);
                    }
                }
                if (string.IsNullOrEmpty(errorMessage))
                {
                    return (null, "Customer profile could not be updated because of some error.");
                }
                return (null, errorMessage);

            }
            catch(Exception ex)
            {
                return (null, "Customer profile could not be updated because of some error.");
            }
            
        }
    }
}
