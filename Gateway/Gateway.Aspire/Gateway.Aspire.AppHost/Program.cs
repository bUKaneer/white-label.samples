var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Gateway_DemoService_WebApi>("bff")
    .WithLaunchProfile("http");

builder.AddProject<Projects.Gateway_Api>("gateway")
    .WithReference(api.GetEndpoint("http"));

builder.Build().Run();