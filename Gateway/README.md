# Gateway Distributed Development Environment Information 

The following docker containers have been setup for this project: 

- Container Registry : http://localhost:12896
- [Container Registry UI](http://localhost:11262): http://localhost:11262
- [Package Source UI](http://localhost:46959): http://localhost:46959

## Configuration Information 

The config file for this Cloud Native Applcation can be found here:

`C:\WL\Gateway\Configuration\Gateway.config.json`

The Configuration folder holds all values used in project initialisation.

`C:\WL\Gateway\Configuration\Gateway.DemoService.config.json`

The Gateway.PackagesAndContainers solution has within it a special posts.config.json 
which has been copied here. This is used during initialisation to manage the dynamic ports for the nuget.config file which has 
also been copied here

The nuget file can be placed into new project you generate so that they can access the local 
package source.

## Aspire AppHost Wire-up 

Use the following to replace the content of Program.cs in Aspire.AppHost folder.

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var apiBackendForFrontEnd = builder.AddProject<Projects._Sample_Demo_WebApi>("api-backend-for-frontend")
.WithLaunchProfile("http");

var frontend = builder.AddProject<Projects._Sample_Demo_UserInterface>("ui-frontend")
.WithLaunchProfile("http")
.WithReference(apiBackendForFrontEnd);

builder.Build().Run();
```

## Add additional Projects/Services

To add a new HostedProject (Service) first create the Project using the following command:

dotnet new whitelabel-service -o YourProjectPrefix.YourProjectName

Once created:

cd .\YourProjectPrefix.YourProjectName\'

Then run the following command to reference the Demo Projects from Aspire:"

Example (Change values as required):

`.\RUNME.ps1 -projectNameBase "Gateway" -aspireProjectName "Gateway.Aspire" -aspireSolutionFolder "C:\WL\Gateway\Gateway.Aspire" -serviceDefaultsPackage "Gateway.Aspire.ServiceDefaults" -packagesAndContainersSolutionFolder "C:\WL\Gateway\Gateway.PackagesAndContainers" -ApiOnly True`
  
