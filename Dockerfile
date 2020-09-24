FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["helloworld-api/helloworld-api.csproj", "helloworld-api/"]
RUN dotnet restore "helloworld-api/helloworld-api.csproj"
COPY . .
WORKDIR "/src/helloworld-api"
RUN dotnet build "helloworld-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "helloworld-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "helloworld-api.dll"]
