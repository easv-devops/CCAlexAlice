FROM mcr.microsoft.com/dotnet/aspnet:8.0.1 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CurrencyConverter/CurrencyConverter.csproj", "CurrencyConverter/"] 
RUN dotnet restore "CurrencyConverter/CurrencyConverter.csproj"
COPY . .
WORKDIR "/src/CurrencyConverter"
RUN dotnet build "CurrencyConverter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CurrencyConverter.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CurrencyConverter.dll"]