var builder = DistributedApplication.CreateBuilder(args);

var apiBackendForFrontEnd = builder.AddProject<Projects.LB_DemoService_WebApi>("api-backend-for-frontend")
.WithLaunchProfile("http");

var frontend = builder.AddProject<Projects.LB_DemoService_UI>("ui-frontend")
.WithLaunchProfile("http")
.WithReference(apiBackendForFrontEnd);

builder.Build().Run();