CREATE TABLE [UserBookInformations] (
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[BookId] [uniqueidentifier] NOT NULL,
	[DomainUserId] [uniqueidentifier] NOT NULL,
	[OnWishlist] [bit] NOT NULL,
)

ALTER TABLE [dbo].[UserBookInformations] WITH CHECK ADD CONSTRAINT [FK_UserBookInformations_DomainUsers_Id] FOREIGN KEY([DomainUserId])
REFERENCES [dbo].[DomainUsers] ([Id])
GO

ALTER TABLE [dbo].[UserBookInformations] CHECK CONSTRAINT [FK_UserBookInformations_DomainUsers_Id]
GO

ALTER TABLE [dbo].[UserBookInformations] WITH CHECK ADD CONSTRAINT [FK_UserBookInformations_Books_Id] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO

ALTER TABLE [dbo].[UserBookInformations] CHECK CONSTRAINT [FK_UserBookInformations_Books_Id]
GO