# LB Distributed Development Environment Information 

The following docker containers have been setup for this project: 

- Container Registry : http://localhost:35615
- [Container Registry UI](http://localhost:10553): http://localhost:10553
- [Package Source UI](http://localhost:37253): http://localhost:37253

## Configuration Information 

The config file for this Cloud Native Applcation can be found here:

`C:\WL\LB\Configuration\LB.config.json`

The Configuration folder holds all values used in project initialisation.

`C:\WL\LB\Configuration\LB.DemoService.config.json`

The LB.PackagesAndContainers solution has within it a special posts.config.json 
which has been copied here. This is used during initialisation to manage the dynamic ports for the nuget.config file which has 
also been copied here

The nuget file can be placed into new project you generate so that they can access the local 
package source.

## Aspire AppHost Wire-up 

Use the following to replace the content of Program.cs in Aspire.AppHost folder.

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var apiBackendForFrontEnd = builder.AddProject<Projects.LB_Sample_Demo_WebApi>("api-backend-for-frontend")
.WithLaunchProfile("http");

var frontend = builder.AddProject<Projects.LB_Sample_Demo_UserInterface>("ui-frontend")
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

`.\RUNME.ps1 -projectNameBase "LB" -aspireProjectName "LB.Aspire" -aspireSolutionFolder "C:\WL\LB\LB.Aspire" -serviceDefaultsPackage "LB.Aspire.ServiceDefaults" -packagesAndContainersSolutionFolder "C:\WL\LB\LB.PackagesAndContainers"`

