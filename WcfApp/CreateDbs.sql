USE [Master]
GO

CREATE DATABASE AlunosClient1
GO

USE [AlunosClient1]
GO

CREATE TABLE [dbo].[Alunos]
(   
 [Id] [uniqueidentifier] DEFAULT NEWID() NOT NULL,
 [Name] [nchar](50) NULL
) 
GO

INSERT INTO ALUNOS (NAME) VALUES ('Aluno do Cliente 1')
GO

USE [Master]
GO

CREATE DATABASE AlunosClient2
GO

USE [AlunosClient2]
GO

CREATE TABLE [dbo].[Alunos]
(   
 [Id] [uniqueidentifier] DEFAULT NEWID() NOT NULL,
 [Name] [nchar](50) NULL
) 
GO

INSERT INTO ALUNOS (NAME) VALUES ('Aluno do Cliente 2')
GO