ARG DOTNET_VERSION=10.0

# Build
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build

WORKDIR /src

COPY WebCalculatorApi.Specs/ ./

RUN dotnet restore && \
    dotnet build --configuration Release --no-restore

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/runtime:${DOTNET_VERSION}

WORKDIR /app

# Copy built artifacts from the build stage
COPY --from=build /src/bin/Release/ ./

ENTRYPOINT ["bash"]
