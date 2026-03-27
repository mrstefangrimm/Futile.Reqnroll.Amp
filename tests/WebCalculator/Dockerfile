# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY WebCalculator/*.csproj ./WebCalculator/
RUN dotnet restore WebCalculator/WebCalculator.csproj

COPY . .
RUN dotnet publish WebCalculator/WebCalculator.csproj -c Release -o /app/dist

# Runtime stage (nginx)
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/dist/wwwroot .

EXPOSE 80
