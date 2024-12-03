# Create the build environment image
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0.100-noble as build-env

WORKDIR /app

# Copy the project file and restore the dependencies
COPY src/*.csproj ./
RUN dotnet restore

# Copy the remaining source files and build the application
COPY src/. ./
RUN dotnet publish -c Release -r linux-x64 -o out

# Build the runtime image
FROM --platform=$TARGETPLATFORM mcr.microsoft.com/dotnet/runtime:9.0.0-noble

WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "password_generator.dll"]
