using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Domain.Entities;
using Infrastructure.Identity;
using Application.Interfaces;
using Application.interfaces;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
           //Add Infrastructure services here, e.g., DbContext, Repositories, etc.
              services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CRMDemoSQLConnection")),ServiceLifetime.Scoped
              );
              //Register identity services
              services.AddAuthenticationService(configuration);


             //Register repositories
            services.AddScoped<ICustomer, CustomerRepository>();
            services.AddScoped<ICampaign, CampaignRepository>();
            services.AddScoped<ITicket, TicketRepository>();
            services.AddScoped<IIdentity, IdentityRepos>();
            // services.AddScoped<IUser, UserRepository>();


              return services;

        }
    }
}