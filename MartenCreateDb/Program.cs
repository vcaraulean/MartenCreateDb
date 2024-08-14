using Marten;

const string connectionString = "Host=localhost;Database=db_1;Username=pgu;Password=pgp;";

await using var store = DocumentStore.For(options =>
{
    options.Connection(connectionString);
    options.CreateDatabasesForTenants(t =>
    {
        t.ForTenant()
            .DropExisting(true)
            .CheckAgainstPgDatabase()
            .WithEncoding("UTF-8")
            .ConnectionLimit(-1);
    });
});

await using var session = store.LightweightSession();
await session.QueryAsync<int>("select 1");

Console.WriteLine("done");