# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Install Playwright dependencies
#RUN apt-get update && apt-get install -y \
    #libnss3 \
    #libatk1.0-0 \
    #libatk-bridge2.0-0 \
    #libcups2 \
    #libdrm2 \
    #libxkbcommon0 \
    #libxcomposite1 \
    #libxdamage1 \
    #libxfixes3 \
    #libxrandr2 \
    #libgbm1 \
    #libasound2 \
    #libpangocairo-1.0-0 \
    #libpango-1.0-0 \
    #libcairo2 \
    #libatspi2.0-0 \
    #libx11-xcb1 \
    #libxshmfence1 \
    #wget \
    #&& rm -rf /var/lib/apt/lists/*



# Copy csproj and restore
COPY WebCalculator.Specs/*.csproj ./WebCalculator.Specs/
RUN dotnet restore WebCalculator.Specs/WebCalculator.Specs.csproj

# Copy everything and publish
COPY . .
##RUN dotnet publish WebCalculator.Specs/WebCalculator.Specs.csproj -c Release -o /app/publish
##
# Install Chromium browser for Playwright
RUN dotnet tool install --global Microsoft.Playwright.CLI
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR /src/WebCalculator.Specs
RUN dotnet build

RUN playwright install-deps
RUN playwright install chromium

# Runtime stage
##FROM mcr.microsoft.com/dotnet/runtime:10.0 AS final
##
###WORKDIR /src
###COPY WebCalculator.Specs/*.csproj ./WebCalculator.Specs/
###
##WORKDIR /app
##
### Copy published output
##COPY --from=build /app/publish .
##
### Copy installed Playwright browsers
##COPY --from=build /root/.cache/ms-playwright /root/.cache/ms-playwright
##
##COPY WebCalculator.Specs/Settings/AppSettings.json ./Settings/appsettings.json
##
##ENTRYPOINT ["dotnet", "WebCalculator.Specs.dll"]
##

ENTRYPOINT ["bash"]
