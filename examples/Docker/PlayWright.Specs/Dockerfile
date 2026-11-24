ARG PLAYWRIGHT_VERSION=v1.64.1-noble

# Stage 1: Build stage
FROM mcr.microsoft.com/playwright/dotnet:${PLAYWRIGHT_VERSION} AS build

WORKDIR /app

COPY WebCalculator.Specs/ ./

RUN dotnet restore && \
    dotnet build --configuration Debug --no-restore


# Stage 2: Runtime stage
FROM mcr.microsoft.com/playwright/dotnet:${PLAYWRIGHT_VERSION}

WORKDIR /app

# Copy built artifacts from the build stage
COPY --from=build /app/bin/Debug/ ./

ENTRYPOINT ["bash"]
