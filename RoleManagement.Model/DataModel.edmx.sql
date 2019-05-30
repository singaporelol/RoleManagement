
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/04/2019 14:53:28
-- Generated from EDMX file: C:\Users\xueqian\source\RoleManagement\RoleManagement.Model\DataModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_RoleUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfo] DROP CONSTRAINT [FK_RoleUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionRole_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionRole] DROP CONSTRAINT [FK_ActionRole_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionRole] DROP CONSTRAINT [FK_ActionRole_Role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[Action]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Action];
GO
IF OBJECT_ID(N'[dbo].[ActionRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Action'
CREATE TABLE [dbo].[Action] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ParentId] int  NOT NULL,
    [ActionName] nvarchar(max)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [IsMenu] bit  NOT NULL
);
GO

-- Creating table 'ActionRole'
CREATE TABLE [dbo].[ActionRole] (
    [Action_Id] int  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [PK_Action]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Action_Id], [Role_Id] in table 'ActionRole'
ALTER TABLE [dbo].[ActionRole]
ADD CONSTRAINT [PK_ActionRole]
    PRIMARY KEY CLUSTERED ([Action_Id], [Role_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleId] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [FK_RoleUser]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleUser'
CREATE INDEX [IX_FK_RoleUser]
ON [dbo].[UserInfo]
    ([RoleId]);
GO

-- Creating foreign key on [Action_Id] in table 'ActionRole'
ALTER TABLE [dbo].[ActionRole]
ADD CONSTRAINT [FK_ActionRole_Action]
    FOREIGN KEY ([Action_Id])
    REFERENCES [dbo].[Action]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_Id] in table 'ActionRole'
ALTER TABLE [dbo].[ActionRole]
ADD CONSTRAINT [FK_ActionRole_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionRole_Role'
CREATE INDEX [IX_FK_ActionRole_Role]
ON [dbo].[ActionRole]
    ([Role_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------