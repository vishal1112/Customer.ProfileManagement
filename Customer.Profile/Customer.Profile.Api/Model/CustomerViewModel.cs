using Customer.Profile.Api.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Profile.Api.Model
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MinAge(18)]
        public DateTime DOB { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="The email field is not a valid e-mail address.")]
        public string Email { get; set; }

        public string MobileNumber { get; set; }
    }
}
