FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /src

# Use the official .NET Core SDK as parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY MfaApi.csproj ./
RUN dotnet restore
COPY . .

# Apply migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet ef database update --connection $PGSQL_CONNECTION_STRING --assembly

# Publish the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /src
COPY --from=build /src/out ./

EXPOSE 8080

# Start the application
ENTRYPOINT dotnet MfaApi.dll -e ConnectionStrings__postgresdb=$PGSQL_CONNECTION_STRING Auth0__Authority=$AUTH0_AUTHORITY Auth0__Audience=$AUTH0_AUDIENCE