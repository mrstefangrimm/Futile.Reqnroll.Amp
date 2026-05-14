# Creates an archive with all the required nuget packages.

dotnet restore --packages ./output-packages
New-Item -ItemType Directory -Force -Path .\output-windows
Get-ChildItem -Path .\output-packages -Recurse -Filter *.nupkg | Copy-Item -Destination .\output-windows

dotnet pack .\src\Reqnroll.Amp\Reqnroll.Amp.csproj -p:Version=0.1.0 -c Release -o ./output-windows
dotnet pack .\src\Reqnroll.Amp-windows\Reqnroll.Amp-windows.csproj -p:Version=0.1.0 -c Release -o ./output-windows

Compress-Archive -Path .\output-windows\* -DestinationPath .\artifacts-windows.zip -Force

Remove-Item -Path .\output-windows -Recurse -Force

