
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/24/2015 22:35:55
-- Generated from EDMX file: C:\Users\Ghost\Documents\Projects\GitHub\Hyk\Hyk_WebApi\Hyk_WebApi\Models\Enityt_Framework_File\Hyk_Database_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\Users\Ghost\Documents\Projects\GitHub\Hyk\Hyk_WebApi\Hyk_WebApi\App_Data\Hyk_Database.mdf];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CARDUSER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CARDs] DROP CONSTRAINT [FK_CARDUSER];
GO
IF OBJECT_ID(N'[dbo].[FK_DRIVERCAR]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CARs] DROP CONSTRAINT [FK_DRIVERCAR];
GO
IF OBJECT_ID(N'[dbo].[FK_DRIVERTRIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TRIPs] DROP CONSTRAINT [FK_DRIVERTRIP];
GO
IF OBJECT_ID(N'[dbo].[FK_DRIVERUSER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DRIVERs] DROP CONSTRAINT [FK_DRIVERUSER];
GO
IF OBJECT_ID(N'[dbo].[FK_PASSENGERTRIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TRIPs] DROP CONSTRAINT [FK_PASSENGERTRIP];
GO
IF OBJECT_ID(N'[dbo].[FK_PASSENGERUSER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PASSENGERs] DROP CONSTRAINT [FK_PASSENGERUSER];
GO
IF OBJECT_ID(N'[dbo].[FK_TRIPLOCATION]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LOCATIONs] DROP CONSTRAINT [FK_TRIPLOCATION];
GO
IF OBJECT_ID(N'[dbo].[FK_TRIPTRIP_MATCH]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TRIP_MATCH] DROP CONSTRAINT [FK_TRIPTRIP_MATCH];
GO
IF OBJECT_ID(N'[dbo].[FK_TRIPTRIP_MATCH1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TRIP_MATCH] DROP CONSTRAINT [FK_TRIPTRIP_MATCH1];
GO
IF OBJECT_ID(N'[dbo].[FK_USERPREFERENCE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[USERs] DROP CONSTRAINT [FK_USERPREFERENCE];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CARDs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CARDs];
GO
IF OBJECT_ID(N'[dbo].[CARs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CARs];
GO
IF OBJECT_ID(N'[dbo].[DRIVERs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DRIVERs];
GO
IF OBJECT_ID(N'[dbo].[LOCATIONs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LOCATIONs];
GO
IF OBJECT_ID(N'[dbo].[PASSENGERs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PASSENGERs];
GO
IF OBJECT_ID(N'[dbo].[PREFERENCEs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PREFERENCEs];
GO
IF OBJECT_ID(N'[dbo].[RATINGs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RATINGs];
GO
IF OBJECT_ID(N'[dbo].[TRIP_MATCH]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TRIP_MATCH];
GO
IF OBJECT_ID(N'[dbo].[TRIPs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TRIPs];
GO
IF OBJECT_ID(N'[dbo].[USERs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[USERs];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'USERs'
CREATE TABLE [dbo].[USERs] (
    [ID_] int IDENTITY(1,1) NOT NULL,
    [FIRSTNAME_] nvarchar(max)  NOT NULL,
    [LASTNAME_] nvarchar(max)  NOT NULL,
    [EMAIL_] nvarchar(max)  NOT NULL,
    [CONTACT_NUMBER_] nvarchar(max)  NOT NULL,
    [PICTURE_] nvarchar(max)  NOT NULL,
    [AVERAGE_RATING_] int  NOT NULL,
    [DATE_REGISTERED_] datetime  NOT NULL,
    [PREFERENCE_ID_] int  NOT NULL
);
GO

-- Creating table 'CARs'
CREATE TABLE [dbo].[CARs] (
    [NUMBER_PLATE_] nvarchar(max)  NOT NULL,
    [MAKE_] nvarchar(max)  NOT NULL,
    [MODEL_] nvarchar(max)  NOT NULL,
    [COLOUR_] nvarchar(max)  NOT NULL,
    [PICTURE_] nvarchar(max)  NOT NULL,
    [MAX_SEATS_] int  NOT NULL,
    [PROVINCIAL_MARK_] nvarchar(max)  NOT NULL,
    [PROVINCE_] nvarchar(max)  NOT NULL,
    [DRIVER_ID_] int  NOT NULL,
    [DATE_ADDED_] datetime  NOT NULL,
    [ID_] int  NOT NULL
);
GO

-- Creating table 'CARDs'
CREATE TABLE [dbo].[CARDs] (
    [ID_] int IDENTITY(1,1) NOT NULL,
    [DATE_ADDED_] datetime  NOT NULL,
    [USER_ID_] int  NOT NULL
);
GO

-- Creating table 'RATINGs'
CREATE TABLE [dbo].[RATINGs] (
    [ID_] int IDENTITY(1,1) NOT NULL,
    [DATE_] datetime  NOT NULL,
    [STARS_] int  NOT NULL,
    [RATER_ID_] int  NOT NULL,
    [RATEE_ID_] int  NOT NULL,
    [COMMENT_] nvarchar(max)  NULL
);
GO

-- Creating table 'LOCATIONs'
CREATE TABLE [dbo].[LOCATIONs] (
    [ID_] int IDENTITY(1,1) NOT NULL,
    [PROVINCE_] nvarchar(max)  NOT NULL,
    [CITY_] nvarchar(max)  NOT NULL,
    [DISTRICT_] nvarchar(max)  NOT NULL,
    [NEIGHBOURHOOD_] nvarchar(max)  NOT NULL,
    [TYPE_] nvarchar(max)  NOT NULL,
    [TRIPID_] int  NOT NULL
);
GO

-- Creating table 'PASSENGERs'
CREATE TABLE [dbo].[PASSENGERs] (
    [ID_] int IDENTITY(1,1) NOT NULL,
    [USER_ID_] int  NOT NULL
);
GO

-- Creating table 'DRIVERs'
CREATE TABLE [dbo].[DRIVERs] (
    [ID_] int IDENTITY(1,1) NOT NULL,
    [USER_ID_] int  NOT NULL
);
GO

-- Creating table 'TRIPs'
CREATE TABLE [dbo].[TRIPs] (
    [ID_] int IDENTITY(1,1) NOT NULL,
    [DATE_CREATED_] datetime  NOT NULL,
    [DATE_SCHEDULED_] datetime  NOT NULL,
    [PASSENGER_ID_] int  NULL,
    [DRIVER_ID_] int  NULL,
    [TICKET_NUMBER_] nvarchar(max)  NOT NULL,
    [SEATS_] int  NOT NULL
);
GO

-- Creating table 'PREFERENCEs'
CREATE TABLE [dbo].[PREFERENCEs] (
    [ID_] int IDENTITY(1,1) NOT NULL,
    [SMOKING_] bit  NOT NULL,
    [FOOD_] bit  NOT NULL,
    [PETS_] bit  NOT NULL
);
GO

-- Creating table 'TRIP_MATCH'
CREATE TABLE [dbo].[TRIP_MATCH] (
    [ID_] int IDENTITY(1,1) NOT NULL,
    [PASSANGERS_TRIP_ID_] int  NOT NULL,
    [DRIVERS_TRIP_ID_] int  NOT NULL,
    [ACCEPTED_] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID_] in table 'USERs'
ALTER TABLE [dbo].[USERs]
ADD CONSTRAINT [PK_USERs]
    PRIMARY KEY CLUSTERED ([ID_] ASC);
GO

-- Creating primary key on [ID_] in table 'CARs'
ALTER TABLE [dbo].[CARs]
ADD CONSTRAINT [PK_CARs]
    PRIMARY KEY CLUSTERED ([ID_] ASC);
GO

-- Creating primary key on [ID_] in table 'CARDs'
ALTER TABLE [dbo].[CARDs]
ADD CONSTRAINT [PK_CARDs]
    PRIMARY KEY CLUSTERED ([ID_] ASC);
GO

-- Creating primary key on [ID_] in table 'RATINGs'
ALTER TABLE [dbo].[RATINGs]
ADD CONSTRAINT [PK_RATINGs]
    PRIMARY KEY CLUSTERED ([ID_] ASC);
GO

-- Creating primary key on [ID_] in table 'LOCATIONs'
ALTER TABLE [dbo].[LOCATIONs]
ADD CONSTRAINT [PK_LOCATIONs]
    PRIMARY KEY CLUSTERED ([ID_] ASC);
GO

-- Creating primary key on [ID_] in table 'PASSENGERs'
ALTER TABLE [dbo].[PASSENGERs]
ADD CONSTRAINT [PK_PASSENGERs]
    PRIMARY KEY CLUSTERED ([ID_] ASC);
GO

-- Creating primary key on [ID_] in table 'DRIVERs'
ALTER TABLE [dbo].[DRIVERs]
ADD CONSTRAINT [PK_DRIVERs]
    PRIMARY KEY CLUSTERED ([ID_] ASC);
GO

-- Creating primary key on [ID_] in table 'TRIPs'
ALTER TABLE [dbo].[TRIPs]
ADD CONSTRAINT [PK_TRIPs]
    PRIMARY KEY CLUSTERED ([ID_] ASC);
GO

-- Creating primary key on [ID_] in table 'PREFERENCEs'
ALTER TABLE [dbo].[PREFERENCEs]
ADD CONSTRAINT [PK_PREFERENCEs]
    PRIMARY KEY CLUSTERED ([ID_] ASC);
GO

-- Creating primary key on [ID_] in table 'TRIP_MATCH'
ALTER TABLE [dbo].[TRIP_MATCH]
ADD CONSTRAINT [PK_TRIP_MATCH]
    PRIMARY KEY CLUSTERED ([ID_] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [USER_ID_] in table 'CARDs'
ALTER TABLE [dbo].[CARDs]
ADD CONSTRAINT [FK_CARDUSER]
    FOREIGN KEY ([USER_ID_])
    REFERENCES [dbo].[USERs]
        ([ID_])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CARDUSER'
CREATE INDEX [IX_FK_CARDUSER]
ON [dbo].[CARDs]
    ([USER_ID_]);
GO

-- Creating foreign key on [USER_ID_] in table 'PASSENGERs'
ALTER TABLE [dbo].[PASSENGERs]
ADD CONSTRAINT [FK_PASSENGERUSER]
    FOREIGN KEY ([USER_ID_])
    REFERENCES [dbo].[USERs]
        ([ID_])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PASSENGERUSER'
CREATE INDEX [IX_FK_PASSENGERUSER]
ON [dbo].[PASSENGERs]
    ([USER_ID_]);
GO

-- Creating foreign key on [DRIVER_ID_] in table 'CARs'
ALTER TABLE [dbo].[CARs]
ADD CONSTRAINT [FK_DRIVERCAR]
    FOREIGN KEY ([DRIVER_ID_])
    REFERENCES [dbo].[DRIVERs]
        ([ID_])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DRIVERCAR'
CREATE INDEX [IX_FK_DRIVERCAR]
ON [dbo].[CARs]
    ([DRIVER_ID_]);
GO

-- Creating foreign key on [TRIPID_] in table 'LOCATIONs'
ALTER TABLE [dbo].[LOCATIONs]
ADD CONSTRAINT [FK_TRIPLOCATION]
    FOREIGN KEY ([TRIPID_])
    REFERENCES [dbo].[TRIPs]
        ([ID_])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TRIPLOCATION'
CREATE INDEX [IX_FK_TRIPLOCATION]
ON [dbo].[LOCATIONs]
    ([TRIPID_]);
GO

-- Creating foreign key on [PASSENGER_ID_] in table 'TRIPs'
ALTER TABLE [dbo].[TRIPs]
ADD CONSTRAINT [FK_PASSENGERTRIP]
    FOREIGN KEY ([PASSENGER_ID_])
    REFERENCES [dbo].[PASSENGERs]
        ([ID_])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PASSENGERTRIP'
CREATE INDEX [IX_FK_PASSENGERTRIP]
ON [dbo].[TRIPs]
    ([PASSENGER_ID_]);
GO

-- Creating foreign key on [DRIVER_ID_] in table 'TRIPs'
ALTER TABLE [dbo].[TRIPs]
ADD CONSTRAINT [FK_DRIVERTRIP]
    FOREIGN KEY ([DRIVER_ID_])
    REFERENCES [dbo].[DRIVERs]
        ([ID_])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DRIVERTRIP'
CREATE INDEX [IX_FK_DRIVERTRIP]
ON [dbo].[TRIPs]
    ([DRIVER_ID_]);
GO

-- Creating foreign key on [USER_ID_] in table 'DRIVERs'
ALTER TABLE [dbo].[DRIVERs]
ADD CONSTRAINT [FK_DRIVERUSER]
    FOREIGN KEY ([USER_ID_])
    REFERENCES [dbo].[USERs]
        ([ID_])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DRIVERUSER'
CREATE INDEX [IX_FK_DRIVERUSER]
ON [dbo].[DRIVERs]
    ([USER_ID_]);
GO

-- Creating foreign key on [PASSANGERS_TRIP_ID_] in table 'TRIP_MATCH'
ALTER TABLE [dbo].[TRIP_MATCH]
ADD CONSTRAINT [FK_TRIPTRIP_MATCH]
    FOREIGN KEY ([PASSANGERS_TRIP_ID_])
    REFERENCES [dbo].[TRIPs]
        ([ID_])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TRIPTRIP_MATCH'
CREATE INDEX [IX_FK_TRIPTRIP_MATCH]
ON [dbo].[TRIP_MATCH]
    ([PASSANGERS_TRIP_ID_]);
GO

-- Creating foreign key on [DRIVERS_TRIP_ID_] in table 'TRIP_MATCH'
ALTER TABLE [dbo].[TRIP_MATCH]
ADD CONSTRAINT [FK_TRIPTRIP_MATCH1]
    FOREIGN KEY ([DRIVERS_TRIP_ID_])
    REFERENCES [dbo].[TRIPs]
        ([ID_])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TRIPTRIP_MATCH1'
CREATE INDEX [IX_FK_TRIPTRIP_MATCH1]
ON [dbo].[TRIP_MATCH]
    ([DRIVERS_TRIP_ID_]);
GO

-- Creating foreign key on [PREFERENCE_ID_] in table 'USERs'
ALTER TABLE [dbo].[USERs]
ADD CONSTRAINT [FK_USERPREFERENCE]
    FOREIGN KEY ([PREFERENCE_ID_])
    REFERENCES [dbo].[PREFERENCEs]
        ([ID_])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_USERPREFERENCE'
CREATE INDEX [IX_FK_USERPREFERENCE]
ON [dbo].[USERs]
    ([PREFERENCE_ID_]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------