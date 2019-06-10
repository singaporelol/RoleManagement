
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/10/2019 14:15:20
-- Generated from EDMX file: C:\Users\xueqian\Documents\Work\RoleRelavant\RoleManagement\RoleManagement.Model\DataModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_ActionRole_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionRole] DROP CONSTRAINT [FK_ActionRole_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionRole] DROP CONSTRAINT [FK_ActionRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionActionModule_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionActionModule] DROP CONSTRAINT [FK_ActionActionModule_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionActionModule_ActionModule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionActionModule] DROP CONSTRAINT [FK_ActionActionModule_ActionModule];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionMenu_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionMenu] DROP CONSTRAINT [FK_ActionMenu_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionMenu_Menu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionMenu] DROP CONSTRAINT [FK_ActionMenu_Menu];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRole_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRole] DROP CONSTRAINT [FK_UserInfoRole_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRole] DROP CONSTRAINT [FK_UserInfoRole_Role];
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
IF OBJECT_ID(N'[dbo].[ActionModule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionModule];
GO
IF OBJECT_ID(N'[dbo].[Menu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menu];
GO
IF OBJECT_ID(N'[dbo].[ActionRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionRole];
GO
IF OBJECT_ID(N'[dbo].[ActionActionModule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionActionModule];
GO
IF OBJECT_ID(N'[dbo].[ActionMenu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionMenu];
GO
IF OBJECT_ID(N'[dbo].[UserInfoRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoRole];
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
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Action'
CREATE TABLE [dbo].[Action] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActionType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ActionModule'
CREATE TABLE [dbo].[ActionModule] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ParentId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Menu'
CREATE TABLE [dbo].[Menu] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ParentId] int  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ActionRole'
CREATE TABLE [dbo].[ActionRole] (
    [Action_Id] int  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'ActionActionModule'
CREATE TABLE [dbo].[ActionActionModule] (
    [Action_Id] int  NOT NULL,
    [ActionModule_Id] int  NOT NULL
);
GO

-- Creating table 'ActionMenu'
CREATE TABLE [dbo].[ActionMenu] (
    [Action_Id] int  NOT NULL,
    [Menu_Id] int  NOT NULL
);
GO

-- Creating table 'UserInfoRole'
CREATE TABLE [dbo].[UserInfoRole] (
    [UserInfo_Id] int  NOT NULL,
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

-- Creating primary key on [Id] in table 'ActionModule'
ALTER TABLE [dbo].[ActionModule]
ADD CONSTRAINT [PK_ActionModule]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Menu'
ALTER TABLE [dbo].[Menu]
ADD CONSTRAINT [PK_Menu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Action_Id], [Role_Id] in table 'ActionRole'
ALTER TABLE [dbo].[ActionRole]
ADD CONSTRAINT [PK_ActionRole]
    PRIMARY KEY CLUSTERED ([Action_Id], [Role_Id] ASC);
GO

-- Creating primary key on [Action_Id], [ActionModule_Id] in table 'ActionActionModule'
ALTER TABLE [dbo].[ActionActionModule]
ADD CONSTRAINT [PK_ActionActionModule]
    PRIMARY KEY CLUSTERED ([Action_Id], [ActionModule_Id] ASC);
GO

-- Creating primary key on [Action_Id], [Menu_Id] in table 'ActionMenu'
ALTER TABLE [dbo].[ActionMenu]
ADD CONSTRAINT [PK_ActionMenu]
    PRIMARY KEY CLUSTERED ([Action_Id], [Menu_Id] ASC);
GO

-- Creating primary key on [UserInfo_Id], [Role_Id] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [PK_UserInfoRole]
    PRIMARY KEY CLUSTERED ([UserInfo_Id], [Role_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [Action_Id] in table 'ActionActionModule'
ALTER TABLE [dbo].[ActionActionModule]
ADD CONSTRAINT [FK_ActionActionModule_Action]
    FOREIGN KEY ([Action_Id])
    REFERENCES [dbo].[Action]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionModule_Id] in table 'ActionActionModule'
ALTER TABLE [dbo].[ActionActionModule]
ADD CONSTRAINT [FK_ActionActionModule_ActionModule]
    FOREIGN KEY ([ActionModule_Id])
    REFERENCES [dbo].[ActionModule]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionActionModule_ActionModule'
CREATE INDEX [IX_FK_ActionActionModule_ActionModule]
ON [dbo].[ActionActionModule]
    ([ActionModule_Id]);
GO

-- Creating foreign key on [Action_Id] in table 'ActionMenu'
ALTER TABLE [dbo].[ActionMenu]
ADD CONSTRAINT [FK_ActionMenu_Action]
    FOREIGN KEY ([Action_Id])
    REFERENCES [dbo].[Action]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Menu_Id] in table 'ActionMenu'
ALTER TABLE [dbo].[ActionMenu]
ADD CONSTRAINT [FK_ActionMenu_Menu]
    FOREIGN KEY ([Menu_Id])
    REFERENCES [dbo].[Menu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionMenu_Menu'
CREATE INDEX [IX_FK_ActionMenu_Menu]
ON [dbo].[ActionMenu]
    ([Menu_Id]);
GO

-- Creating foreign key on [UserInfo_Id] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [FK_UserInfoRole_UserInfo]
    FOREIGN KEY ([UserInfo_Id])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_Id] in table 'UserInfoRole'
ALTER TABLE [dbo].[UserInfoRole]
ADD CONSTRAINT [FK_UserInfoRole_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRole_Role'
CREATE INDEX [IX_FK_UserInfoRole_Role]
ON [dbo].[UserInfoRole]
    ([Role_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------