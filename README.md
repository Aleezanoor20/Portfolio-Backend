# Portfolio Backend

Backend, gemaakt met ASP.NET Core Web API.

## .NET-versie

Dit project gebruikt **.NET 10**.

## API-keuze en structuur

Ik heb gekozen voor **Controllers**, omdat ik hiermee tijdens de lessen heb gewerkt en omdat de verschillende onderdelen van de applicatie hiermee duidelijk gescheiden zijn.

De structuur is:

```text
Controller → Service → DbContext / Entity Framework Core → SQL Server
```

De Controllers verwerken de HTTP-requests. De Services bevatten de applicatielogica en de DbContext verzorgt de datatoegang.

## SQL Server en database

De applicatie gebruikt **SQL Server Express**.

Server:

```text
localhost\SQLEXPRESS
```

Database:

```text
PortfolioDb
```

De connection string staat in `appsettings.json`.

De database is aangemaakt met een **Entity Framework Core migration**:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Applicatie starten

Open een terminal in de projectmap en voer uit:

```bash
dotnet run
```

Na het starten kan de API via Swagger worden getest. De URL en poort worden in de terminal weergegeven.