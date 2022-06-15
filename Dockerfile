FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
MAINTAINER Tarik Zeid <tarik.zeid@alten.be>

WORKDIR /app
EXPOSE 8888

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Powerplant-Challenge/Powerplant-Challenge.csproj", "Powerplant-Challenge/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Powerplant-Challenge/Powerplant-Challenge.csproj"
COPY . .
WORKDIR "/src/Powerplant-Challenge"
RUN dotnet build "Powerplant-Challenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Powerplant-Challenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Powerplant-Challenge.dll"]