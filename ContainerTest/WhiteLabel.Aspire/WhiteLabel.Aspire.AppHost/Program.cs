var builder = DistributedApplication.CreateBuilder(args);

var projects = Projects;


// var apiBackendForFrontEnd = builder.AddProject<Projects.>("website-api-backend-for-frontend")
// .WithLaunchProfile("https");

// var websiteFrontend = builder.AddProject<Projects.>("website-frontend")
// .WithLaunchProfile("https")
// .WithReference(apiBackendForFrontEnd);


builder.Build().Run();