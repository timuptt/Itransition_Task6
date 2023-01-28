FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ItraMessenger.WEB/ItraMessenger.WEB.csproj", "ItraMessenger.WEB/"]
RUN dotnet restore "ItraMessenger.WEB/ItraMessenger.WEB.csproj"
COPY . .
WORKDIR "/src/ItraMessenger.WEB"
RUN dotnet build "ItraMessenger.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ItraMessenger.WEB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ItraMessenger.WEB.dll"]
