using Google.Protobuf.WellKnownTypes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection.PortableExecutable;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()

    // if you comment out this configuration, everything works fine
    .ConfigureFunctionsWorkerDefaults(app =>
    {
        app.UseMiddleware<FunctionApp1.CustomMiddleware>();
    })

    .Build();

await host.RunAsync();