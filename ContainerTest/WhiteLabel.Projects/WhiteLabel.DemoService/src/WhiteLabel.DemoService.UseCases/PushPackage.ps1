
$Process = Start-Process -NoNewWindow -PassThru "C:\Program Files\dotnet\dotnet.exe" -ArgumentList "pack", "--output nupkgs"
$Process.WaitForExit()

$Process = Start-Process -NoNewWindow -PassThru "C:\Program Files\dotnet\dotnet.exe" -ArgumentList "nuget", "push", "./nupkgs/WhiteLabel.DemoService.UseCases.1.0.0.nupkg", "-s http://localhost:35476/v3/index.json", "-k 8B516EDB-7523-476E-AF43-79CCA054CE9F"
$Process.WaitForExit()

