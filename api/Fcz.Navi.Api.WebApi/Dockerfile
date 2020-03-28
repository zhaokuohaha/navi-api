FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime

WORKDIR /app

COPY . /app

EXPOSE 5002
ENV ASPNETCORE_URLS http://*:5002
ENV ASPNETCORE_ENVIRONMENT=production

ENTRYPOINT ["dotnet", "Fcz.Navi.Api.WebApi.dll"]