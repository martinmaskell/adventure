USE [Adventure]
GO
/****** Object:  User [maskellweb]    Script Date: 09/29/2011 16:25:27 ******/
CREATE USER [maskellweb] FOR LOGIN [maskellweb] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [GameData]    Script Date: 09/29/2011 16:25:25 ******/
CREATE SCHEMA [GameData] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [LocationData]    Script Date: 09/29/2011 16:25:25 ******/
CREATE SCHEMA [LocationData] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [LogicData]    Script Date: 09/29/2011 16:25:25 ******/
CREATE SCHEMA [LogicData] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [LookupData]    Script Date: 09/29/2011 16:25:25 ******/
CREATE SCHEMA [LookupData] AUTHORIZATION [dbo]
GO
/****** Object:  Table [LocationData].[Direction]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LocationData].[Direction](
	[DirectionID] [uniqueidentifier] NOT NULL,
	[DirectionName] [nvarchar](200) NOT NULL,
	[ShortName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Direction] PRIMARY KEY CLUSTERED 
(
	[DirectionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'ff7277fe-46e8-e011-b36b-005056c00008', N'Right', N'R')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'007377fe-46e8-e011-b36b-005056c00008', N'West', N'W')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'017377fe-46e8-e011-b36b-005056c00008', N'Up', N'U')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'027377fe-46e8-e011-b36b-005056c00008', N'North', N'N')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'037377fe-46e8-e011-b36b-005056c00008', N'Southeast', N'SE')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'047377fe-46e8-e011-b36b-005056c00008', N'Northwest', N'NW')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'057377fe-46e8-e011-b36b-005056c00008', N'East', N'E')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'067377fe-46e8-e011-b36b-005056c00008', N'South', N'S')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'077377fe-46e8-e011-b36b-005056c00008', N'Inside', N'In')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'087377fe-46e8-e011-b36b-005056c00008', N'Left', N'L')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'097377fe-46e8-e011-b36b-005056c00008', N'Northeast', N'NE')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'0a7377fe-46e8-e011-b36b-005056c00008', N'Down', N'D')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'0b7377fe-46e8-e011-b36b-005056c00008', N'Southwest', N'SW')
INSERT [LocationData].[Direction] ([DirectionID], [DirectionName], [ShortName]) VALUES (N'0c7377fe-46e8-e011-b36b-005056c00008', N'Outside', N'Out')
/****** Object:  Table [LookupData].[ParameterType]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [LookupData].[ParameterType](
	[ParameterTypeID] [int] NOT NULL,
	[ParameterTypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ParameterType] PRIMARY KEY CLUSTERED 
(
	[ParameterTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [LookupData].[ParameterType] ([ParameterTypeID], [ParameterTypeName]) VALUES (1, N'Item')
INSERT [LookupData].[ParameterType] ([ParameterTypeID], [ParameterTypeName]) VALUES (2, N'Location')
INSERT [LookupData].[ParameterType] ([ParameterTypeID], [ParameterTypeName]) VALUES (3, N'Direction')
INSERT [LookupData].[ParameterType] ([ParameterTypeID], [ParameterTypeName]) VALUES (4, N'Non Player Character')
/****** Object:  Table [LookupData].[PropertyType]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [LookupData].[PropertyType](
	[PropertyTypeID] [int] NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PropertyType] PRIMARY KEY CLUSTERED 
(
	[PropertyTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [LookupData].[PropertyType] ([PropertyTypeID], [TypeName]) VALUES (1, N'String')
INSERT [LookupData].[PropertyType] ([PropertyTypeID], [TypeName]) VALUES (2, N'Int32')
INSERT [LookupData].[PropertyType] ([PropertyTypeID], [TypeName]) VALUES (3, N'Bool')
INSERT [LookupData].[PropertyType] ([PropertyTypeID], [TypeName]) VALUES (4, N'DateTime')
INSERT [LookupData].[PropertyType] ([PropertyTypeID], [TypeName]) VALUES (5, N'Decimal')
/****** Object:  Table [GameData].[Module]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameData].[Module](
	[ModuleID] [int] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[ModuleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LookupData].[DependencyType]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [LookupData].[DependencyType](
	[DependencyTypeID] [int] NOT NULL,
	[DependencyName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DependencyType] PRIMARY KEY CLUSTERED 
(
	[DependencyTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (1, N'Location Is Available')
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (2, N'Location Is Not Available')
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (3, N'Item Is In Inventory')
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (4, N'Item Is Not in Inventory')
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (5, N'Item Is At Location')
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (6, N'Item Is Not At Location')
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (7, N'Item Property Value Is Equal To')
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (8, N'Item Property Value Is Not Equal To')
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (9, N'Item Property Value Is True')
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (10, N'Item Property Value Is False')
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (11, N'Item Property Value Is Greater Than')
INSERT [LookupData].[DependencyType] ([DependencyTypeID], [DependencyName]) VALUES (12, N'Item Property Value Is Less Than')
/****** Object:  Table [LookupData].[CommandType]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LookupData].[CommandType](
	[CommandTypeID] [int] NOT NULL,
	[CommandTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CommandType] PRIMARY KEY CLUSTERED 
(
	[CommandTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (1, N'close ')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (2, N'drink ')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (3, N'drop ')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (4, N'eat ')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (5, N'examine')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (6, N'give')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (7, N'go ')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (8, N'lock ')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (9, N'look')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (10, N'open ')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (11, N'pickup ')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (12, N'put ')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (13, N'take')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (14, N'talk ')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (15, N'unlock ')
INSERT [LookupData].[CommandType] ([CommandTypeID], [CommandTypeName]) VALUES (16, N'use')
/****** Object:  Table [LookupData].[Action]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [LookupData].[Action](
	[ActionID] [int] NOT NULL,
	[ActionName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [LookupData].[Action] ([ActionID], [ActionName]) VALUES (1, N'Change Current Location')
INSERT [LookupData].[Action] ([ActionID], [ActionName]) VALUES (2, N'Add Item To Inventory')
INSERT [LookupData].[Action] ([ActionID], [ActionName]) VALUES (3, N'Remove Item From Inventory')
INSERT [LookupData].[Action] ([ActionID], [ActionName]) VALUES (4, N'Change Item Property')
INSERT [LookupData].[Action] ([ActionID], [ActionName]) VALUES (5, N'Add Location Relationship To Location')
INSERT [LookupData].[Action] ([ActionID], [ActionName]) VALUES (6, N'Remove Location Relationship From Location')
/****** Object:  Table [LocationData].[LocationDirection]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LocationData].[LocationDirection](
	[SourceLocationID] [uniqueidentifier] NOT NULL,
	[TargetLocationID] [uniqueidentifier] NOT NULL,
	[DirectionID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_LocationDirection_1] PRIMARY KEY CLUSTERED 
(
	[SourceLocationID] ASC,
	[TargetLocationID] ASC,
	[DirectionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [LocationData].[LocationDirection] ([SourceLocationID], [TargetLocationID], [DirectionID]) VALUES (N'91b43129-e2e8-e011-b36b-005056c00008', N'0dbb3a61-ece8-e011-b36b-005056c00008', N'027377fe-46e8-e011-b36b-005056c00008')
/****** Object:  Table [LogicData].[Command]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LogicData].[Command](
	[CommandID] [int] NOT NULL,
	[CommandTypeID] [int] NOT NULL,
	[FirstParameterType] [int] NULL,
	[SecondParameterType] [int] NULL,
	[ThirdParameterType] [int] NULL,
	[FourthParameterType] [int] NULL,
 CONSTRAINT [PK_Command] PRIMARY KEY CLUSTERED 
(
	[CommandID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [LogicData].[Command] ([CommandID], [CommandTypeID], [FirstParameterType], [SecondParameterType], [ThirdParameterType], [FourthParameterType]) VALUES (1, 7, 3, NULL, NULL, NULL)
/****** Object:  Table [GameData].[ItemProperty]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GameData].[ItemProperty](
	[ItemPropertyID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[PropertyTypeID] [int] NOT NULL,
	[PropertyName] [varchar](50) NOT NULL,
	[PropertyValue] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_ItemProperty] PRIMARY KEY CLUSTERED 
(
	[ItemPropertyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GameData].[CommandTypeModule]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameData].[CommandTypeModule](
	[CommandTypeID] [int] NOT NULL,
	[ModuleID] [int] NOT NULL,
 CONSTRAINT [PK_CommandTypeModule] PRIMARY KEY CLUSTERED 
(
	[CommandTypeID] ASC,
	[ModuleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LogicData].[CommandActionDependency]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LogicData].[CommandActionDependency](
	[CommandActionID] [int] NOT NULL,
	[DependencyID] [int] NOT NULL,
	[DependencyOrder] [int] NOT NULL,
 CONSTRAINT [PK_CommandActionDependency] PRIMARY KEY CLUSTERED 
(
	[CommandActionID] ASC,
	[DependencyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LogicData].[CommandAction]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LogicData].[CommandAction](
	[CommandActionID] [int] IDENTITY(1,1) NOT NULL,
	[CommandID] [int] NOT NULL,
	[ActionGroupID] [int] NOT NULL,
	[FirstParameterID] [uniqueidentifier] NOT NULL,
	[SecondParameterID] [uniqueidentifier] NULL,
	[ThirdParameterID] [uniqueidentifier] NULL,
	[FourthParameterID] [uniqueidentifier] NULL,
	[GameID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CommandAction] PRIMARY KEY CLUSTERED 
(
	[CommandActionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [LogicData].[CommandAction] ON
INSERT [LogicData].[CommandAction] ([CommandActionID], [CommandID], [ActionGroupID], [FirstParameterID], [SecondParameterID], [ThirdParameterID], [FourthParameterID], [GameID]) VALUES (1, 1, 1, N'027377fe-46e8-e011-b36b-005056c00008', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [LogicData].[CommandAction] OFF
/****** Object:  Table [GameData].[Item]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameData].[Item](
	[ItemID] [uniqueidentifier] NOT NULL,
	[GameID] [uniqueidentifier] NOT NULL,
	[ItemName] [nvarchar](500) NOT NULL,
	[CommonName] [nvarchar](500) NOT NULL,
	[ItemDescription] [text] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [LocationData].[Location]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [LocationData].[Location](
	[LocationID] [uniqueidentifier] NOT NULL,
	[GameID] [uniqueidentifier] NOT NULL,
	[LocationName] [varchar](500) NOT NULL,
	[LocationDescription] [text] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [LocationData].[Location] ([LocationID], [GameID], [LocationName], [LocationDescription]) VALUES (N'91b43129-e2e8-e011-b36b-005056c00008', N'2888acb4-4ae8-e011-b36b-005056c00008', N'Home', N'You are in a large room with no windows. There is an opening to the North.')
INSERT [LocationData].[Location] ([LocationID], [GameID], [LocationName], [LocationDescription]) VALUES (N'0dbb3a61-ece8-e011-b36b-005056c00008', N'2888acb4-4ae8-e011-b36b-005056c00008', N'Pantry', N'You are in a pantry.  There are a few dusty shelves here.')
/****** Object:  Table [LogicData].[CommandActionResponse]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [LogicData].[CommandActionResponse](
	[CommandActionResponseID] [int] IDENTITY(1,1) NOT NULL,
	[CommandActionID] [int] NOT NULL,
	[SuccessReponseMessage] [varchar](1000) NOT NULL,
	[FailResponseMessage] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_CommandTypeDirectionResponse] PRIMARY KEY CLUSTERED 
(
	[CommandActionResponseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [LogicData].[LocationCommandAction]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LogicData].[LocationCommandAction](
	[LocationID] [uniqueidentifier] NOT NULL,
	[CommandActionID] [int] NOT NULL,
 CONSTRAINT [PK_LocationCommandAction] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC,
	[CommandActionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LocationData].[LocationItem]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LocationData].[LocationItem](
	[LocationID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_LocationItem] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC,
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GameData].[Game]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameData].[Game](
	[GameID] [uniqueidentifier] NOT NULL,
	[OwnerID] [int] NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Description] [text] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[StartLocationID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[GameID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [GameData].[Game] ([GameID], [OwnerID], [Title], [Description], [DateAdded], [StartLocationID]) VALUES (N'2888acb4-4ae8-e011-b36b-005056c00008', 1, N'Martin''s Test Game', N'This is a test description', CAST(0x00009F6A00FCE551 AS DateTime), N'91b43129-e2e8-e011-b36b-005056c00008')
/****** Object:  Table [LogicData].[Dependency]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [LogicData].[Dependency](
	[DependencyID] [int] IDENTITY(1,1) NOT NULL,
	[DependencyTypeID] [int] NOT NULL,
	[DependencyElementID] [uniqueidentifier] NOT NULL,
	[DependencyElementKey] [varchar](50) NOT NULL,
	[DependencyElementValue] [varchar](50) NULL,
 CONSTRAINT [PK_Dependency] PRIMARY KEY CLUSTERED 
(
	[DependencyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [LogicData].[ActionGroup]    Script Date: 09/29/2011 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LogicData].[ActionGroup](
	[ActionGroupID] [int] NOT NULL,
	[ActionID] [int] NOT NULL,
	[ActionOrder] [int] NOT NULL,
 CONSTRAINT [PK_ActionGroup] PRIMARY KEY CLUSTERED 
(
	[ActionGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [LogicData].[ActionGroup] ([ActionGroupID], [ActionID], [ActionOrder]) VALUES (1, 1, 1)
/****** Object:  StoredProcedure [LogicData].[GetCommandAction]    Script Date: 09/29/2011 16:25:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LogicData].[GetCommandAction](
												@CommandTypeId int, 
												@FirstParameterId uniqueidentifier = NULL, 
												@SecondParameterId uniqueidentifier = NULL, 
												@ThirdParameterId uniqueidentifier = NULL, 
												@FourthParameterId uniqueidentifier = NULL, 
												@GameId uniqueidentifier = NULL) AS

SELECT CA.*
FROM [LogicData].[CommandAction] CA
INNER JOIN [LogicData].[Command] C on C.CommandID = CA.CommandID
WHERE C.CommandTypeID = @CommandTypeId
AND (@FirstParameterId IS NULL OR CA.FirstParameterID = @FirstParameterId)
AND (@SecondParameterId IS NULL OR CA.SecondParameterID = @SecondParameterId)
AND (@ThirdParameterId IS NULL OR CA.ThirdParameterID = @ThirdParameterId)
AND (@ThirdParameterId IS NULL OR CA.FourthParameterID = @FourthParameterId)
AND (@GameId IS NULL OR CA.GameID = @GameId)
GO
/****** Object:  Default [DF_Game_GameID]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [GameData].[Game] ADD  CONSTRAINT [DF_Game_GameID]  DEFAULT (newsequentialid()) FOR [GameID]
GO
/****** Object:  Default [DF_Game_DateCreated]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [GameData].[Game] ADD  CONSTRAINT [DF_Game_DateCreated]  DEFAULT (getdate()) FOR [DateAdded]
GO
/****** Object:  Default [DF_Item_ItemID]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [GameData].[Item] ADD  CONSTRAINT [DF_Item_ItemID]  DEFAULT (newsequentialid()) FOR [ItemID]
GO
/****** Object:  Default [DF_Direction_GameID]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LocationData].[Direction] ADD  CONSTRAINT [DF_Direction_GameID]  DEFAULT (newsequentialid()) FOR [DirectionID]
GO
/****** Object:  Default [DF_Location_LocationID]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LocationData].[Location] ADD  CONSTRAINT [DF_Location_LocationID]  DEFAULT (newsequentialid()) FOR [LocationID]
GO
/****** Object:  Default [DF_LocationDirection_DirectionID]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LocationData].[LocationDirection] ADD  CONSTRAINT [DF_LocationDirection_DirectionID]  DEFAULT (newsequentialid()) FOR [DirectionID]
GO
/****** Object:  Default [DF_LocationItem_LocationID]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LocationData].[LocationItem] ADD  CONSTRAINT [DF_LocationItem_LocationID]  DEFAULT (newid()) FOR [LocationID]
GO
/****** Object:  Default [DF_LocationItem_ItemID]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LocationData].[LocationItem] ADD  CONSTRAINT [DF_LocationItem_ItemID]  DEFAULT (newid()) FOR [ItemID]
GO
/****** Object:  Default [DF_LocationCommandAction_LocationID]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[LocationCommandAction] ADD  CONSTRAINT [DF_LocationCommandAction_LocationID]  DEFAULT (newsequentialid()) FOR [LocationID]
GO
/****** Object:  ForeignKey [FK_CommandTypeModule_CommandType]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [GameData].[CommandTypeModule]  WITH CHECK ADD  CONSTRAINT [FK_CommandTypeModule_CommandType] FOREIGN KEY([CommandTypeID])
REFERENCES [LookupData].[CommandType] ([CommandTypeID])
GO
ALTER TABLE [GameData].[CommandTypeModule] CHECK CONSTRAINT [FK_CommandTypeModule_CommandType]
GO
/****** Object:  ForeignKey [FK_CommandTypeModule_Module]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [GameData].[CommandTypeModule]  WITH CHECK ADD  CONSTRAINT [FK_CommandTypeModule_Module] FOREIGN KEY([ModuleID])
REFERENCES [GameData].[Module] ([ModuleID])
GO
ALTER TABLE [GameData].[CommandTypeModule] CHECK CONSTRAINT [FK_CommandTypeModule_Module]
GO
/****** Object:  ForeignKey [FK_Game_Location]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [GameData].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_Location] FOREIGN KEY([StartLocationID])
REFERENCES [LocationData].[Location] ([LocationID])
GO
ALTER TABLE [GameData].[Game] CHECK CONSTRAINT [FK_Game_Location]
GO
/****** Object:  ForeignKey [FK_Item_Game]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [GameData].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Game] FOREIGN KEY([GameID])
REFERENCES [GameData].[Game] ([GameID])
GO
ALTER TABLE [GameData].[Item] CHECK CONSTRAINT [FK_Item_Game]
GO
/****** Object:  ForeignKey [FK_ItemProperty_Item]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [GameData].[ItemProperty]  WITH CHECK ADD  CONSTRAINT [FK_ItemProperty_Item] FOREIGN KEY([ItemID])
REFERENCES [GameData].[Item] ([ItemID])
GO
ALTER TABLE [GameData].[ItemProperty] CHECK CONSTRAINT [FK_ItemProperty_Item]
GO
/****** Object:  ForeignKey [FK_ItemProperty_PropertyType]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [GameData].[ItemProperty]  WITH CHECK ADD  CONSTRAINT [FK_ItemProperty_PropertyType] FOREIGN KEY([PropertyTypeID])
REFERENCES [LookupData].[PropertyType] ([PropertyTypeID])
GO
ALTER TABLE [GameData].[ItemProperty] CHECK CONSTRAINT [FK_ItemProperty_PropertyType]
GO
/****** Object:  ForeignKey [FK_Location_Game]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LocationData].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Game] FOREIGN KEY([GameID])
REFERENCES [GameData].[Game] ([GameID])
GO
ALTER TABLE [LocationData].[Location] CHECK CONSTRAINT [FK_Location_Game]
GO
/****** Object:  ForeignKey [FK_LocationDirection_Direction]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LocationData].[LocationDirection]  WITH CHECK ADD  CONSTRAINT [FK_LocationDirection_Direction] FOREIGN KEY([DirectionID])
REFERENCES [LocationData].[Direction] ([DirectionID])
GO
ALTER TABLE [LocationData].[LocationDirection] CHECK CONSTRAINT [FK_LocationDirection_Direction]
GO
/****** Object:  ForeignKey [FK_LocationDirection_Location]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LocationData].[LocationDirection]  WITH CHECK ADD  CONSTRAINT [FK_LocationDirection_Location] FOREIGN KEY([SourceLocationID])
REFERENCES [LocationData].[Location] ([LocationID])
GO
ALTER TABLE [LocationData].[LocationDirection] CHECK CONSTRAINT [FK_LocationDirection_Location]
GO
/****** Object:  ForeignKey [FK_LocationDirection_Location1]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LocationData].[LocationDirection]  WITH CHECK ADD  CONSTRAINT [FK_LocationDirection_Location1] FOREIGN KEY([TargetLocationID])
REFERENCES [LocationData].[Location] ([LocationID])
GO
ALTER TABLE [LocationData].[LocationDirection] CHECK CONSTRAINT [FK_LocationDirection_Location1]
GO
/****** Object:  ForeignKey [FK_LocationItem_Item]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LocationData].[LocationItem]  WITH CHECK ADD  CONSTRAINT [FK_LocationItem_Item] FOREIGN KEY([ItemID])
REFERENCES [GameData].[Item] ([ItemID])
GO
ALTER TABLE [LocationData].[LocationItem] CHECK CONSTRAINT [FK_LocationItem_Item]
GO
/****** Object:  ForeignKey [FK_LocationItem_Location]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LocationData].[LocationItem]  WITH CHECK ADD  CONSTRAINT [FK_LocationItem_Location] FOREIGN KEY([LocationID])
REFERENCES [LocationData].[Location] ([LocationID])
GO
ALTER TABLE [LocationData].[LocationItem] CHECK CONSTRAINT [FK_LocationItem_Location]
GO
/****** Object:  ForeignKey [FK_ActionGroup_Action]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[ActionGroup]  WITH CHECK ADD  CONSTRAINT [FK_ActionGroup_Action] FOREIGN KEY([ActionID])
REFERENCES [LookupData].[Action] ([ActionID])
GO
ALTER TABLE [LogicData].[ActionGroup] CHECK CONSTRAINT [FK_ActionGroup_Action]
GO
/****** Object:  ForeignKey [FK_Command_CommandType]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[Command]  WITH CHECK ADD  CONSTRAINT [FK_Command_CommandType] FOREIGN KEY([CommandTypeID])
REFERENCES [LookupData].[CommandType] ([CommandTypeID])
GO
ALTER TABLE [LogicData].[Command] CHECK CONSTRAINT [FK_Command_CommandType]
GO
/****** Object:  ForeignKey [FK_Command_ParameterType]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[Command]  WITH CHECK ADD  CONSTRAINT [FK_Command_ParameterType] FOREIGN KEY([FirstParameterType])
REFERENCES [LookupData].[ParameterType] ([ParameterTypeID])
GO
ALTER TABLE [LogicData].[Command] CHECK CONSTRAINT [FK_Command_ParameterType]
GO
/****** Object:  ForeignKey [FK_Command_ParameterType1]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[Command]  WITH CHECK ADD  CONSTRAINT [FK_Command_ParameterType1] FOREIGN KEY([SecondParameterType])
REFERENCES [LookupData].[ParameterType] ([ParameterTypeID])
GO
ALTER TABLE [LogicData].[Command] CHECK CONSTRAINT [FK_Command_ParameterType1]
GO
/****** Object:  ForeignKey [FK_Command_ParameterType2]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[Command]  WITH CHECK ADD  CONSTRAINT [FK_Command_ParameterType2] FOREIGN KEY([ThirdParameterType])
REFERENCES [LookupData].[ParameterType] ([ParameterTypeID])
GO
ALTER TABLE [LogicData].[Command] CHECK CONSTRAINT [FK_Command_ParameterType2]
GO
/****** Object:  ForeignKey [FK_Command_ParameterType3]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[Command]  WITH CHECK ADD  CONSTRAINT [FK_Command_ParameterType3] FOREIGN KEY([FourthParameterType])
REFERENCES [LookupData].[ParameterType] ([ParameterTypeID])
GO
ALTER TABLE [LogicData].[Command] CHECK CONSTRAINT [FK_Command_ParameterType3]
GO
/****** Object:  ForeignKey [FK_CommandAction_ActionGroup]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[CommandAction]  WITH CHECK ADD  CONSTRAINT [FK_CommandAction_ActionGroup] FOREIGN KEY([ActionGroupID])
REFERENCES [LogicData].[ActionGroup] ([ActionGroupID])
GO
ALTER TABLE [LogicData].[CommandAction] CHECK CONSTRAINT [FK_CommandAction_ActionGroup]
GO
/****** Object:  ForeignKey [FK_CommandAction_Command]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[CommandAction]  WITH CHECK ADD  CONSTRAINT [FK_CommandAction_Command] FOREIGN KEY([CommandID])
REFERENCES [LogicData].[Command] ([CommandID])
GO
ALTER TABLE [LogicData].[CommandAction] CHECK CONSTRAINT [FK_CommandAction_Command]
GO
/****** Object:  ForeignKey [FK_CommandAction_Game]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[CommandAction]  WITH CHECK ADD  CONSTRAINT [FK_CommandAction_Game] FOREIGN KEY([GameID])
REFERENCES [GameData].[Game] ([GameID])
GO
ALTER TABLE [LogicData].[CommandAction] CHECK CONSTRAINT [FK_CommandAction_Game]
GO
/****** Object:  ForeignKey [FK_CommandActionDependency_CommandAction]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[CommandActionDependency]  WITH CHECK ADD  CONSTRAINT [FK_CommandActionDependency_CommandAction] FOREIGN KEY([CommandActionID])
REFERENCES [LogicData].[CommandAction] ([CommandActionID])
GO
ALTER TABLE [LogicData].[CommandActionDependency] CHECK CONSTRAINT [FK_CommandActionDependency_CommandAction]
GO
/****** Object:  ForeignKey [FK_CommandTypeDirectionDependency_Dependency]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[CommandActionDependency]  WITH CHECK ADD  CONSTRAINT [FK_CommandTypeDirectionDependency_Dependency] FOREIGN KEY([DependencyID])
REFERENCES [LogicData].[Dependency] ([DependencyID])
GO
ALTER TABLE [LogicData].[CommandActionDependency] CHECK CONSTRAINT [FK_CommandTypeDirectionDependency_Dependency]
GO
/****** Object:  ForeignKey [FK_CommandActionResponse_CommandAction]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[CommandActionResponse]  WITH CHECK ADD  CONSTRAINT [FK_CommandActionResponse_CommandAction] FOREIGN KEY([CommandActionID])
REFERENCES [LogicData].[CommandAction] ([CommandActionID])
GO
ALTER TABLE [LogicData].[CommandActionResponse] CHECK CONSTRAINT [FK_CommandActionResponse_CommandAction]
GO
/****** Object:  ForeignKey [FK_CommandActionResponse_CommandAction1]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[CommandActionResponse]  WITH CHECK ADD  CONSTRAINT [FK_CommandActionResponse_CommandAction1] FOREIGN KEY([CommandActionID])
REFERENCES [LogicData].[CommandAction] ([CommandActionID])
GO
ALTER TABLE [LogicData].[CommandActionResponse] CHECK CONSTRAINT [FK_CommandActionResponse_CommandAction1]
GO
/****** Object:  ForeignKey [FK_Dependency_DependencyType]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[Dependency]  WITH CHECK ADD  CONSTRAINT [FK_Dependency_DependencyType] FOREIGN KEY([DependencyTypeID])
REFERENCES [LookupData].[DependencyType] ([DependencyTypeID])
GO
ALTER TABLE [LogicData].[Dependency] CHECK CONSTRAINT [FK_Dependency_DependencyType]
GO
/****** Object:  ForeignKey [FK_LocationCommandAction_CommandAction]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[LocationCommandAction]  WITH CHECK ADD  CONSTRAINT [FK_LocationCommandAction_CommandAction] FOREIGN KEY([CommandActionID])
REFERENCES [LogicData].[CommandAction] ([CommandActionID])
GO
ALTER TABLE [LogicData].[LocationCommandAction] CHECK CONSTRAINT [FK_LocationCommandAction_CommandAction]
GO
/****** Object:  ForeignKey [FK_LocationCommandAction_Location]    Script Date: 09/29/2011 16:25:27 ******/
ALTER TABLE [LogicData].[LocationCommandAction]  WITH CHECK ADD  CONSTRAINT [FK_LocationCommandAction_Location] FOREIGN KEY([LocationID])
REFERENCES [LocationData].[Location] ([LocationID])
GO
ALTER TABLE [LogicData].[LocationCommandAction] CHECK CONSTRAINT [FK_LocationCommandAction_Location]
GO
