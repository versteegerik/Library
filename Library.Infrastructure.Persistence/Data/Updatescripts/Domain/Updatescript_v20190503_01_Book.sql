CREATE TABLE [dbo].[Books](
	[Id] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY,
	[Title] [nvarchar](450) NOT NULL,
	[Author] [nvarchar](450) NOT NULL
)
GO

ALTER TABLE [dbo].[Books] WITH CHECK ADD CONSTRAINT [FK_Books_AspNetUsers_UserId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_AspNetUsers_UserId]
GO