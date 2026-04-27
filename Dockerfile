# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ["TestAPI/TestAPI.csproj", "TestAPI/"]
RUN dotnet restore "./TestAPI.csproj"

# Copy everything else
COPY . .

# Publish app
RUN dotnet publish "TestAPI.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Start app
ENTRYPOINT ["dotnet", "TestAPI.dll"]
