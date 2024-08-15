using Marten;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

const string connectionString = "Host=localhost;Database=db_1;Username=pgu;Password=pgp;";

var builder = Host.CreateApplicationBuilder();

builder.Services.AddMarten(options =>
{
    options.Connection(connectionString);
    options.CreateDatabasesForTenants(x =>
    {
        x
            .ForTenant()
            .CheckAgainstPgDatabase()
            .WithOwner("postgres")
            .WithEncoding("UTF-8")
            .ConnectionLimit(-1);
    });
});

using var host = builder.Build();

await host.StartAsync();

using var store = host.Services.GetRequiredService<IDocumentStore>();
await using var session =  store.LightweightSession();
await session.QueryAsync<int>("select 1");

Console.WriteLine("done");