FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebAPI1.csproj", "./"]
RUN dotnet restore "WebAPI1.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebAPI1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI1.dll"]
