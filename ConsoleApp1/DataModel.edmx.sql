
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/06/2019 21:54:10
-- Generated from EDMX file: C:\Users\xueqian\source\RoleManagement\ConsoleApp1\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BackEndRoleManagement];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_classesteachers_classes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[classesteachers] DROP CONSTRAINT [FK_classesteachers_classes];
GO
IF OBJECT_ID(N'[dbo].[FK_classesteachers_teachers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[classesteachers] DROP CONSTRAINT [FK_classesteachers_teachers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[classes1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[classes1];
GO
IF OBJECT_ID(N'[dbo].[teacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[teacher];
GO
IF OBJECT_ID(N'[dbo].[classesteachers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[classesteachers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'classes'
CREATE TABLE [dbo].[classes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'teacher'
CREATE TABLE [dbo].[teacher] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'classesteachers'
CREATE TABLE [dbo].[classesteachers] (
    [classes_Id] int  NOT NULL,
    [teachers_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'classes'
ALTER TABLE [dbo].[classes]
ADD CONSTRAINT [PK_classes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'teacher'
ALTER TABLE [dbo].[teacher]
ADD CONSTRAINT [PK_teacher]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [classes_Id], [teachers_Id] in table 'classesteachers'
ALTER TABLE [dbo].[classesteachers]
ADD CONSTRAINT [PK_classesteachers]
    PRIMARY KEY CLUSTERED ([classes_Id], [teachers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [classes_Id] in table 'classesteachers'
ALTER TABLE [dbo].[classesteachers]
ADD CONSTRAINT [FK_classesteachers_classes]
    FOREIGN KEY ([classes_Id])
    REFERENCES [dbo].[classes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [teachers_Id] in table 'classesteachers'
ALTER TABLE [dbo].[classesteachers]
ADD CONSTRAINT [FK_classesteachers_teachers]
    FOREIGN KEY ([teachers_Id])
    REFERENCES [dbo].[teacher]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_classesteachers_teachers'
CREATE INDEX [IX_FK_classesteachers_teachers]
ON [dbo].[classesteachers]
    ([teachers_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------