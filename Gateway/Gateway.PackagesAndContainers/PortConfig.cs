
public record struct PortConfig(
    string ProjectName,
    string PortConfigFilePath,
    string PortConfigFileName = "ports.config.json",
    int ContainersRegistryPort = 19000,
    int ContainersUserInterfacePort = 19001,
    int PackagesUserInterfacePort = 19002
)
{
    public string GetPortConfigFullPath()
    {
        return Path.Combine(PortConfigFilePath, PortConfigFileName);
    }

    public string GetProjectNameFromFolderName()
    {
        if (!string.IsNullOrWhiteSpace(ProjectName)) return ProjectName;

        var projectName = new DirectoryInfo(PortConfigFilePath).Name;
        return string.IsNullOrWhiteSpace(projectName)
            ? Guid.NewGuid().ToString()
            : projectName;
    }

    public string GetProjectNameFromFolderNameAsKebabCase()
    {
        return GetProjectNameFromFolderName().Replace(".", "-").ToLower();
    }
};
