USE [master]
GO

IF (DB_ID('BazaarCoreDB') IS NOT NULL)
BEGIN	
	RETURN;	
END

CREATE DATABASE [BazaarCoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BazaarCoreDB', FILENAME = N'/var/opt/mssql/BazaarCoreDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BazaarCoreDB_log', FILENAME = N'/var/opt/mssql/BazaarCoreDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BazaarCoreDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BazaarCoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BazaarCoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BazaarCoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BazaarCoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BazaarCoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BazaarCoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BazaarCoreDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BazaarCoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BazaarCoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [BazaarCoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BazaarCoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BazaarCoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BazaarCoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BazaarCoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BazaarCoreDB] SET QUERY_STORE = OFF
GO
USE [BazaarCoreDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BazaarCoreDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01/05/2021 22:42:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account]    Script Date: 01/05/2021 22:42:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[id] [uniqueidentifier] NOT NULL,
	[email] [nvarchar](60) NOT NULL,
	[normalized_email] [nvarchar](60) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[security_stamp] [nvarchar](max) NULL,
	[email_confirmed] [bit] NOT NULL,
 CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_claim]    Script Date: 01/05/2021 22:42:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_claim](
	[id] [uniqueidentifier] NOT NULL,
	[account_id] [uniqueidentifier] NOT NULL,
	[claim_type] [nvarchar](max) NOT NULL,
	[claim_value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_account_claim] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_login]    Script Date: 01/05/2021 22:42:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_login](
	[account_id] [uniqueidentifier] NOT NULL,
	[login_provider] [nvarchar](450) NOT NULL,
	[provider_key] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_account_login] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC,
	[login_provider] ASC,
	[provider_key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_role]    Script Date: 01/05/2021 22:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_role](
	[role_id] [uniqueidentifier] NOT NULL,
	[account_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_account_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC,
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ad]    Script Date: 01/05/2021 22:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ad](
	[id] [uniqueidentifier] NOT NULL,
	[title] [nvarchar](max) NULL,
	[description] [nvarchar](max) NOT NULL,
	[price] [float] NOT NULL,
	[date] [datetime2](7) NOT NULL,
	[id_category] [uniqueidentifier] NOT NULL,
	[id_advertiser] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ad_image]    Script Date: 01/05/2021 22:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ad_image](
	[id_ad] [uniqueidentifier] NOT NULL,
	[id_image] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ad_image] PRIMARY KEY CLUSTERED 
