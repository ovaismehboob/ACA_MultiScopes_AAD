FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:443
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebUI.csproj", "./"]
RUN dotnet restore "WebUI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebUI.dll"]
