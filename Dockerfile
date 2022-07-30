FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["aerospike.csproj", "./"]
RUN dotnet restore "./aerospike.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "aerospike.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "aerospike.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aerospike.dll"]