# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src


# Copy csproj and restore
COPY Reqnroll.Amp/Core/*.csproj ./Reqnroll.Amp/Core/
COPY WeatherApi.Specs/*.csproj ./WeatherApi.Specs/
RUN dotnet restore WeatherApi.Specs/WeatherApi.Specs.csproj

# Copy everything and publish
COPY . .
##RUN dotnet publish WeatherApi.Specs/WeatherApi.Specs.csproj -c Release -o /app/publish


WORKDIR /src/WeatherApi.Specs
RUN dotnet build

# RUN playwright install-deps
# RUN playwright install chromium

# Runtime stage
##FROM mcr.microsoft.com/dotnet/runtime:10.0 AS final
##
###WORKDIR /src
###COPY WeatherApi.Specs/*.csproj ./WeatherApi.Specs/
###
##WORKDIR /app
##
### Copy published output
##COPY --from=build /app/publish .
##
##COPY WeatherApi.Specs/Settings/AppSettings.json ./Settings/appsettings.json
##
##ENTRYPOINT ["dotnet", "WeatherApi.Specs.dll"]
##

ENTRYPOINT ["bash"]
