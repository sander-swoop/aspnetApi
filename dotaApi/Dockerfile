FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["aspnetApi/dotaApi/dotaApi.csproj", "aspnetApi/dotaApi/"]
RUN dotnet restore "aspnetApi/dotaApi/dotaApi.csproj"
COPY . .
WORKDIR "/src/aspnetApi/dotaApi"
RUN dotnet build "dotaApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotaApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotaApi.dll"]
