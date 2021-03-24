dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialMigration -s .\src\WebUI\ -p .\src\Infrastructure\

