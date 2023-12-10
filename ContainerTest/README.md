# WhiteLabel Distributed Development Environment Information 

The following docker containers have been setup for this project: 

- Container Registry : http://localhost:39444
- [Container Registry UI](http://localhost:43266): http://localhost:43266
- [Package Source UI](http://localhost:35476): http://localhost:35476

## Configuration Information 

The config file for this Cloud Native Applcation can be found here:

`C:\WL\WhiteLabel\Configuration\WhiteLabel.config.json`

The Configuration folder holds all values used in project initialisation.

`C:\WL\WhiteLabel\Configuration\WhiteLabel.DemoService.config.json`

The WhiteLabel.PackagesAndContainers solution has within it a special posts.config.json 
which has been copied here. This is used during initialisation to manage the dynamic ports for the nuget.config file which has 
also been copied here

The nuget file can be placed into new project you generate so that they can access the local 
package source.

## Aspire AppHost Wire-up 

Use the following to replace the content of Program.cs in Aspire.AppHost folder.

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var apiBackendForFrontEnd = builder.AddProject<Projects.WhiteLabel_Sample_Demo_WebApi>("website-api-backend-for-frontend")
.WithLaunchProfile("https");

var websiteFrontend = builder.AddProject<Projects.WhiteLabel_Sample_Demo_UserInterface>("website-frontend")
.WithLaunchProfile("https")
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

`.\RUNME.ps1 -projectNameBase "WhiteLabel" -aspireProjectName "WhiteLabel.Aspire" -aspireSolutionFolder "C:\WL\WhiteLabel\WhiteLabel.Aspire" -serviceDefaultsPackage "WhiteLabel.Aspire.ServiceDefaults" -packagesAndContainersSolutionFolder "C:\WL\WhiteLabel\WhiteLabel.PackagesAndContainers"`

