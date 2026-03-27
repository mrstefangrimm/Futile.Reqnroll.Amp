# Creates an archive with all the required nuget packages.

dotnet restore --packages ./output-packages
New-Item -ItemType Directory -Force -Path .\output
Get-ChildItem -Path .\output-packages -Recurse -Filter *.nupkg | Copy-Item -Destination .\output

dotnet pack .\src\Reqnroll.Amp\Reqnroll.Amp.csproj -c Release -o ./output

Compress-Archive -Path .\output\* -DestinationPath .\artifacts.zip -Force

Remove-Item -Path .\output -Recurse -Force

