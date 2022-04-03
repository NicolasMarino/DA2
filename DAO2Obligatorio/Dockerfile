#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
# COPY ["DAO2Obligatorio/DAO2Obligatorio.WebApi.csproj", "DAO2Obligatorio/"]
# COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
# COPY ["IBusinessLogic/IBusinessLogic.csproj", "IBusinessLogic/"]
# COPY ["Domain/Domain.csproj", "Domain/"]
# COPY ["DataAccessInterface/DataAccessInterface.csproj", "DataAccessInterface/"]
# COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY . .
#
RUN dotnet restore "DAO2Obligatorio/DAO2Obligatorio.WebApi.csproj"
#
WORKDIR "/src/."
COPY . .
RUN dotnet build "DAO2Obligatorio/DAO2Obligatorio.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DAO2Obligatorio/DAO2Obligatorio.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:PORT_NUMBER
ENTRYPOINT ["dotnet", "DAO2Obligatorio.WebApi.dll"]
