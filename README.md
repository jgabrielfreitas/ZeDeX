# ZeDeX
A partner CRUD

# Requirements
- Docker

# Getting started

Database structure:
```sql
USE master
CREATE DATABASE ZedeX2

create table dbo.Emploees
(
	Id int identity,
	FirstName varchar(30) not null,
	LastName varchar(200),
	IsOwner bit default 0,
	constraint Emploees_pk
		primary key nonclustered (Id),
)

create table dbo.PartnerAddresses
(
	Id int identity,
	Location geography not null,
	constraint PartnerAddresses_pk
		primary key nonclustered (Id)
)

create table dbo.PartnerCoveredAreas
(
	Id int identity,
	Location geography not null,
	constraint PartnerCoveredAreas_pk
		primary key nonclustered (Id)
)

create table dbo.Partners
(
	Id int identity,
	DocumentNumber int not null,
	CoverageAreaId int not null,
	AddressId int not null,
	OwnerId int not null,
	constraint Partners_pk
		primary key nonclustered (Id)
)

create unique index Partners_DocumentNumber_uindex
	on dbo.Partners (DocumentNumber)

```