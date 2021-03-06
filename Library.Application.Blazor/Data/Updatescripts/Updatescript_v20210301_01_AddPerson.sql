CREATE TABLE [dbo].[Person](
	[Id] [uniqueidentifier] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PersonToWishListBooks](
	[Person_id] [uniqueidentifier] NOT NULL,
	[Book_id] [uniqueidentifier] NOT NULL,	
 CONSTRAINT [PK_PersonToWishListBooks]PRIMARY KEY CLUSTERED 
(
	[Person_id] ASC,
	[Book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PersonToWishListBooks]  WITH CHECK ADD  CONSTRAINT [FK_PersonToWishListBooks_Person] FOREIGN KEY([Person_id])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[PersonToWishListBooks] CHECK CONSTRAINT [FK_PersonToWishListBooks_Person]
GO

ALTER TABLE [dbo].[PersonToWishListBooks]  WITH CHECK ADD  CONSTRAINT [FK_PersonToWishListBooks_Book] FOREIGN KEY([Book_id])
REFERENCES [dbo].[Book] ([Id])
GO

ALTER TABLE [dbo].[PersonToWishListBooks] CHECK CONSTRAINT [FK_PersonToWishListBooks_Book]
GO

CREATE TABLE [dbo].[PersonToOwnedBooks](
	[Person_id] [uniqueidentifier] NOT NULL,
	[Book_id] [uniqueidentifier] NOT NULL,	
 CONSTRAINT [PK_PersonToOwnedBooks]PRIMARY KEY CLUSTERED 
(
	[Person_id] ASC,
	[Book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PersonToOwnedBooks]  WITH CHECK ADD  CONSTRAINT [FK_PersonToOwnedBooks_Person] FOREIGN KEY([Person_id])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[PersonToOwnedBooks] CHECK CONSTRAINT [FK_PersonToOwnedBooks_Person]
GO

ALTER TABLE [dbo].[PersonToOwnedBooks]  WITH CHECK ADD  CONSTRAINT [FK_PersonToOwnedBooks_Book] FOREIGN KEY([Book_id])
REFERENCES [dbo].[Book] ([Id])
GO

ALTER TABLE [dbo].[PersonToOwnedBooks] CHECK CONSTRAINT [FK_PersonToOwnedBooks_Book]
GO