using Customer.Profile.Web.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Profile.Web
{
    public static class AddCustomerProfileRegstrationExtension
    {
        public static IServiceCollection AddCustomerProfileRegstration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            return services;
        }
           
    }
}
