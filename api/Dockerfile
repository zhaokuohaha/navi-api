FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY *.sln .
COPY **/*.csproj ./navi/
RUN dotnet restore

COPY . ./navi/
WORKDIR /app/navi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

COPY --from=build /app/navi/out ./

EXPOSE 5002
ENV ASPNETCORE_URLS http://*:5002 \
    ASPNETCORE_ENVIRONMENT=production

ENTRYPOINT ["dotnet", "Fcz.Navi.Api.WebApi.dll"]