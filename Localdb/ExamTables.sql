/*
 Navicat Premium Data Transfer

 Source Server         : LocalDB
 Source Server Type    : SQL Server
 Source Server Version : 15004153
 Source Host           : (localdb)\MSSQLLocalDB:1433
 Source Catalog        : CargoDB
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15004153
 File Encoding         : 65001

 Date: 21/05/2022 12:46:06
*/


-- ----------------------------
-- Table structure for DataDictionary
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[DataDictionary]') AND type IN ('U'))
	DROP TABLE [dbo].[DataDictionary]
GO

CREATE TABLE [dbo].[DataDictionary] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [DataType] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [ShortCode] nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FullCode] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DataName] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CreateTime] datetime DEFAULT getdate() NULL
)
GO

ALTER TABLE [dbo].[DataDictionary] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'DataDictionary',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数据类型',
'SCHEMA', N'dbo',
'TABLE', N'DataDictionary',
'COLUMN', N'DataType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'类型缩写',
'SCHEMA', N'dbo',
'TABLE', N'DataDictionary',
'COLUMN', N'ShortCode'
GO

EXEC sp_addextendedproperty
'MS_Description', N'类型全拼',
'SCHEMA', N'dbo',
'TABLE', N'DataDictionary',
'COLUMN', N'FullCode'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数据名称',
'SCHEMA', N'dbo',
'TABLE', N'DataDictionary',
'COLUMN', N'DataName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'插入时间',
'SCHEMA', N'dbo',
'TABLE', N'DataDictionary',
'COLUMN', N'CreateTime'
GO


-- ----------------------------
-- Table structure for Questions
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Questions]') AND type IN ('U'))
	DROP TABLE [dbo].[Questions]
GO

CREATE TABLE [dbo].[Questions] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [PaperName] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Content] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Score] int  NULL,
  [QuestionType] nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Subject] nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Options] nvarchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Answer] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CreateTime] datetime DEFAULT getdate() NULL
)
GO

ALTER TABLE [dbo].[Questions] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'Questions',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'试卷名称',
'SCHEMA', N'dbo',
'TABLE', N'Questions',
'COLUMN', N'PaperName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数据字典',
'SCHEMA', N'dbo',
'TABLE', N'Questions',
'COLUMN', N'QuestionType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'科目',
'SCHEMA', N'dbo',
'TABLE', N'Questions',
'COLUMN', N'Subject'
GO

EXEC sp_addextendedproperty
'MS_Description', N'may be not use',
'SCHEMA', N'dbo',
'TABLE', N'Questions',
'COLUMN', N'CreateTime'
GO


-- ----------------------------
-- Table structure for RoleInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[RoleInfo]
GO

CREATE TABLE [dbo].[RoleInfo] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [RoleInfo] nvarchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Privilege] nvarchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [RoleSC] nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[RoleInfo] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'管理员，操作员',
'SCHEMA', N'dbo',
'TABLE', N'RoleInfo',
'COLUMN', N'RoleInfo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作权限，注册账号，删除试题等',
'SCHEMA', N'dbo',
'TABLE', N'RoleInfo',
'COLUMN', N'Privilege'
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色简码',
'SCHEMA', N'dbo',
'TABLE', N'RoleInfo',
'COLUMN', N'RoleSC'
GO


-- ----------------------------
-- Table structure for UserInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[UserInfo]
GO

CREATE TABLE [dbo].[UserInfo] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [UserName] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [RoleId] int DEFAULT 2 NULL,
  [Password] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CreateTime] datetime DEFAULT getdate() NULL,
  [Salt] nvarchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[UserInfo] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'md5+salt',
'SCHEMA', N'dbo',
'TABLE', N'UserInfo',
'COLUMN', N'Password'
GO

EXEC sp_addextendedproperty
'MS_Description', N'getdate()',
'SCHEMA', N'dbo',
'TABLE', N'UserInfo',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'盐',
'SCHEMA', N'dbo',
'TABLE', N'UserInfo',
'COLUMN', N'Salt'
GO


-- ----------------------------
-- Table structure for WrongQuestions
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[WrongQuestions]') AND type IN ('U'))
	DROP TABLE [dbo].[WrongQuestions]
GO

CREATE TABLE [dbo].[WrongQuestions] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [QuestionId] int  NULL,
  [QuestionType] nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [QuestionScore] int  NULL,
  [GenerateTime] datetime DEFAULT getdate() NULL
)
GO

ALTER TABLE [dbo].[WrongQuestions] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'WrongQuestions',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'题目id',
'SCHEMA', N'dbo',
'TABLE', N'WrongQuestions',
'COLUMN', N'QuestionId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'题目类型',
'SCHEMA', N'dbo',
'TABLE', N'WrongQuestions',
'COLUMN', N'QuestionType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'题分值',
'SCHEMA', N'dbo',
'TABLE', N'WrongQuestions',
'COLUMN', N'QuestionScore'
GO

EXEC sp_addextendedproperty
'MS_Description', N'错误时间',
'SCHEMA', N'dbo',
'TABLE', N'WrongQuestions',
'COLUMN', N'GenerateTime'
GO


-- ----------------------------
-- Auto increment value for DataDictionary
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[DataDictionary]', RESEED, 2008)
GO


-- ----------------------------
-- Indexes structure for table DataDictionary
-- ----------------------------
CREATE UNIQUE NONCLUSTERED INDEX [index_sc]
ON [dbo].[DataDictionary] (
  [ShortCode] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table DataDictionary
-- ----------------------------
ALTER TABLE [dbo].[DataDictionary] ADD CONSTRAINT [_copy_1] PRIMARY KEY CLUSTERED ([ShortCode], [Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Questions
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Questions]', RESEED, 198)
GO


-- ----------------------------
-- Primary Key structure for table Questions
-- ----------------------------
ALTER TABLE [dbo].[Questions] ADD CONSTRAINT [_copy_3] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for RoleInfo
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[RoleInfo]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table RoleInfo
-- ----------------------------
ALTER TABLE [dbo].[RoleInfo] ADD CONSTRAINT [PK__RoleInfo__3214EC0721FDC73C] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for UserInfo
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[UserInfo]', RESEED, 1001)
GO


-- ----------------------------
-- Primary Key structure for table UserInfo
-- ----------------------------
ALTER TABLE [dbo].[UserInfo] ADD CONSTRAINT [_copy_2] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for WrongQuestions
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[WrongQuestions]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table WrongQuestions
-- ----------------------------
ALTER TABLE [dbo].[WrongQuestions] ADD CONSTRAINT [_copy_5] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table RoleInfo
-- ----------------------------
ALTER TABLE [dbo].[RoleInfo] ADD CONSTRAINT [fk_shortcode] FOREIGN KEY ([RoleSC]) REFERENCES [dbo].[DataDictionary] ([ShortCode]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table UserInfo
-- ----------------------------
ALTER TABLE [dbo].[UserInfo] ADD CONSTRAINT [fk_roleid] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[RoleInfo] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

