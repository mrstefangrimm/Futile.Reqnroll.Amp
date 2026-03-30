# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY WebCalculatorApi.Specs/*.csproj ./WebCalculatorApi.Specs/
RUN dotnet restore WebCalculatorApi.Specs/WebCalculatorApi.Specs.csproj

COPY . .

WORKDIR /src/WebCalculatorApi.Specs
RUN dotnet build

ENTRYPOINT ["bash"]