(
	[id_image] ASC,
	[id_ad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[advertiser]    Script Date: 01/05/2021 22:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[advertiser](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](15) NOT NULL,
	[last_name] [nvarchar](30) NOT NULL,
	[registration_date] [datetime2](7) NOT NULL,
	[id_avatar] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_advertiser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 01/05/2021 22:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[image]    Script Date: 01/05/2021 22:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[image](
	[id] [uniqueidentifier] NOT NULL,
	[bytes] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_image] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[question]    Script Date: 01/05/2021 22:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[question](
	[id] [uniqueidentifier] NOT NULL,
	[description] [nvarchar](2000) NOT NULL,
	[date] [datetime2](7) NOT NULL,
	[id_user] [uniqueidentifier] NOT NULL,
	[id_ad] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_question] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[response]    Script Date: 01/05/2021 22:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[response](
	[id] [uniqueidentifier] NOT NULL,
	[description] [nvarchar](2000) NOT NULL,
	[date] [datetime2](7) NOT NULL,
	[id_advertiser] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_response] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 01/05/2021 22:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[normalized_name] [nvarchar](max) NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190630225245_BazaarCoreMigrations', N'5.0.5')
INSERT [dbo].[category] ([id], [name]) VALUES (N'd7790600-e338-4039-8833-5f73b02bd385', N'Veículos')
INSERT [dbo].[category] ([id], [name]) VALUES (N'a03dd62c-b476-44eb-b202-85aabb961a5e', N'Brinquedos')
INSERT [dbo].[category] ([id], [name]) VALUES (N'8eabe0fe-39d9-4968-b5ab-9a48302b0a69', N'Livros')
INSERT [dbo].[category] ([id], [name]) VALUES (N'2ca2177d-7c3c-44b9-b966-a135ee698174', N'Esportes')
INSERT [dbo].[category] ([id], [name]) VALUES (N'03079373-5669-4852-ac40-ad5531cb7aac', N'Casa')
INSERT [dbo].[category] ([id], [name]) VALUES (N'18c188f0-8da1-4e94-b598-b642e8b5ed69', N'Eletrônicos')
INSERT [dbo].[category] ([id], [name]) VALUES (N'314dd8ce-cd48-49e0-a0e6-df51afe3f57c', N'Decoração')
INSERT [dbo].[category] ([id], [name]) VALUES (N'29575be0-758e-43b0-8ce4-e20f4f4351df', N'Música')
INSERT [dbo].[category] ([id], [name]) VALUES (N'c9061e94-8757-41de-9e78-e59ef73935ca', N'Moda')
/****** Object:  Index [IX_account_claim_account_id]    Script Date: 01/05/2021 22:42:22 ******/
CREATE NONCLUSTERED INDEX [IX_account_claim_account_id] ON [dbo].[account_claim]
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_account_role_account_id]    Script Date: 01/05/2021 22:42:22 ******/
CREATE NONCLUSTERED INDEX [IX_account_role_account_id] ON [dbo].[account_role]
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ad_id_advertiser]    Script Date: 01/05/2021 22:42:22 ******/
CREATE NONCLUSTERED INDEX [IX_ad_id_advertiser] ON [dbo].[ad]
(
	[id_advertiser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ad_id_category]    Script Date: 01/05/2021 22:42:22 ******/
CREATE NONCLUSTERED INDEX [IX_ad_id_category] ON [dbo].[ad]
(
	[id_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ad_image_id_ad]    Script Date: 01/05/2021 22:42:22 ******/
CREATE NONCLUSTERED INDEX [IX_ad_image_id_ad] ON [dbo].[ad_image]
(
	[id_ad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_advertiser_id_avatar]    Script Date: 01/05/2021 22:42:22 ******/
CREATE NONCLUSTERED INDEX [IX_advertiser_id_avatar] ON [dbo].[advertiser]
(
	[id_avatar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_question_id_ad]    Script Date: 01/05/2021 22:42:22 ******/
CREATE NONCLUSTERED INDEX [IX_question_id_ad] ON [dbo].[question]
(
	[id_ad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_question_id_user]    Script Date: 01/05/2021 22:42:22 ******/
CREATE NONCLUSTERED INDEX [IX_question_id_user] ON [dbo].[question]
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_response_id_advertiser]    Script Date: 01/05/2021 22:42:22 ******/
CREATE NONCLUSTERED INDEX [IX_response_id_advertiser] ON [dbo].[response]
(
	[id_advertiser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[account]  WITH CHECK ADD  CONSTRAINT [FK_account_advertiser_id] FOREIGN KEY([id])
REFERENCES [dbo].[advertiser] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[account] CHECK CONSTRAINT [FK_account_advertiser_id]
GO
ALTER TABLE [dbo].[account_claim]  WITH CHECK ADD  CONSTRAINT [FK_account_claim_account_account_id] FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[account_claim] CHECK CONSTRAINT [FK_account_claim_account_account_id]
GO
ALTER TABLE [dbo].[account_login]  WITH CHECK ADD  CONSTRAINT [FK_account_login_account_account_id] FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[account_login] CHECK CONSTRAINT [FK_account_login_account_account_id]
GO
ALTER TABLE [dbo].[account_role]  WITH CHECK ADD  CONSTRAINT [FK_account_role_account_account_id] FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[account_role] CHECK CONSTRAINT [FK_account_role_account_account_id]
GO
ALTER TABLE [dbo].[account_role]  WITH CHECK ADD  CONSTRAINT [FK_account_role_role_role_id] FOREIGN KEY([role_id])
REFERENCES [dbo].[role] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[account_role] CHECK CONSTRAINT [FK_account_role_role_role_id]
GO
ALTER TABLE [dbo].[ad]  WITH CHECK ADD  CONSTRAINT [FK_ad_advertiser_id_advertiser] FOREIGN KEY([id_advertiser])
REFERENCES [dbo].[advertiser] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ad] CHECK CONSTRAINT [FK_ad_advertiser_id_advertiser]
GO
ALTER TABLE [dbo].[ad]  WITH CHECK ADD  CONSTRAINT [FK_ad_category_id_category] FOREIGN KEY([id_category])
REFERENCES [dbo].[category] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ad] CHECK CONSTRAINT [FK_ad_category_id_category]
GO
ALTER TABLE [dbo].[ad_image]  WITH CHECK ADD  CONSTRAINT [FK_ad_image_ad_id_ad] FOREIGN KEY([id_ad])
REFERENCES [dbo].[ad] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ad_image] CHECK CONSTRAINT [FK_ad_image_ad_id_ad]
GO
ALTER TABLE [dbo].[ad_image]  WITH CHECK ADD  CONSTRAINT [FK_ad_image_image_id_image] FOREIGN KEY([id_image])
REFERENCES [dbo].[image] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ad_image] CHECK CONSTRAINT [FK_ad_image_image_id_image]
GO
ALTER TABLE [dbo].[advertiser]  WITH CHECK ADD  CONSTRAINT [FK_advertiser_image_id_avatar] FOREIGN KEY([id_avatar])
REFERENCES [dbo].[image] ([id])
GO
ALTER TABLE [dbo].[advertiser] CHECK CONSTRAINT [FK_advertiser_image_id_avatar]
GO
ALTER TABLE [dbo].[question]  WITH CHECK ADD  CONSTRAINT [FK_question_ad_id_ad] FOREIGN KEY([id_ad])
REFERENCES [dbo].[ad] ([id])
GO
ALTER TABLE [dbo].[question] CHECK CONSTRAINT [FK_question_ad_id_ad]
GO
ALTER TABLE [dbo].[question]  WITH CHECK ADD  CONSTRAINT [FK_question_advertiser_id_user] FOREIGN KEY([id_user])
REFERENCES [dbo].[advertiser] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[question] CHECK CONSTRAINT [FK_question_advertiser_id_user]
GO
ALTER TABLE [dbo].[response]  WITH CHECK ADD  CONSTRAINT [FK_response_advertiser_id_advertiser] FOREIGN KEY([id_advertiser])
REFERENCES [dbo].[advertiser] ([id])
GO
ALTER TABLE [dbo].[response] CHECK CONSTRAINT [FK_response_advertiser_id_advertiser]
GO
ALTER TABLE [dbo].[response]  WITH CHECK ADD  CONSTRAINT [FK_response_question_id] FOREIGN KEY([id])
REFERENCES [dbo].[question] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[response] CHECK CONSTRAINT [FK_response_question_id]
GO
USE [master]
GO
ALTER DATABASE [BazaarCoreDB] SET  READ_WRITE 
GO