
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2019 22:22:00
-- Generated from EDMX file: C:\Users\xueqian\source\RoleManagement\ConsoleApp1\TestModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_classstudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[students] DROP CONSTRAINT [FK_classstudent];
GO
IF OBJECT_ID(N'[dbo].[FK_teachersclasses_teachers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[teachersclasses] DROP CONSTRAINT [FK_teachersclasses_teachers];
GO
IF OBJECT_ID(N'[dbo].[FK_teachersclasses_classes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[teachersclasses] DROP CONSTRAINT [FK_teachersclasses_classes];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[classes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[classes];
GO
IF OBJECT_ID(N'[dbo].[students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[students];
GO
IF OBJECT_ID(N'[dbo].[teachers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[teachers];
GO
IF OBJECT_ID(N'[dbo].[teachersclasses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[teachersclasses];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'classes'
CREATE TABLE [dbo].[classes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [classname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'students'
CREATE TABLE [dbo].[students] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NULL,
    [age] int  NULL,
    [classId] int  NOT NULL
);
GO

-- Creating table 'teachers'
CREATE TABLE [dbo].[teachers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'teachersclasses'
CREATE TABLE [dbo].[teachersclasses] (
    [teachers_Id] int  NOT NULL,
    [classes_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'students'
ALTER TABLE [dbo].[students]
ADD CONSTRAINT [PK_students]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'teachers'
ALTER TABLE [dbo].[teachers]
ADD CONSTRAINT [PK_teachers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [teachers_Id], [classes_Id] in table 'teachersclasses'
ALTER TABLE [dbo].[teachersclasses]
ADD CONSTRAINT [PK_teachersclasses]
    PRIMARY KEY CLUSTERED ([teachers_Id], [classes_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [classId] in table 'students'
ALTER TABLE [dbo].[students]
ADD CONSTRAINT [FK_classstudent]
    FOREIGN KEY ([classId])
    REFERENCES [dbo].[classes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_classstudent'
CREATE INDEX [IX_FK_classstudent]
ON [dbo].[students]
    ([classId]);
GO

-- Creating foreign key on [teachers_Id] in table 'teachersclasses'
ALTER TABLE [dbo].[teachersclasses]
ADD CONSTRAINT [FK_teachersclasses_teachers]
    FOREIGN KEY ([teachers_Id])
    REFERENCES [dbo].[teachers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [classes_Id] in table 'teachersclasses'
ALTER TABLE [dbo].[teachersclasses]
ADD CONSTRAINT [FK_teachersclasses_classes]
    FOREIGN KEY ([classes_Id])
    REFERENCES [dbo].[classes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_teachersclasses_classes'
CREATE INDEX [IX_FK_teachersclasses_classes]
ON [dbo].[teachersclasses]
    ([classes_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------