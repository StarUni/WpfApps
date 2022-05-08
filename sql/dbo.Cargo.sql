CREATE TABLE [dbo].[Cargo] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (50) NULL,
    [CreateTime] DATETIME     NOT NULL DEFAULT getdate(),
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

