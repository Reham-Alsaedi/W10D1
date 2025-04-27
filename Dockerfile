# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the csproj file and restore any dependencies (via dotnet restore)
COPY ProductApp.csproj /src/

RUN dotnet restore "/src/ProductApp.csproj"

# Copy the entire source code and build the app
COPY . /src/
WORKDIR /src
RUN dotnet build "ProductApp.csproj" -c Release -o /app/build

# Publish the app to the /app/publish folder
FROM build AS publish
RUN dotnet publish "ProductApp.csproj" -c Release -o /app/publish

# Set up the final image based on the base image and copy the published app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "ProductApp.dll"]
