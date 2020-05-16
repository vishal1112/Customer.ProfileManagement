using Customer.Profile.Api.Model;
using Customer.Profile.Store.Model;
using am=AutoMapper;


namespace Customer.Profile.Api.Mapper
{
    public class AutoMapping : am.Profile
    {

        public AutoMapping()
        {
            CreateMap<CustomerViewModel, CustomerProfile>();

            CreateMap<CustomerProfile, CustomerViewModel>();
        }
    }
}
