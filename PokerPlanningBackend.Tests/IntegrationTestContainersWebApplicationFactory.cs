using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PokerPlanningBackend.Infrastructure.EntityFramework;
using Testcontainers.PostgreSql;

namespace PokerPlanningBackend.Tests;

public class IntegrationTestContainersWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private DbContext? _context = null;

    private readonly PostgreSqlContainer _postgresqlContainer = new PostgreSqlBuilder().Build();

    public Task InitializeAsync()
    {
        return _postgresqlContainer.StartAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //base.ConfigureWebHost(builder);

        //builder.ConfigureServices
        builder.ConfigureTestServices(serviceCollection =>
        {
            // Remove the current config
            //serviceCollection.Remove(serviceCollection.Single(serviceDescriptor =>
            //    serviceDescriptor.ServiceType == typeof(DbContextOptions<PokerPlanningSQLiteContext>))
            //);
            // Better way?... I don't know
            serviceCollection.RemoveAll<DbContextOptions<PokerPlanningSQLiteContext>>();

            // var descriptorAppDbContext = serviceCollection.Single(serviceDescriptor =>
            //     serviceDescriptor.ServiceType == typeof(PokerPlanningSQLiteContext)
            // );
            // serviceCollection.Remove(descriptorAppDbContext);
            serviceCollection.RemoveAll<PokerPlanningSQLiteContext>();

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
            // or
            //this._context.Database.Migrate();
        });
    }

    public Task DisposeAsync()
    {
        return _postgresqlContainer.DisposeAsync().AsTask();
    }
}
