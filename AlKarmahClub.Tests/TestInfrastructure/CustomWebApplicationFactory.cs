using AlKarmahClub.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AlKarmahClub.Tests.TestInfrastructure;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }

            var dbContextDescriptor2 = services.SingleOrDefault(d => d.ServiceType == typeof(AppDbContext));
            if (dbContextDescriptor2 != null)
            {
                services.Remove(dbContextDescriptor2);
            }

            var appDbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(AppDbContext));
            if (appDbContextDescriptor != null)
            {
                services.Remove(appDbContextDescriptor);
            }

            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));
        });
    }
}