using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhonebookDB.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhonebookDB.EF
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PhonebookDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("phonebookDB")));

            return services;
        }
    }
}
