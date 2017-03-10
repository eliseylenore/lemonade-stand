USE [lemonade_stand]
GO
/****** Object:  Table [dbo].[players]    Script Date: 3/9/2017 4:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[money] [decimal](9, 2) NULL,
	[count] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[players_scores]    Script Date: 3/9/2017 4:07:21 PM ******/
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

INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (1, N'te', N'te', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (2, N'qq', N'qq', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (3, N'qq', N'qq', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (4, N'qq', N'qq', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (5, N'qq', N'qq', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (6, N'qq', N'qq', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (7, N'qqq', N'qqq', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (8, N'qqq', N'qqq', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (9, N'qqq', N'qqq', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (10, N'qqq', N'qqq', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (11, N'qqq', N'qqq', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (12, N'qqq', N'qqq', CAST(32.00 AS Decimal(9, 2)), 2)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (13, N'ttt', N'ttt', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (14, N'qqqq', N'qqqq', CAST(23.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (15, N'll', N'll', CAST(32.40 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (16, N'gg', N'gg', CAST(28.00 AS Decimal(9, 2)), 3)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (17, N'dd', N'dd', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (18, N'tdd', N'tddd', CAST(27.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (19, N'tt', N'tt', CAST(26.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (20, N'bb', N'bb', CAST(63.70 AS Decimal(9, 2)), 2)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (21, N'qqqqq', N'qqq', CAST(22.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (22, N'f', N'f', CAST(33.60 AS Decimal(9, 2)), 6)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (23, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (24, N'coolgurl123', N'password123', CAST(65.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (25, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (26, N'coolgurl123', N'password123', CAST(5.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (27, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (28, N'coolgurl123', N'password123', CAST(35.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (29, N'coolgurl123', N'password123', CAST(10.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (30, N'coolgurl123', N'password123', CAST(20.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (31, N'coolgurl123', N'password123', CAST(35.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (32, N'coolgurl123', N'password123', CAST(10.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (33, N'coolgurl123', N'password123', CAST(30.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (34, N'coolgurl123', N'password123', CAST(15.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (35, N'coolgurl123', N'password123', CAST(25.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (36, N'coolgurl123', N'password123', CAST(40.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (37, N'coolgurl123', N'password123', CAST(10.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (38, N'coolgurl123', N'password123', CAST(-15.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (39, N'coolgurl123', N'password123', CAST(-20.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (40, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (41, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (42, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (43, N'coolgurl123', N'password123', CAST(10.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (44, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (45, N'coolgurl123', N'password123', CAST(10.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (46, N'coolgurl123', N'password123', CAST(10.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (47, N'coolgurl123', N'password123', CAST(10.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (48, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (49, N'aa', N'aa', CAST(17.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (50, N'd', N'd', CAST(4.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (51, N'd', N'd', CAST(20.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (52, N'coolgurl123', N'password123', CAST(10.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (53, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (54, N'coolgurl123', N'password123', CAST(10.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (55, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (56, N'coolgurl123', N'password123', CAST(0.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (57, N'dang', N'dang', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (58, N'dang', N'dang', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (59, N'dang', N'dang', CAST(14.50 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (60, N'dang', N'dang', CAST(20.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (61, N'dang', N'dang', CAST(20.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (62, N'Tam', N'Tam', CAST(20.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (63, N'Tam', N'Tam', CAST(172.00 AS Decimal(9, 2)), 4)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (64, N't', N't', CAST(23.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (65, N't', N't', CAST(20.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (66, N'bb', N'bb', CAST(20.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (67, N'ttt', N'ttt', CAST(20.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (68, N'coolgurl123', N'password123', CAST(-20.00 AS Decimal(9, 2)), 0)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (69, N'td', N'td', CAST(14.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (70, N'td', N'td', CAST(10.00 AS Decimal(9, 2)), 2)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (71, N'qqq', N'qqq', CAST(20.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (72, N'ggg', N'ggg', CAST(4.00 AS Decimal(9, 2)), 2)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (73, N'rrr', N'rrr', CAST(8.00 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (74, N'ddd', N'ddd', CAST(9.20 AS Decimal(9, 2)), 1)
INSERT [dbo].[players] ([id], [username], [password], [money], [count]) VALUES (75, N'coolgurl123', N'password123', CAST(-15.00 AS Decimal(9, 2)), 0)
SET IDENTITY_INSERT [dbo].[players] OFF
SET IDENTITY_INSERT [dbo].[players_scores] ON 

INSERT [dbo].[players_scores] ([id], [player_id], [score]) VALUES (1, 16, CAST(59.20 AS Decimal(9, 2)))
INSERT [dbo].[players_scores] ([id], [player_id], [score]) VALUES (2, 65, CAST(23.30 AS Decimal(9, 2)))
SET IDENTITY_INSERT [dbo].[players_scores] OFF
