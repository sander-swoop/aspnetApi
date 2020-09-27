FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8000
ENV ASPNETCORE_URLS=http://*:8000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . ./hotsApi
RUN dotnet restore "hotsApi/hotsApi.csproj"
COPY . .
WORKDIR "/src/hotsApi"
RUN dotnet build "hotsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hotsApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hotsApi.dll"]
