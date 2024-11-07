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

# Apply migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

ARG PGSQL_CONNECTION_STRING
RUN dotnet ef database update --connection=$PGSQL_CONNECTION_STRING

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /src
COPY --from=build /src/out ./

EXPOSE 8080

ARG PGSQL_CONNECTION_STRING
ENV PGSQL_CONNECTION_STRING=$PGSQL_CONNECTION_STRING
ARG AUTH0_AUTHORITY
ENV AUTH0_AUTHORITY=$AUTH0_AUTHORITY
ARG AUTH0_AUDIENCE
ENV AUTH0_AUDIENCE=$AUTH0_AUDIENCE
ARG MFA_CLIENT_URL
ENV MFA_CLIENT_URL=$MFA_CLIENT_URL

# Start the application
ENTRYPOINT dotnet MfaApi.dll -e ConnectionStrings__postgresdb=$PGSQL_CONNECTION_STRING Auth0__Authority=$AUTH0_AUTHORITY Auth0__Audience=$AUTH0_AUDIENCE MfaClientUrl=$MFA_CLIENT_URL