var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddContainer(
    "api-backend-for-frontend",
    "localhost:43266/whitelabel-demoservice-api",
    "0.0.1-alpha")
.WithServiceBinding(17460, 19000, "http", "api-backend-for-frontend");

var ui = builder.AddContainer(
    "ui-frontend",
    "localhost:43266/whitelabel-demoservice-ui",
    "0.0.1-alpha")
.WithServiceBinding(22346, 19001, "http", "ui-frontend");


builder.Build().Run();
