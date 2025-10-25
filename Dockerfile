FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["CopilotProject.csproj", "./"]
RUN dotnet restore

# Copy the rest of the code
COPY . .

# Build the application
RUN dotnet build "CopilotProject.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "CopilotProject.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CopilotProject.dll"]