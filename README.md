# ZeDeX
A partner CRUD

# Requirements
- Docker

# Getting started

1. First of all, start a localhost sqlserver instance:
```sh
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Passw0rd" -p 1433:1433 --name sqlserver -d microsoft/mssql-server-linux
```
2. You'll need to create the `Zedex` database and application's data structure.
> Run create_database.sql and create_database_structure.sql respectively

3. Start application:
```sh

```

