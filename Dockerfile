# Use the official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY hakaton-yz-api.csproj ./
RUN dotnet restore ./hakaton-yz-api.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish ./hakaton-yz-api.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose port (change if your app uses a different port)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "hakaton-yz-api.dll"]
