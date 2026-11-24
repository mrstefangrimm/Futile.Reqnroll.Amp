ARG PLAYWRIGHT_VERSION=1.63.0

# Stage 1: Build stage
FROM playwrightsdkbase:${PLAYWRIGHT_VERSION} AS build

WORKDIR /app

COPY WebCalculator.Specs/ ./

RUN dotnet restore && \
    dotnet build --configuration Debug --no-restore


# Stage 2: Runtime stage
FROM playwrightruntimebase:${PLAYWRIGHT_VERSION}

WORKDIR /app

# Copy built artifacts from the build stage
COPY --from=build /app/bin/Debug/ ./

ENTRYPOINT ["bash"]
