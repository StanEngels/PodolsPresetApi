FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /PresetApi

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_URLS=https://+:5001
EXPOSE 5000 5001
WORKDIR /PresetApi
COPY --from=build-env /PresetApi/out .
ENTRYPOINT ["./PresetApi"]