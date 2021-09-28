#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/PM.BazaarCore.Services.WebApi/PM.BazaarCore.Services.WebApi.csproj", "src/PM.BazaarCore.Services.WebApi/"]
COPY ["src/PM.BazaarCore.Infrastructure.CrossCutting.AspNetFilters/PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.csproj", "src/PM.BazaarCore.Infrastructure.CrossCutting.AspNetFilters/"]
COPY ["src/PM.Bazaar.Infrastructure.CrossCutting.Identity/PM.BazaarCore.Infrastructure.CrossCutting.Identity.csproj", "src/PM.Bazaar.Infrastructure.CrossCutting.Identity/"]
COPY ["src/PM.BazaarCore.Domain/PM.BazaarCore.Domain.csproj", "src/PM.BazaarCore.Domain/"]
COPY ["src/PM.BazaarCore.Domain.Core/PM.BazaarCore.Domain.Core.csproj", "src/PM.BazaarCore.Domain.Core/"]
COPY ["src/PM.Bazaar.Infrastructure.CrossCutting.Configuration/PM.BazaarCore.Infrastructure.CrossCutting.Configuration.csproj", "src/PM.Bazaar.Infrastructure.CrossCutting.Configuration/"]
COPY ["src/PM.BazaarCore.Application/PM.BazaarCore.Application.csproj", "src/PM.BazaarCore.Application/"]
COPY ["src/PM.Bazaar.Infrastructure.Data/PM.BazaarCore.Infrastructure.Data.csproj", "src/PM.Bazaar.Infrastructure.Data/"]
COPY ["src/PM.BazaarCore.Infrastructure.CrossCutting.IoC/PM.BazaarCore.Infrastructure.CrossCutting.IoC.csproj", "src/PM.BazaarCore.Infrastructure.CrossCutting.IoC/"]
RUN dotnet restore "src/PM.BazaarCore.Services.WebApi/PM.BazaarCore.Services.WebApi.csproj"
COPY . .
WORKDIR "/src/src/PM.BazaarCore.Services.WebApi"
RUN dotnet build "PM.BazaarCore.Services.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PM.BazaarCore.Services.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PM.BazaarCore.Services.WebApi.dll"]