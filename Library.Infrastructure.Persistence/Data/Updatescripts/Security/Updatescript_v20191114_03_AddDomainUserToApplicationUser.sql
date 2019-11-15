ALTER TABLE [AspNetUsers] ADD [DomainUserId] UNIQUEIDENTIFIER NULL
GO 

ALTER TABLE [dbo].[AspNetUsers] WITH CHECK ADD CONSTRAINT [FK_AspNetUsers_DomainUsers_DomainUserId] FOREIGN KEY([DomainUserId])
REFERENCES [dbo].[DomainUsers] ([Id])
GO

ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_DomainUsers_DomainUserId]
GO