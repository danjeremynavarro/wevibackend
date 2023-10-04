FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["wevibackend/wevibackend.csproj", "wevibackend/"]
RUN dotnet restore "wevibackend/wevibackend.csproj"
COPY . .
WORKDIR "/src/wevibackend"
RUN dotnet build "wevibackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "wevibackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "wevibackend.dll"]
