using System.Diagnostics;
using System.Text.Json;

public class StartService
{

    public StartService(string configPath)
    {
        var jsonString = File.ReadAllText(configPath);
        var jsonDoc = JsonDocument.Parse(jsonString);
        var config = JsonSerializer.Deserialize<PortConfig>(jsonDoc);

        var process = new Process();
        process.StartInfo.FileName = @"C:\Program Files\Docker\Docker\resources\bin\docker.exe";
        process.StartInfo.Arguments = "compose up --detach";
        process.StartInfo.CreateNoWindow = false;
        var startResult = process.Start();
        Console.Write(startResult);

    }

}