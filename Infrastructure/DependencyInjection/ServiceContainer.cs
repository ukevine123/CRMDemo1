using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Application.interfaces;
using Infrastructure.Repositories;
using Domain.Entities;

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
            
            services.AddScoped<ICustomer, CustomerRepository>();
            services.AddScoped<ICampaign, CampaignRepository>();
            services.AddScoped<ITicket, TicketRepository>();
            services.AddScoped<IUser, UserRepository>();


              return services;

        }
    }
}