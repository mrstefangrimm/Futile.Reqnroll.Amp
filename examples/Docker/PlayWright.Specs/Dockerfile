ARG PLAYWRIGHT_VERSION=v1.65.1-noble

# Stage 1: Build
FROM mcr.microsoft.com/playwright/dotnet:${PLAYWRIGHT_VERSION} AS build

WORKDIR /src

COPY WebCalculator.Specs/ ./

RUN dotnet restore && \
    dotnet build --configuration Release --no-restore

# Stage 2: Run
FROM mcr.microsoft.com/playwright/dotnet:${PLAYWRIGHT_VERSION}

WORKDIR /app

# Copy built artifacts from the build stage
COPY --from=build /src/bin/Release/ ./

ENTRYPOINT ["bash"]
