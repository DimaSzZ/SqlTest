FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SqlRequest/SqlRequest.csproj", "SqlRequest/"]
RUN dotnet restore "SqlRequest/SqlRequest.csproj"
COPY . .
WORKDIR "/src/SqlRequest"
RUN dotnet build "SqlRequest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SqlRequest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SqlRequest.dll"]
