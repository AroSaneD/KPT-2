
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/21/2015 02:17:47
-- Generated from EDMX file: C:\Users\Super\Desktop\KurwaPizdaToolsas-master\API\API\API\Models\Database.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ShoeBox];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProjectTeam_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectTeam] DROP CONSTRAINT [FK_ProjectTeam_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectTeam_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectTeam] DROP CONSTRAINT [FK_ProjectTeam_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserTeam];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectStatusProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectSet] DROP CONSTRAINT [FK_ProjectStatusProject];
GO
IF OBJECT_ID(N'[dbo].[FK_MilestoneProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MilestoneSet] DROP CONSTRAINT [FK_MilestoneProject];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectSet] DROP CONSTRAINT [FK_ClientProject];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskSet] DROP CONSTRAINT [FK_ProjectTask];
GO
IF OBJECT_ID(N'[dbo].[FK_MilestoneTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskSet] DROP CONSTRAINT [FK_MilestoneTask];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskStatusTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskSet] DROP CONSTRAINT [FK_TaskStatusTask];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskPriorityTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskSet] DROP CONSTRAINT [FK_TaskPriorityTask];
GO
IF OBJECT_ID(N'[dbo].[FK_CommitTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommitSet] DROP CONSTRAINT [FK_CommitTask];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskLogTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskLogSet] DROP CONSTRAINT [FK_TaskLogTask];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProjectSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectSet];
GO
IF OBJECT_ID(N'[dbo].[TeamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[RoleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectStatusSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectStatusSet];
GO
IF OBJECT_ID(N'[dbo].[MilestoneSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MilestoneSet];
GO
IF OBJECT_ID(N'[dbo].[ClientSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientSet];
GO
IF OBJECT_ID(N'[dbo].[TaskSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskSet];
GO
IF OBJECT_ID(N'[dbo].[TaskStatusSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskStatusSet];
GO
IF OBJECT_ID(N'[dbo].[TaskPrioritySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskPrioritySet];
GO
IF OBJECT_ID(N'[dbo].[CommitSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommitSet];
GO
IF OBJECT_ID(N'[dbo].[TaskLogSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskLogSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectTeam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectTeam];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProjectSet'
CREATE TABLE [dbo].[ProjectSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CreatedOn] nvarchar(max)  NOT NULL,
    [Client] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [ProjectManager] nvarchar(max)  NOT NULL,
    [ProjectStatus_Id] int  NOT NULL,
    [Client1_Id] int  NOT NULL
);
GO

-- Creating table 'TeamSet'
CREATE TABLE [dbo].[TeamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [TeamLead] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Passkey] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [LastActivity] datetime  NOT NULL,
    [Roles] nvarchar(max)  NOT NULL,
    [Task_Id] int  NULL,
    [Team_Id] int  NULL
);
GO

-- Creating table 'RoleSet'
CREATE TABLE [dbo].[RoleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FriendlyName] nvarchar(max)  NOT NULL,
    [SysRole] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProjectStatusSet'
CREATE TABLE [dbo].[ProjectStatusSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MilestoneSet'
CREATE TABLE [dbo].[MilestoneSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Project_Id] int  NOT NULL
);
GO

-- Creating table 'ClientSet'
CREATE TABLE [dbo].[ClientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TaskSet'
CREATE TABLE [dbo].[TaskSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Slug] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [CreatedOn] nvarchar(max)  NOT NULL,
    [Estimate] nvarchar(max)  NOT NULL,
    [EndDate] nvarchar(max)  NOT NULL,
    [Project_Id] int  NOT NULL,
    [Milestone_Id] int  NOT NULL,
    [TaskStatus_Id] int  NOT NULL,
    [TaskPriority_Id] int  NOT NULL
);
GO

-- Creating table 'TaskStatusSet'
CREATE TABLE [dbo].[TaskStatusSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TaskPrioritySet'
CREATE TABLE [dbo].[TaskPrioritySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Order] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CommitSet'
CREATE TABLE [dbo].[CommitSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CommitHash] nvarchar(max)  NOT NULL,
    [CommitDateTime] datetime  NOT NULL,
    [Task_Id] int  NOT NULL
);
GO

-- Creating table 'TaskLogSet'
CREATE TABLE [dbo].[TaskLogSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Event] nvarchar(max)  NOT NULL,
    [EntryDate] datetime  NOT NULL,
    [Task_Id] int  NOT NULL
);
GO

-- Creating table 'ProjectTeam'
CREATE TABLE [dbo].[ProjectTeam] (
    [Project_Id] int  NOT NULL,
    [Team_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [PK_ProjectSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeamSet'
ALTER TABLE [dbo].[TeamSet]
ADD CONSTRAINT [PK_TeamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoleSet'
ALTER TABLE [dbo].[RoleSet]
ADD CONSTRAINT [PK_RoleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectStatusSet'
ALTER TABLE [dbo].[ProjectStatusSet]
ADD CONSTRAINT [PK_ProjectStatusSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MilestoneSet'
ALTER TABLE [dbo].[MilestoneSet]
ADD CONSTRAINT [PK_MilestoneSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [PK_ClientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaskSet'
ALTER TABLE [dbo].[TaskSet]
ADD CONSTRAINT [PK_TaskSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaskStatusSet'
ALTER TABLE [dbo].[TaskStatusSet]
ADD CONSTRAINT [PK_TaskStatusSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaskPrioritySet'
ALTER TABLE [dbo].[TaskPrioritySet]
ADD CONSTRAINT [PK_TaskPrioritySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommitSet'
ALTER TABLE [dbo].[CommitSet]
ADD CONSTRAINT [PK_CommitSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaskLogSet'
ALTER TABLE [dbo].[TaskLogSet]
ADD CONSTRAINT [PK_TaskLogSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Project_Id], [Team_Id] in table 'ProjectTeam'
ALTER TABLE [dbo].[ProjectTeam]
ADD CONSTRAINT [PK_ProjectTeam]
    PRIMARY KEY CLUSTERED ([Project_Id], [Team_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Project_Id] in table 'ProjectTeam'
ALTER TABLE [dbo].[ProjectTeam]
ADD CONSTRAINT [FK_ProjectTeam_Project]
    FOREIGN KEY ([Project_Id])
    REFERENCES [dbo].[ProjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Team_Id] in table 'ProjectTeam'
ALTER TABLE [dbo].[ProjectTeam]
ADD CONSTRAINT [FK_ProjectTeam_Team]
    FOREIGN KEY ([Team_Id])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTeam_Team'
CREATE INDEX [IX_FK_ProjectTeam_Team]
ON [dbo].[ProjectTeam]
    ([Team_Id]);
GO

-- Creating foreign key on [Team_Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_UserTeam]
    FOREIGN KEY ([Team_Id])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTeam'
CREATE INDEX [IX_FK_UserTeam]
ON [dbo].[UserSet]
    ([Team_Id]);
GO

-- Creating foreign key on [ProjectStatus_Id] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_ProjectStatusProject]
    FOREIGN KEY ([ProjectStatus_Id])
    REFERENCES [dbo].[ProjectStatusSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectStatusProject'
CREATE INDEX [IX_FK_ProjectStatusProject]
ON [dbo].[ProjectSet]
    ([ProjectStatus_Id]);
GO

-- Creating foreign key on [Project_Id] in table 'MilestoneSet'
ALTER TABLE [dbo].[MilestoneSet]
ADD CONSTRAINT [FK_MilestoneProject]
    FOREIGN KEY ([Project_Id])
    REFERENCES [dbo].[ProjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MilestoneProject'
CREATE INDEX [IX_FK_MilestoneProject]
ON [dbo].[MilestoneSet]
    ([Project_Id]);
GO

-- Creating foreign key on [Client1_Id] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_ClientProject]
    FOREIGN KEY ([Client1_Id])
    REFERENCES [dbo].[ClientSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientProject'
CREATE INDEX [IX_FK_ClientProject]
ON [dbo].[ProjectSet]
    ([Client1_Id]);
GO

-- Creating foreign key on [Project_Id] in table 'TaskSet'
ALTER TABLE [dbo].[TaskSet]
ADD CONSTRAINT [FK_ProjectTask]
    FOREIGN KEY ([Project_Id])
    REFERENCES [dbo].[ProjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTask'
CREATE INDEX [IX_FK_ProjectTask]
ON [dbo].[TaskSet]
    ([Project_Id]);
GO

-- Creating foreign key on [Milestone_Id] in table 'TaskSet'
ALTER TABLE [dbo].[TaskSet]
ADD CONSTRAINT [FK_MilestoneTask]
    FOREIGN KEY ([Milestone_Id])
    REFERENCES [dbo].[MilestoneSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MilestoneTask'
CREATE INDEX [IX_FK_MilestoneTask]
ON [dbo].[TaskSet]
    ([Milestone_Id]);
GO

-- Creating foreign key on [TaskStatus_Id] in table 'TaskSet'
ALTER TABLE [dbo].[TaskSet]
ADD CONSTRAINT [FK_TaskStatusTask]
    FOREIGN KEY ([TaskStatus_Id])
    REFERENCES [dbo].[TaskStatusSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskStatusTask'
CREATE INDEX [IX_FK_TaskStatusTask]
ON [dbo].[TaskSet]
    ([TaskStatus_Id]);
GO

-- Creating foreign key on [TaskPriority_Id] in table 'TaskSet'
ALTER TABLE [dbo].[TaskSet]
ADD CONSTRAINT [FK_TaskPriorityTask]
    FOREIGN KEY ([TaskPriority_Id])
    REFERENCES [dbo].[TaskPrioritySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskPriorityTask'
CREATE INDEX [IX_FK_TaskPriorityTask]
ON [dbo].[TaskSet]
    ([TaskPriority_Id]);
GO

-- Creating foreign key on [Task_Id] in table 'CommitSet'
ALTER TABLE [dbo].[CommitSet]
ADD CONSTRAINT [FK_CommitTask]
    FOREIGN KEY ([Task_Id])
    REFERENCES [dbo].[TaskSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CommitTask'
CREATE INDEX [IX_FK_CommitTask]
ON [dbo].[CommitSet]
    ([Task_Id]);
GO

-- Creating foreign key on [Task_Id] in table 'TaskLogSet'
ALTER TABLE [dbo].[TaskLogSet]
ADD CONSTRAINT [FK_TaskLogTask]
    FOREIGN KEY ([Task_Id])
    REFERENCES [dbo].[TaskSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskLogTask'
CREATE INDEX [IX_FK_TaskLogTask]
ON [dbo].[TaskLogSet]
    ([Task_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------