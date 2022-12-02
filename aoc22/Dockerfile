FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["aoc22/aoc22.csproj", "aoc22/"]
RUN dotnet restore "aoc22/aoc22.csproj"
COPY . .
WORKDIR "/src/aoc22"
RUN dotnet build "aoc22.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aoc22.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aoc22.dll"]
