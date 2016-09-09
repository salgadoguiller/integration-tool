-- -----------------------------------------------------
-- DATABASE IntegrationTool
-- -----------------------------------------------------
-- DROP DATABASE IntegrationTool;

-- -----------------------------------------------------
-- DATABASE IntegrationTool
-- -----------------------------------------------------
-- CREATE DATABASE IntegrationTool;
-- USE IntegrationTool;

-- -----------------------------------------------------
-- Table Engines
-- -----------------------------------------------------
CREATE TABLE Engines (
  EngineId INT NOT NULL IDENTITY(1,1),
  Name VARCHAR(45) NOT NULL,
  CONSTRAINT PK_Engines
    PRIMARY KEY (EngineId));


-- -----------------------------------------------------
-- Table DatabaseParameters
-- -----------------------------------------------------
CREATE TABLE DatabaseParameters (
  DatabaseParametersId INT NOT NULL IDENTITY(1,1),
  Ip VARCHAR(15) NOT NULL,
  Port VARCHAR(15) NOT NULL,
  Instance VARCHAR(45),
  Name VARCHAR(45) NOT NULL,
  Username VARCHAR(45) NOT NULL,
  Password VARCHAR(45) NOT NULL,
  EngineId INT NOT NULL,
  CONSTRAINT PK_DatabaseParameter
    PRIMARY KEY (DatabaseParametersId),
  CONSTRAINT FK_DatabaseParametersEngines_EngineId
    FOREIGN KEY (EngineId)
    REFERENCES Engines (EngineId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table QueriesType
-- -----------------------------------------------------
CREATE TABLE QueriesType (
  QueryTypeId INT NOT NULL IDENTITY(1,1),
  Name VARCHAR(45) NOT NULL,
  CONSTRAINT PK_QueryType
    PRIMARY KEY (QueryTypeId));


-- -----------------------------------------------------
-- Table Queries
-- -----------------------------------------------------
CREATE TABLE Queries (
  QueryId INT NOT NULL IDENTITY(1,1),
  Query VARCHAR(MAX) NOT NULL,
  QueryTypeId INT NOT NULL,
  CONSTRAINT PK_Query
    PRIMARY KEY (QueryId),
  CONSTRAINT FK_QueriesQueriesType_QueryTypeId
    FOREIGN KEY (QueryTypeId)
    REFERENCES QueriesType (QueryTypeId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table Resource
-- -----------------------------------------------------
CREATE TABLE Resources (
  ResourceId INT NOT NULL IDENTITY(1,1),
  Name VARCHAR(45) NOT NULL,
  CONSTRAINT PK_Resource
    PRIMARY KEY (ResourceId));


-- -----------------------------------------------------
-- Table UsersType
-- -----------------------------------------------------
CREATE TABLE UsersType (
  UserTypeId INT NOT NULL IDENTITY(1,1),
  Type VARCHAR(45) NOT NULL,
  CONSTRAINT PK_UserType
    PRIMARY KEY (UserTypeId));


-- -----------------------------------------------------
-- Table Users
-- -----------------------------------------------------
CREATE TABLE Users (
  UserId INT NOT NULL IDENTITY(1,1),
  Name VARCHAR(45) NOT NULL,
  Username VARCHAR(45) NOT NULL,
  Password VARCHAR(45) NOT NULL,
  Email VARCHAR(45) NOT NULL,
  Domain VARCHAR(45) NULL,
  UserTypeId INT NOT NULL,
  CONSTRAINT PK_User
    PRIMARY KEY (UserId),
  CONSTRAINT FK_UsersUsersType_UserTypeId
    FOREIGN KEY (UserTypeId)
    REFERENCES UsersType (UserTypeId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table WebServices
-- -----------------------------------------------------
CREATE TABLE WebServices (
  WebServiceId INT NOT NULL IDENTITY(1,1),
  Endpoint VARCHAR(MAX) NOT NULL,
  Username VARCHAR(100) NOT NULL,
  Password VARCHAR(100) NOT NULL,
  CONSTRAINT PK_WebService
    PRIMARY KEY (WebServiceId));


-- -----------------------------------------------------
-- Table IntegrationsType
-- -----------------------------------------------------
CREATE TABLE IntegrationsType (
  IntegrationTypeId INT NOT NULL IDENTITY(1,1),
  Name VARCHAR(45) NOT NULL,
  CONSTRAINT PK_IntegrationType
    PRIMARY KEY (IntegrationTypeId));


-- -----------------------------------------------------
-- Table ServerSMTPParameters
-- -----------------------------------------------------
CREATE TABLE ServerSMTPParameters (
  ServerSMTPParametersId INT NOT NULL IDENTITY(1,1),
  NameServerSMTP VARCHAR(45) NOT NULL,
  Port VARCHAR(45) NOT NULL,
  UsernameSMTP VARCHAR(45) NOT NULL,
  PasswordSMTP VARCHAR(45) NOT NULL,
  CONSTRAINT PK_EmailParameter
    PRIMARY KEY (ServerSMTPParametersId));


-- -----------------------------------------------------
-- Table FlatFileParameters
-- -----------------------------------------------------
CREATE TABLE FlatFileParameters (
  FlatFileParametersId INT NOT NULL IDENTITY(1,1),
  Location VARCHAR(MAX) NOT NULL,
  CONSTRAINT PK_FlatFileParameters
    PRIMARY KEY (FlatFileParametersId));


-- -----------------------------------------------------
-- Table Integrations
-- -----------------------------------------------------
CREATE TABLE Integrations (
  IntegrationId INT NOT NULL IDENTITY(1,1),
  IntegrationDate DATETIME NOT NULL,
  UserId INT NOT NULL,
  WebServiceId INT NOT NULL,
  DatabaseParametersId INT NOT NULL,
  ServerSMTPParametersId INT NOT NULL,
  FlatFileParametersId INT NOT NULL,
  IntegrationTypeId INT NOT NULL,
  QueryId INT NOT NULL,
  CONSTRAINT PK_Integration
    PRIMARY KEY (IntegrationId),
  CONSTRAINT FK_IntegrationsUsers_UserId
    FOREIGN KEY (UserId)
    REFERENCES Users (UserId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK_IntegrationsWebServices_WebServiceId
    FOREIGN KEY (WebServiceId)
    REFERENCES WebServices (WebServiceId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK_IntegrationsDatabaseParameters_DatabaseParametersId
    FOREIGN KEY (DatabaseParametersId)
    REFERENCES DatabaseParameters (DatabaseParametersId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK_IntegrationsServerSMTPParameters_ServerSMTPParametersId
    FOREIGN KEY (ServerSMTPParametersId)
    REFERENCES ServerSMTPParameters (ServerSMTPParametersId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK_IntegrationsFlatFileParameters_FlatFileParametersId
    FOREIGN KEY (FlatFileParametersId)
    REFERENCES FlatFileParameters (FlatFileParametersId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK_IntegrationsIntegrationsType_IntegrationTypeId
    FOREIGN KEY (IntegrationTypeId)
    REFERENCES IntegrationsType (IntegrationTypeId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK_IntegrationsQueries_QueryId
    FOREIGN KEY (QueryId)
    REFERENCES Queries (QueryId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table ActiveDirectoryParameters
-- -----------------------------------------------------
CREATE TABLE ActiveDirectoryParameters (
  ActiveDirectoryId INT NOT NULL IDENTITY(1,1),
  ADPath VARCHAR(MAX) NOT NULL,
  ADDomain VARCHAR(45) NOT NULL,
  CONSTRAINT PK_ActiveDirectoryParameter
    PRIMARY KEY (ActiveDirectoryId));


-- -----------------------------------------------------
-- Table Permissions
-- -----------------------------------------------------
CREATE TABLE Permissions (
  PermissionId INT NOT NULL IDENTITY(1,1),
  UserId INT NOT NULL,
  ResourceId INT NOT NULL,
  CONSTRAINT PK_Permission
    PRIMARY KEY (PermissionId),
  CONSTRAINT FK_PermissionsUsers_UserId
    FOREIGN KEY (UserId)
    REFERENCES Users (UserId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK_PermissionsResources_ResourceId
    FOREIGN KEY (ResourceId)
    REFERENCES Resources (ResourceId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table IntegrationLogs
-- -----------------------------------------------------
CREATE TABLE IntegrationLogs (
  LogId INT NOT NULL IDENTITY(1,1),
  Description VARCHAR(MAX) NOT NULL,
  ErrorDate DATETIME NOT NULL,
  IntegrationId INT NOT NULL,
  CONSTRAINT PK_IntegrationLog
    PRIMARY KEY (LogId),
  CONSTRAINT FK_IntegrationLogsIntegrations_IntegrationId
    FOREIGN KEY (IntegrationId)
    REFERENCES Integrations (IntegrationId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table Headers
-- -----------------------------------------------------
CREATE TABLE Headers (
  HeaderId INT NOT NULL IDENTITY(1,1),
  Name VARCHAR(45) NOT NULL,
  QueryTypeId INT NOT NULL,
  CONSTRAINT PK_Header
    PRIMARY KEY (HeaderId),
  CONSTRAINT FK_HeadersQueriesType_QueryTypeId
    FOREIGN KEY (QueryTypeId)
    REFERENCES QueriesType (QueryTypeId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table Recurrences
-- -----------------------------------------------------
CREATE TABLE Recurrences (
  RecurrenceId INT NOT NULL IDENTITY(1,1),
  NameRecurrence VARCHAR(45) NOT NULL,
  CONSTRAINT PK_Recurrence
    PRIMARY KEY (RecurrenceId));


-- -----------------------------------------------------
-- Table Calendars
-- -----------------------------------------------------
CREATE TABLE Calendars (
  CalendarId INT NOT NULL IDENTITY(1,1),
  ExecutionStartDate DATETIME NOT NULL,
  NextExecutionDate DATETIME NULL,
  Emails VARCHAR(MAX),
  IntegrationId INT NOT NULL,
  RecurrenceId INT NOT NULL,
  CONSTRAINT PK_Calendar
    PRIMARY KEY (CalendarId),
  CONSTRAINT FK_CalendarsIntegrations_IntegrationId
    FOREIGN KEY (IntegrationId)
    REFERENCES Integrations (IntegrationId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK_CalendarsRecurrences_RecurrenceId
    FOREIGN KEY (RecurrenceId)
    REFERENCES Recurrences (RecurrenceId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table System_Logs
-- -----------------------------------------------------
CREATE TABLE SystemLogs (
  SystemLogId INT NOT NULL IDENTITY(1,1),
  Description VARCHAR(MAX) NOT NULL,
  ErrorDate DATETIME NOT NULL,
  IntegrationId INT NOT NULL,
  CONSTRAINT PK_SystemLog
    PRIMARY KEY (SystemLogId),
  CONSTRAINT FK_SystemLogsIntegrations_IntegrationId
    FOREIGN KEY (IntegrationId)
    REFERENCES Integrations (IntegrationId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
