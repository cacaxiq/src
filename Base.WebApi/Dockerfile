FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY Base.sln ./
COPY Base.WebApi/Base.WebApi.csproj Base.WebApi/
COPY Base.ExternalData/Base.ExternalData.csproj Base.ExternalData/
COPY Base.Domain/Base.Domain.csproj Base.Domain/
COPY Base.Shared.Enum/Base.Shared.Enum.csproj Base.Shared.Enum/
COPY Base.Shared.Domain/Base.Shared.Domain.csproj Base.Shared.Domain/
COPY Base.Shared.Extension/Base.Shared.Extension.csproj Base.Shared.Extension/
COPY Base.IoC/Base.IoC.csproj Base.IoC/
COPY Base.Application/Base.Application.csproj Base.Application/
COPY Base.Bus/Base.Bus.csproj Base.Bus/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Base.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Base.WebApi.dll"]
