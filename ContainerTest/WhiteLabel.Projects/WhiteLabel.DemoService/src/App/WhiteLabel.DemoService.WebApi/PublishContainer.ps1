
$Process = Start-Process -PassThru -NoNewWindow "C:\Program Files\dotnet\dotnet.exe" -ArgumentList "publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer"
$Process.WaitForExit()

