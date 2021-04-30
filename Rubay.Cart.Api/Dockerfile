#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Rubay.Cart.Api/Rubay.Cart.Api.csproj", "Rubay.Cart.Api/"]
RUN dotnet restore "Rubay.Cart.Api/Rubay.Cart.Api.csproj"
COPY . .
WORKDIR "/src/Rubay.Cart.Api"
RUN dotnet build "Rubay.Cart.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rubay.Cart.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rubay.Cart.Api.dll"]