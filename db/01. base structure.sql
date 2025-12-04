CREATE DATABASE Tekus_PruebaTecnica;
GO

USE Tekus_PruebaTecnica;

CREATE TABLE Supplier (
    Id INT IDENTITY(1,1) NOT NULL,
    TaxId VARCHAR(50) NOT NULL,
    Name VARCHAR(200) NOT NULL,
    Email VARCHAR(200) NOT NULL,
);
GO

ALTER TABLE Supplier ADD CONSTRAINT PK_Supplier PRIMARY KEY (Id);
GO

CREATE TABLE [Service] (
    Id INT IDENTITY(1,1) NOT NULL,
    SupplierId INT NOT NULL,
    [Name] VARCHAR(200) NOT NULL,
    HourlyRate DECIMAL(18,2) NOT NULL,
);

ALTER TABLE [Service] ADD CONSTRAINT PK_Service PRIMARY KEY (Id);
GO

ALTER TABLE [Service] ADD CONSTRAINT FK_Service_Supplier FOREIGN KEY (SupplierId) REFERENCES Supplier(Id);
GO

CREATE TABLE Country (
    Id INT IDENTITY(1,1) NOT NULL,
    Name VARCHAR(150) NOT NULL,
    Code VARCHAR(10) NOT NULL,
);
GO

ALTER TABLE Country ADD CONSTRAINT PK_Country PRIMARY KEY (Id);
GO

CREATE TABLE ServiceCountry (
	Id INT IDENTITY(1,1) NOT NULL,
    ServiceId INT NOT NULL,
    CountryId INT NOT NULL,
);
GO

ALTER TABLE ServiceCountry ADD CONSTRAINT PK_ServiceCountry PRIMARY KEY (Id);
GO

ALTER TABLE ServiceCountry ADD CONSTRAINT FK_ServiceCountry_Service FOREIGN KEY (ServiceId) REFERENCES [Service](Id);
GO

ALTER TABLE ServiceCountry ADD CONSTRAINT FK_ServiceCountry_Country FOREIGN KEY (CountryId) REFERENCES Country(Id);
GO

CREATE TABLE SupplierAttribute (
    Id INT IDENTITY(1,1) NOT NULL,
    SupplierId INT NOT NULL,
    AttributeName VARCHAR(200) NOT NULL,
    AttributeValue NVARCHAR(MAX) NOT NULL,
);
GO

ALTER TABLE SupplierAttribute ADD CONSTRAINT PK_SupplierAttribute PRIMARY KEY (Id);
GO

ALTER TABLE SupplierAttribute ADD CONSTRAINT FK_SupplierAttribute_Supplier FOREIGN KEY (SupplierId) REFERENCES Supplier(Id);
GO