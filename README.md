# KILIMO HIGH - GEORGE WANJOHI


## How to Run the Application

Open appsettings.json, change the value of _KilimoDBConnection_ connection string with an appropriate connection string that points to your MSSQL Server database instance.

Note that the name of the database supplied therein must not be EXISTING already. When you first run the application, a database  with the supplied name will be created.


```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "KilimoDBConnection": "Data Source=localhost;Initial Catalog=KilimoniCloud4;Persist Security Info=True;User ID=sa;Password=303mP$203;MultipleActiveResultSets=True;TrustServerCertificate=True"
  }
}

```
The Generated database will look as follows


```sql
create database KilimoCloud
go

use KilimoCloud
go

create table dbo.FormStreams
(
    FormStreamId uniqueidentifier not null
        constraint PK_FormStreams
            primary key,
    Name         nvarchar(max)    not null
)
go


use KilimoniCloud
go

create table dbo.Students
(
    Id              uniqueidentifier not null
        constraint PK_Students
            primary key,
    Name            nvarchar(200)    not null,
    Age             int              not null,
    GuardianContact nvarchar(200)    not null,
    FormStreamId    uniqueidentifier not null
        constraint FK_Students_FormStreams_FormStreamId
            references dbo.FormStreams
            on delete cascade
)
go

create index IX_Students_FormStreamId
    on dbo.Students (FormStreamId)
go



```