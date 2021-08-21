# Create the build environment image
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env
WORKDIR /app

# Copy the project file and restore the dependencies
COPY src/*.csproj ./
RUN dotnet restore

# Copy the remaining source files and build the application
COPY src/. ./
RUN dotnet publish -c Release -r linux-x64 -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "password_generator.dll"]
