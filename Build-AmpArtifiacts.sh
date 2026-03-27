# Creates an archive with all the required nuget packages.

dotnet restore --packages ./output-packages
mkdir -p output
find ./output-packages -name "*.nupkg" -exec cp {} ./output \;

dotnet pack ./src/Reqnroll.Amp/Reqnroll.Amp.csproj -c Release -o ./output

tar -czf artifacts.tar.gz -C output .


rm -rf output

