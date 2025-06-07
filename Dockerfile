# Use .NET 9.0 SDK preview image to build the app
FROM mcr.microsoft.com/dotnet/nightly/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY *.sln ./
COPY LLMStudio/*.csproj ./LLMStudio/
RUN dotnet restore

# Copy the source code and build
COPY LLMStudio/. ./LLMStudio/
WORKDIR /src/LLMStudio
RUN dotnet publish -c Release -o /app/publish

# Use ASP.NET 9.0 runtime image
FROM mcr.microsoft.com/dotnet/nightly/aspnet:9.0 AS runtime
WORKDIR /app

# Copy the published output from build stage
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Set the entrypoint to run the app
ENTRYPOINT ["dotnet", "LLMStudio.dll"]
