CREATE TABLE [dbo].[Author](
	[Id] [uniqueidentifier] NOT NULL,
	[Initials] [nvarchar](450) NULL,
	[FirstNames] [nvarchar](450) NULL,
	[Prefix] [nvarchar](450) NULL,
	[LastName] [nvarchar](450) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
