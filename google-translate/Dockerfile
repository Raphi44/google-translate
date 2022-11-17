
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://*:80
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["google-translate.csproj", "./"]
RUN dotnet restore "./google-translate.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "google-translate.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "google-translate.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "google-translate.dll"]
