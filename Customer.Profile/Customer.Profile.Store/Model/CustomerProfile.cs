using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Customer.Profile.Store.Model
{
    public class CustomerProfile 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        [ReadOnly(true)]
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
