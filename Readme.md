# Demo project using Marted to create a new database from a console application

`DocumentStore.For<>` is not creating the database from connection string. 

`select 1` throw following error

```
Marten.Exceptions.MartenCommandException: Marten Command Failure:
3D000: database "db_1" does not exist
---> Npgsql.PostgresException (0x80004005): 3D000: database "db_1" does not exist
```
