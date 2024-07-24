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

