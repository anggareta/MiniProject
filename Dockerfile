FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MiniProject.API.csproj", "."]
RUN dotnet restore "./MiniProject.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MiniProject.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniProject.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniProject.API.dll"]