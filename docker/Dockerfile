FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./DesafioPagCerto.Core/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN cd DesafioPagCerto.Core && dotnet publish -c Release -o out
# dotnet-ef migrations add DesafioPagCertoDB
# dotnet-ef database update
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/DesafioPagCerto.Core/out .
ENTRYPOINT ["dotnet", "DesafioPagCerto.Core.dll"]