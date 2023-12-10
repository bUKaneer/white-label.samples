# Local Containers & Packages

This environment allows the developer to manage packages between the distributed projects where code reuse is required.

Libraries such as Servce Defaults and Shared Kernels are good candidates.

Orchestration tooling can use any projects deployed as containers to the local registry to aid in providing additional custom infrastructure.

## Local NuGet (Baget)

Add Baget as Package Source

`dotnet nuget add source http://localhost:9002/v3/index.json --name baget`

Use the following command in the same folder as the `.csproj` to pack files ready for Baget.

`dotnet pack --output nupkgs`

Push the package to Baget.

`dotnet nuget push ./nupkgs/ProjectName.nupkg -s http://localhost:19002/v3/index.json -k 8B516EDB-7523-476E-AF43-79CCA054CE9F`

## Local Container Registry

Add Containerisation Support to the project, run in the same folder as `.csproj` file.

`dotnet add package Microsoft.NET.Build.Containers`

Setup containerisation settings

In `.csproj` file add `ContainerRepository` and `ContainerRegistry` elements with appropriate values.

```xml

<PropertyGroup>
    <!-- Other Properties here -->
    <ContainerRepository>white-label.projectname</ContainerRepository>
    <ContainerRegistry>localhost:19001</ContainerRegistry>
</PropertyGroup>

```

Publish to Local Registry, run this in the same folder as the `.csproj` file.

`dotnet publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer`
