USE ZedeX

BEGIN TRAN

CREATE TABLE dbo.Emploees
  (
     Id        INT IDENTITY,
     FirstName VARCHAR(30) NOT NULL,
     LastName  VARCHAR(200),
     IsOwner   BIT DEFAULT 0,
     CONSTRAINT emploees_pk PRIMARY KEY NONCLUSTERED (Id),
  )

CREATE TABLE dbo.PartnerAddresses
  (
     Id       INT IDENTITY,
     Location GEOGRAPHY NOT NULL,
     CONSTRAINT partneraddresses_pk PRIMARY KEY NONCLUSTERED (Id)
  )

CREATE TABLE dbo.PartnerCoveredAreas
  (
     Id       INT IDENTITY,
     Location GEOGRAPHY NOT NULL,
     CONSTRAINT partnercoveredareas_pk PRIMARY KEY NONCLUSTERED (Id)
  )

CREATE TABLE dbo.Partners
  (
     Id             INT IDENTITY,
     DocumentNumber VARCHAR(14) NOT NULL,
     Name			VARCHAR(50) NOT NULL,
     CoverageAreaId INT			NOT NULL,
     AddressId      INT			NOT NULL,
     OwnerId        INT			NOT NULL,
     CONSTRAINT partners_pk PRIMARY KEY NONCLUSTERED (Id)
  )

CREATE UNIQUE INDEX partners_documentnumber_uindex
  ON dbo.partners (DocumentNumber);

COMMIT;  