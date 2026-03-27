# Creates an archive with all the required nuget packages.

dotnet restore --packages ./output-packages
mkdir -p output-windows
find ./output-packages -name "*.nupkg" -exec cp {} ./output-windows \;

dotnet pack ./src/Reqnroll.Amp/Reqnroll.Amp.csproj -c Release -o ./output-windows
dotnet pack ./src/Reqnroll.Amp-windows/Reqnroll.Amp-windows.csproj -c Release -o ./output-windows

tar -czf artifacts-windows.tar.gz -C output-windows .

rm -rf output-windows

