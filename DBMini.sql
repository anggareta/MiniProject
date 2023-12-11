IF NOT EXISTS(SELECT *
FROM sys.databases
WHERE name = 'DBMini')
  BEGIN
  CREATE DATABASE [DBMini]
END
GO

USE [DBMini]
GO
IF NOT EXISTS (SELECT *
FROM sysobjects
WHERE name='TMCustomer' and xtype='U')
BEGIN
  CREATE TABLE TMCustomer
  (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    Name VARCHAR(100),
    BirthDate DATETIME2,
    Address VARCHAR(100)
  )
END

IF NOT EXISTS (SELECT *
FROM sysobjects
WHERE name='TMPromo' and xtype='U')
BEGIN
  CREATE TABLE TMPromo
  (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    PromoName VARCHAR(100)
  )
END