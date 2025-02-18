FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /src

# Use the official .NET Core SDK as parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY MfaApi.csproj ./
RUN dotnet restore
COPY . .

# Publish the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /src
COPY --from=build /src/out ./

EXPOSE 8080

ENV PGSQL_CONNECTION_STRING=""
ENV AUTH0_AUTHORITY=""
ENV AUTH0_AUDIENCE=""
ENV MFA_CLIENT_URL=""

# Start the application
ENTRYPOINT ["dotnet", "MfaApi.dll"]