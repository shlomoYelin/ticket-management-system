# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY ["TicketApi/TicketApi.csproj", "TicketApi/"]
COPY ["TicketManagement.Application/TicketManagement.Application.csproj", "TicketManagement.Application/"]
COPY ["TicketManagement.Domain/TicketManagement.Domain.csproj", "TicketManagement.Domain/"]
COPY ["TicketManagement.Infrastructure/TicketManagement.Infrastructure.csproj", "TicketManagement.Infrastructure/"]

RUN dotnet restore "TicketApi/TicketApi.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/TicketApi"
RUN dotnet build "TicketApi.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "TicketApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

# Copy published app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TicketApi.dll"]
