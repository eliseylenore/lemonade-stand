USE [lemonade_stand]
GO
/****** Object:  Table [dbo].[players]    Script Date: 3/7/2017 4:51:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[money] [decimal](9, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[players_scores]    Script Date: 3/7/2017 4:51:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players_scores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[player_id] [int] NULL,
	[score] [decimal](9, 2) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[players] ON 

INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (1, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (2, N'kaz', N'password', CAST(8.80 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (3, N'kaz', N'pass', CAST(16.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (4, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (5, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (6, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (7, N'Elise ', N'eliseylenore', CAST(14.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (8, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (9, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (10, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (11, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (12, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (13, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (14, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (15, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (16, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (17, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (18, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (19, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (20, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (21, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (22, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (23, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (24, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (25, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (26, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (27, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (28, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (29, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (30, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (31, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (32, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (33, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (34, N'Elise ', N'eliseylenore', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (35, N'Elise ', N'eliseylenore', CAST(10.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (36, N'coolgurl123', N'password123', CAST(10.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (37, N'eliseylenore', N'socweras', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (38, N'eliseylenore', N'soccer', CAST(14.50 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (39, N'eliseylenore', N'soccer', CAST(17.20 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (40, N'eliseylenore', N'soccer', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (41, N'eliseylenore', N'soccer', CAST(-26.90 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (42, N'blah ', N'lkajsdflkjasd', CAST(23.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (43, N'blah', N'lkasdfjlasd', CAST(21.00 AS Decimal(9, 2)))
INSERT [dbo].[players] ([id], [username], [password], [money]) VALUES (44, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)))
SET IDENTITY_INSERT [dbo].[players] OFF
