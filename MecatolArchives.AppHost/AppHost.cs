
using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<SqlServerServerResource> sql;

var testingArg = args.FirstOrDefault(x => x.StartsWith("--testing="));
if (testingArg != null)
{
    var name = testingArg.Split('=')[1];
    sql = builder.AddSqlServer(name);
}
else
{
    sql = builder.AddSqlServer("sql")
             .WithLifetime(ContainerLifetime.Persistent);
}
var db = sql.AddDatabase("MecatolArchives");

var apiService = builder.AddProject<Projects.MecatolArchives_ApiService>("apiservice")
    .WithExternalHttpEndpoints()
    .WithUrl("/api")
    .WithHttpHealthCheck("/health")
    .WithReference(db)
    .WaitFor(db);

builder.AddProject<Projects.MecatolArchives_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();

