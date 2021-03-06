CREATE TABLE [dbo].[BookGenre](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](450) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[BookGenreToBook](
	[Book_id] [uniqueidentifier] NOT NULL,
	[BookGenre_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_BookGenreToBook] PRIMARY KEY CLUSTERED 
(
	[Book_id] ASC,
	[BookGenre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [BookGenre] ([Id], [Code])
VALUES (NEWID(), 'Biografie')
      ,(NEWID(), 'Waargebeurd')
      ,(NEWID(), 'Fantasy')
      ,(NEWID(), 'Sciencefiction')
      ,(NEWID(), 'Misdaad')
      ,(NEWID(), 'Thriller')
      ,(NEWID(), 'Eten & Koken')
      ,(NEWID(), 'Historisch')
      ,(NEWID(), 'Futuristisch')
      ,(NEWID(), 'Roman')
      ,(NEWID(), 'Sport')
      ,(NEWID(), 'Studie')
      ,(NEWID(), 'Religie & Spiritualiteit')
      ,(NEWID(), 'Kunst & Cultuur')
      ,(NEWID(), 'Verhalenbundels')
      ,(NEWID(), 'Vrije tijd & Hobby')
      ,(NEWID(), 'Chick Flick')
      ,(NEWID(), 'Jeugd')
      ,(NEWID(), 'Drama')
      ,(NEWID(), 'Horror')
      ,(NEWID(), 'Sprookjes')

