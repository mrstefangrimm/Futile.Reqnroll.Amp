# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY WebCalculator/*.csproj ./WebCalculator/
RUN dotnet restore WebCalculator/WebCalculator.csproj

COPY . .
RUN dotnet publish WebCalculator/WebCalculator.csproj -c Release -o /app/dist

# Runtime stage (nginx)
FROM nginx:stable-alpine3.24-slim AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/dist/wwwroot .

RUN sed -i 's/listen  *80;/listen 8080;/g' /etc/nginx/conf.d/default.conf
RUN sed -i '/^[[:space:]]*user[[:space:]]/d' /etc/nginx/nginx.conf

EXPOSE 8080
