# Get base image (Full .NET Core SDK) & Create work dir. where our app will reside
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy .csproj file (contains dependencies, specifies how code runs) and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build (out is the folder containing app build dll)
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image; only retrieve aspnet runtime image, keeps image "lean"
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "Commander.dll"]