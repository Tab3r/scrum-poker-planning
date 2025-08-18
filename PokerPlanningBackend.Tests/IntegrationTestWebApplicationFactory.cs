using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PokerPlanningBackend.Infrastructure.EntityFramework;

namespace PokerPlanningBackend.Tests;

public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private DbContext? _context = null;

    public Task InitializeAsync()
    {
        //throw new NotImplementedException();
        return Task.CompletedTask;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //base.ConfigureWebHost(builder);

        //builder.ConfigureServices
        builder.ConfigureTestServices(serviceCollection =>
        {
            // Remove the current config
            serviceCollection.Remove(serviceCollection.Single(serviceDescriptor =>
                serviceDescriptor.ServiceType == typeof(DbContextOptions<PokerPlanningSQLiteContext>))
            );
            // Add new one
            serviceCollection.AddDbContext<PokerPlanningSQLiteContext>(dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder.UseSqlite("Data Source=./pokerplanning_test.db", x =>
                {
                    x.CommandTimeout(5);
                });
            });

            var scope = serviceCollection.BuildServiceProvider().CreateScope();

            this._context = scope.ServiceProvider.GetRequiredService<PokerPlanningSQLiteContext>();

            this._context.Database.EnsureCreated();
        });
    }

    public Task DisposeAsync()
    {
        if (_context != null)
        {
            return _context.Database.EnsureDeletedAsync();
        }
        return Task.CompletedTask;
    }

}
