CREATE TABLE [dbo].[NewsMessages](
	[Id] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY,
	[Title] [nvarchar](450) NOT NULL,
	[Message] [nvarchar](MAX) NOT NULL,
	[IsShown] [bit] NOT NULL
)