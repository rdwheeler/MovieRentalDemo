FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["samples/Rental/RentalService.Api/RentalService.Api.csproj", "RentalService.Api/"]
RUN dotnet restore "samples/Rental/RentalService.Api/RentalService.Api.csproj"
COPY . .
WORKDIR "/src/RentalService.Api"
RUN dotnet build "RentalService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentalService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentalService.Api.dll"]
