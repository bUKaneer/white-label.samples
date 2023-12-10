using System.Text.Json;

var projectName = Environment.GetCommandLineArgs()[1];

var containersRegistryPortAsString = Environment.GetCommandLineArgs()[2];
var containersRegistryPort = 0;
var validContainerRegistryPort = int.TryParse(containersRegistryPortAsString, out containersRegistryPort);

var containersUserInterfacePortAsString = Environment.GetCommandLineArgs()[3];
var containersUserInterfacePort = 0;
var validContainerUserInterfacePort = int.TryParse(containersUserInterfacePortAsString, out containersUserInterfacePort);

var packagesUserInterfacePortAsString = Environment.GetCommandLineArgs()[4];
var packagesUserInterfacePort = 0;
var validPackagesPort = int.TryParse(packagesUserInterfacePortAsString, out packagesUserInterfacePort);

var validPorts = validContainerRegistryPort
    && validContainerUserInterfacePort
    && validPackagesPort;

var portConfigPath = Path.GetFullPath($@".\");
var portConfigFilename = "ports.config.json";

var config = validPorts
    ? new PortConfig(
        projectName,
        portConfigPath,
        portConfigFilename,
        containersRegistryPort,
        containersUserInterfacePort,
        packagesUserInterfacePort)
    : new PortConfig();

var portConfigFileExists = File.Exists(config.GetPortConfigFullPath());
if (!portConfigFileExists || validPorts)
{
    var configAsJson = JsonSerializer.Serialize(config);
    File.WriteAllText(config.GetPortConfigFullPath(), configAsJson);
}

var dockerComposeTemplateFullPath = Path.Combine(config.PortConfigFilePath, "docker-compose.yaml.template");
var dockerComposeTemplateContent = File.ReadAllText(dockerComposeTemplateFullPath);

var dockerComposeContent = dockerComposeTemplateContent
    .Replace("{project-name}", config.GetProjectNameFromFolderNameAsKebabCase())
    .Replace("{containers-registry-port}", config.ContainersRegistryPort.ToString())
    .Replace("{containers-ui-port}", config.ContainersUserInterfacePort.ToString())
    .Replace("{packages-port}", config.PackagesUserInterfacePort.ToString());

var dockerComposeFullPath = Path.Combine(config.PortConfigFilePath, "docker-compose.yaml");
File.WriteAllText(dockerComposeFullPath, dockerComposeContent);

var dockerComposeFileExists = File.Exists(dockerComposeFullPath);
portConfigFileExists = File.Exists(config.GetPortConfigFullPath());

var canStartProcess = portConfigFileExists && dockerComposeFileExists;
if (canStartProcess) new StartService(config.GetPortConfigFullPath());

var nugetConfigTemplateFileFullPath = Path.Combine(config.PortConfigFilePath, "nuget.config.template");

var nugetConfigTemmplateContent = File.ReadAllText(nugetConfigTemplateFileFullPath);

var nugetConfigFileContent = nugetConfigTemmplateContent
    .Replace("{project-name}", config.ProjectName)
    .Replace("{project-package-source-name}", config.GetProjectNameFromFolderName())
    .Replace("{project-package-source-ip}", config.PackagesUserInterfacePort.ToString());

var nugetConfigFullPath = Path.Combine(config.PortConfigFilePath, "nuget.config");
File.WriteAllText(nugetConfigFullPath, nugetConfigFileContent);





