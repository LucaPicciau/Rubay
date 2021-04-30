#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Rubay.Web.App/Rubay.Web.App.csproj", "Rubay.Web.App/"]
RUN dotnet restore "Rubay.Web.App/Rubay.Web.App.csproj"
COPY . .
WORKDIR "/src/Rubay.Web.App"
RUN dotnet build "Rubay.Web.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rubay.Web.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rubay.Web.App.dll"]