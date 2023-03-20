use master

DECLARE @dbname nvarchar(128)
SET @dbname = 'MPP'

IF (EXISTS (SELECT name 
             FROM master.dbo.sysdatabases 
             WHERE ('[' + name + ']' = @dbname 
                    OR name = @dbname)))
BEGIN
    PRINT 'The database ' + @dbname + ' exists in the SQL Server instance.'
	DECLARE @sql nvarchar(max)
    SET @sql = 'DROP DATABASE ' + QUOTENAME(@dbname)
    EXEC sp_executesql @sql
END
ELSE
BEGIN
    PRINT 'The database ' + @dbname + ' does not exist in the SQL Server instance.'
END

SET @sql = 'CREATE DATABASE ' + QUOTENAME(@dbname)
EXEC sp_executesql @sql

go

Use MPP

create table Users(
	id int primary key identity,
	username varchar(50),
	password varchar(50)
)

go

create table Trials(
	id int primary key identity,
	name varchar(50),
	distance int,
	style varchar(50),
	startTime datetime,

	check(distance > 0)
)

go

create table Registrations(
	id int primary key identity,
	userId int foreign key references Users(id),
	trialId int foreign key references Trials(id)
)