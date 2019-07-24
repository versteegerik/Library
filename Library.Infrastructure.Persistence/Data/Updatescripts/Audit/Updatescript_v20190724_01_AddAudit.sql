CREATE TABLE [dbo].[AuditLoginAttempt](
	[Id] [nvarchar](256) NOT NULL,
	[Username] [nvarchar](256) NULL,
	[UserId] [nvarchar](256) NULL,
	[ResultOfLogin] [nvarchar](256) NULL,
 CONSTRAINT [PK_AuditLoginAttemp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO