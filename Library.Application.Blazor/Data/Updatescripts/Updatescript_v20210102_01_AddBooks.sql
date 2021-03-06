CREATE TABLE [dbo].[Book](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](450) NOT NULL,
	[Author_id] [uniqueidentifier] NOT NULL,
	[Isbn] [nvarchar](10) NULL,
	[AlternativeTitle] [nvarchar](450) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([Author_id])
REFERENCES [dbo].[Author] ([Id])
GO

ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Author]
GO