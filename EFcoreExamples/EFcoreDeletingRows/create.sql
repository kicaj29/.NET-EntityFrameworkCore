USE [testdb]
GO

/****** Object:  Table [dbo].[Child]    Script Date: 12/14/2017 19:56:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Root](
	[Id] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Root] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Parent](
	[Id] [varchar](50) NOT NULL,
	[RootId] [varchar](50) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[RootId] ASC

)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Parent]  WITH NOCHECK ADD  CONSTRAINT [FK_Parent_Root] FOREIGN KEY([RootId])
REFERENCES [dbo].[Root] ([Id])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[Parent] NOCHECK CONSTRAINT [FK_Parent_Root]
GO

GO

CREATE TABLE [dbo].[Child](
	[Id] [int] NOT NULL,
	[RootId] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ParentId] [varchar](50) NULL,
 CONSTRAINT [PK_Child] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[RootId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


GO

ALTER TABLE [dbo].[Child]  WITH NOCHECK ADD  CONSTRAINT [FK_Child_Parent] FOREIGN KEY([ParentId], [RootId])
REFERENCES [dbo].[Parent] ([Id], [RootId])
NOT FOR REPLICATION
GO

ALTER TABLE [dbo].[Child] NOCHECK CONSTRAINT [FK_Child_Parent]
GO

SET ANSI_PADDING OFF
GO


select * from dbo.Root
select * from dbo.Parent
select * from dbo.Child

delete from dbo.Child
delete from dbo.Parent
delete from dbo.Root