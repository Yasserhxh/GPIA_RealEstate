# Use ASP.NET runtime for the final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use .NET SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

# (Optional) If you have private feed credentials
# If using a private feed that needs credentials:
ARG FEED_URL="https://pkgs.dev.azure.com/hafifi0336/AlexsysFoundations/_packaging/NuGet-NetCore/nuget/v3/index.json"
ARG FEED_USERNAME="your-username"  # Azure DevOps often doesn't require a real username
ARG FEED_PASSWORD="hlbqvxdpzkyml4bpoitebvwiwguphrwb4iro2osnl4pv73gdvrza"

WORKDIR /src

# 1) Copy your solution + Directory.Build.props
COPY ["src/ProjectAPI/ProjectAPI.sln", "."]
COPY ["src/ProjectAPI/Directory.Build.props", "."]

# 2) Copy each .csproj to the correct place in the container
COPY ["src/ProjectAPI/src/Api/ProjectAPI.Api.csproj", "."]
COPY ["src/ProjectAPI/src/Domain/ProjectAPI.Domain.csproj", "Domain/"]
COPY ["src/ProjectAPI/src/Infrastructure/ProjectAPI.Infrastructure.csproj", "Infrastructure/"]

# 3) If using a private NuGet feed, add it
RUN dotnet nuget add source \
    "$FEED_URL" \
    --name "MyPrivateFeed" \
    --username "$FEED_USERNAME" \
    --password "$FEED_PASSWORD" \
    --store-password-in-clear-text

# 4) Restore
RUN dotnet restore "ProjectAPI.Api.csproj"

# 5) Copy the rest of the code (includes Program.cs, etc.)
COPY src/ProjectAPI/. .

# 6) Build
RUN dotnet build "ProjectAPI.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 7) Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProjectAPI.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 8) Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectAPI.Api.dll"]
