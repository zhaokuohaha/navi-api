FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY ./*.sln .

COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*} && mv $file ${file%.*}; done
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 5002
ENV ASPNETCORE_URLS http://*:5002 
ENV ASPNETCORE_ENVIRONMENT production

ENTRYPOINT "dotnet" "Fcz.Navi.Api.WebApi.dll"

# 本写法参考: https://stackoverflow.com/a/56728945
# 标准写法: https://github.com/dotnet/dotnet-docker/blob/master/samples/complexapp/Dockerfile