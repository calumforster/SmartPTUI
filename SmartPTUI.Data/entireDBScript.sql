USE [master]
GO
/****** Object:  Database [SmartPTUI]    Script Date: 22/05/2021 02:16:57 ******/
CREATE DATABASE [SmartPTUI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SmartPTUI', FILENAME = N'C:\Users\Calum\SmartPTUI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SmartPTUI_log', FILENAME = N'C:\Users\Calum\SmartPTUI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SmartPTUI] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SmartPTUI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SmartPTUI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SmartPTUI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SmartPTUI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SmartPTUI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SmartPTUI] SET ARITHABORT OFF 
GO
ALTER DATABASE [SmartPTUI] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SmartPTUI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SmartPTUI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SmartPTUI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SmartPTUI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SmartPTUI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SmartPTUI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SmartPTUI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SmartPTUI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SmartPTUI] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SmartPTUI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SmartPTUI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SmartPTUI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SmartPTUI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SmartPTUI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SmartPTUI] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SmartPTUI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SmartPTUI] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SmartPTUI] SET  MULTI_USER 
GO
ALTER DATABASE [SmartPTUI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SmartPTUI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SmartPTUI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SmartPTUI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SmartPTUI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SmartPTUI] SET QUERY_STORE = OFF
GO
USE [SmartPTUI]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [SmartPTUI]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22/05/2021 02:16:57 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[CurrentHealth] [int] NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[Gender] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[PersonalTrainerId] [int] NULL,
	[isDisabled] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExcersizeMetas]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExcersizeMetas](
	[ExcersizeMetaId] [int] IDENTITY(1,1) NOT NULL,
	[WeightGoal] [int] NOT NULL,
	[SetsGoal] [int] NOT NULL,
	[WorkoutSessionId] [int] NULL,
	[ExcersizeId] [int] NOT NULL,
	[RepsGoal] [int] NOT NULL,
	[ExcersizeFeedbackRating] [int] NOT NULL,
	[FurtherNotes] [nvarchar](max) NULL,
	[isCompletedExcersizeMeta] [bit] NOT NULL,
 CONSTRAINT [PK_ExcersizeMetas] PRIMARY KEY CLUSTERED 
(
	[ExcersizeMetaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExcersizeSets]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExcersizeSets](
	[ExcersizeSetId] [int] IDENTITY(1,1) NOT NULL,
	[SetName] [nvarchar](max) NULL,
	[RepsAchieved] [int] NOT NULL,
	[WeightAchieved] [int] NOT NULL,
	[RepsInReserve] [int] NOT NULL,
	[ExcersizeMetaId] [int] NULL,
 CONSTRAINT [PK_ExcersizeSets] PRIMARY KEY CLUSTERED 
(
	[ExcersizeSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExcersizeStore]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExcersizeStore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimePerRep] [int] NOT NULL,
	[WorkoutName] [nvarchar](max) NULL,
	[WorkoutDescription] [nvarchar](max) NULL,
	[CoreArea] [int] NOT NULL,
	[Difficulty] [int] NOT NULL,
 CONSTRAINT [PK_ExcersizeStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExerciseStore]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseStore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimePerRep] [int] NOT NULL,
	[WorkoutName] [nvarchar](max) NULL,
	[WorkoutDescription] [nvarchar](max) NULL,
	[CoreArea] [int] NOT NULL,
 CONSTRAINT [PK_ExerciseStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalTrainer]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalTrainer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Gender] [int] NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[TitleColour] [nvarchar](max) NULL,
	[TextColour] [nvarchar](max) NULL,
	[BackgorundColour] [nvarchar](max) NULL,
	[TopBarColour] [nvarchar](max) NULL,
	[SiteName] [nvarchar](max) NULL,
	[WelcomeMessage] [nvarchar](max) NULL,
 CONSTRAINT [PK_PersonalTrainer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkoutPlans]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutPlans](
	[WorkoutPlanId] [int] IDENTITY(1,1) NOT NULL,
	[WorkoutQuestionId] [int] NULL,
	[CustomerId] [int] NULL,
	[isCompletedWorkoutPlan] [bit] NOT NULL,
 CONSTRAINT [PK_WorkoutPlans] PRIMARY KEY CLUSTERED 
(
	[WorkoutPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkoutQuestions]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutQuestions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartWeight] [int] NOT NULL,
	[EndWeight] [int] NOT NULL,
	[Goal] [int] NOT NULL,
	[DaysPerWeek] [int] NOT NULL,
	[TimePerWorkout] [int] NOT NULL,
	[WorkoutName] [nvarchar](max) NOT NULL,
	[NumberOfWeeks] [int] NOT NULL,
 CONSTRAINT [PK_WorkoutQuestions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkoutSessions]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutSessions](
	[WorkoutSessionId] [int] IDENTITY(1,1) NOT NULL,
	[WorkoutWeekId] [int] NULL,
	[isCompletedWorkoutSession] [bit] NOT NULL,
 CONSTRAINT [PK_WorkoutSessions] PRIMARY KEY CLUSTERED 
(
	[WorkoutSessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkoutWeeks]    Script Date: 22/05/2021 02:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutWeeks](
	[WorkoutWeekId] [int] IDENTITY(1,1) NOT NULL,
	[StartWeight] [int] NOT NULL,
	[EndWeight] [int] NOT NULL,
	[CaloriesConsumed] [int] NOT NULL,
	[WorkoutPlanId] [int] NULL,
	[isCompletedWorkoutWeek] [bit] NOT NULL,
 CONSTRAINT [PK_WorkoutWeeks] PRIMARY KEY CLUSTERED 
(
	[WorkoutWeekId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 22/05/2021 02:16:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 22/05/2021 02:16:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Customers_PersonalTrainerId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_Customers_PersonalTrainerId] ON [dbo].[Customers]
(
	[PersonalTrainerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Customers_UserId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_Customers_UserId] ON [dbo].[Customers]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExcersizeMetas_ExcersizeId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_ExcersizeMetas_ExcersizeId] ON [dbo].[ExcersizeMetas]
(
	[ExcersizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExcersizeMetas_WorkoutSessionId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_ExcersizeMetas_WorkoutSessionId] ON [dbo].[ExcersizeMetas]
(
	[WorkoutSessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExcersizeSets_ExcersizeMetaId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_ExcersizeSets_ExcersizeMetaId] ON [dbo].[ExcersizeSets]
(
	[ExcersizeMetaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PersonalTrainer_UserId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_PersonalTrainer_UserId] ON [dbo].[PersonalTrainer]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkoutPlans_CustomerId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_WorkoutPlans_CustomerId] ON [dbo].[WorkoutPlans]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkoutPlans_WorkoutQuestionId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_WorkoutPlans_WorkoutQuestionId] ON [dbo].[WorkoutPlans]
(
	[WorkoutQuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkoutSessions_WorkoutWeekId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_WorkoutSessions_WorkoutWeekId] ON [dbo].[WorkoutSessions]
(
	[WorkoutWeekId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkoutWeeks_WorkoutPlanId]    Script Date: 22/05/2021 02:16:57 ******/
CREATE NONCLUSTERED INDEX [IX_WorkoutWeeks_WorkoutPlanId] ON [dbo].[WorkoutWeeks]
(
	[WorkoutPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [CurrentHealth]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DOB]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [Gender]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [Height]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isDisabled]
GO
ALTER TABLE [dbo].[ExcersizeMetas] ADD  DEFAULT ((0)) FOR [ExcersizeId]
GO
ALTER TABLE [dbo].[ExcersizeMetas] ADD  DEFAULT ((0)) FOR [RepsGoal]
GO
ALTER TABLE [dbo].[ExcersizeMetas] ADD  DEFAULT ((0)) FOR [ExcersizeFeedbackRating]
GO
ALTER TABLE [dbo].[ExcersizeMetas] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isCompletedExcersizeMeta]
GO
ALTER TABLE [dbo].[ExcersizeStore] ADD  DEFAULT ((0)) FOR [Difficulty]
GO
ALTER TABLE [dbo].[WorkoutPlans] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isCompletedWorkoutPlan]
GO
ALTER TABLE [dbo].[WorkoutQuestions] ADD  DEFAULT (N'') FOR [WorkoutName]
GO
ALTER TABLE [dbo].[WorkoutQuestions] ADD  DEFAULT ((0)) FOR [NumberOfWeeks]
GO
ALTER TABLE [dbo].[WorkoutSessions] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isCompletedWorkoutSession]
GO
ALTER TABLE [dbo].[WorkoutWeeks] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isCompletedWorkoutWeek]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_PersonalTrainer_PersonalTrainerId] FOREIGN KEY([PersonalTrainerId])
REFERENCES [dbo].[PersonalTrainer] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_PersonalTrainer_PersonalTrainerId]
GO
ALTER TABLE [dbo].[ExcersizeMetas]  WITH CHECK ADD  CONSTRAINT [FK_ExcersizeMetas_ExcersizeStore_ExcersizeId] FOREIGN KEY([ExcersizeId])
REFERENCES [dbo].[ExcersizeStore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExcersizeMetas] CHECK CONSTRAINT [FK_ExcersizeMetas_ExcersizeStore_ExcersizeId]
GO
ALTER TABLE [dbo].[ExcersizeMetas]  WITH CHECK ADD  CONSTRAINT [FK_ExcersizeMetas_WorkoutSessions_WorkoutSessionId] FOREIGN KEY([WorkoutSessionId])
REFERENCES [dbo].[WorkoutSessions] ([WorkoutSessionId])
GO
ALTER TABLE [dbo].[ExcersizeMetas] CHECK CONSTRAINT [FK_ExcersizeMetas_WorkoutSessions_WorkoutSessionId]
GO
ALTER TABLE [dbo].[ExcersizeSets]  WITH CHECK ADD  CONSTRAINT [FK_ExcersizeSets_ExcersizeMetas_ExcersizeMetaId] FOREIGN KEY([ExcersizeMetaId])
REFERENCES [dbo].[ExcersizeMetas] ([ExcersizeMetaId])
GO
ALTER TABLE [dbo].[ExcersizeSets] CHECK CONSTRAINT [FK_ExcersizeSets_ExcersizeMetas_ExcersizeMetaId]
GO
ALTER TABLE [dbo].[PersonalTrainer]  WITH CHECK ADD  CONSTRAINT [FK_PersonalTrainer_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[PersonalTrainer] CHECK CONSTRAINT [FK_PersonalTrainer_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[WorkoutPlans]  WITH CHECK ADD  CONSTRAINT [FK_WorkoutPlans_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[WorkoutPlans] CHECK CONSTRAINT [FK_WorkoutPlans_Customers_CustomerId]
GO
ALTER TABLE [dbo].[WorkoutPlans]  WITH CHECK ADD  CONSTRAINT [FK_WorkoutPlans_WorkoutQuestions_WorkoutQuestionId] FOREIGN KEY([WorkoutQuestionId])
REFERENCES [dbo].[WorkoutQuestions] ([Id])
GO
ALTER TABLE [dbo].[WorkoutPlans] CHECK CONSTRAINT [FK_WorkoutPlans_WorkoutQuestions_WorkoutQuestionId]
GO
ALTER TABLE [dbo].[WorkoutSessions]  WITH CHECK ADD  CONSTRAINT [FK_WorkoutSessions_WorkoutWeeks_WorkoutWeekId] FOREIGN KEY([WorkoutWeekId])
REFERENCES [dbo].[WorkoutWeeks] ([WorkoutWeekId])
GO
ALTER TABLE [dbo].[WorkoutSessions] CHECK CONSTRAINT [FK_WorkoutSessions_WorkoutWeeks_WorkoutWeekId]
GO
ALTER TABLE [dbo].[WorkoutWeeks]  WITH CHECK ADD  CONSTRAINT [FK_WorkoutWeeks_WorkoutPlans_WorkoutPlanId] FOREIGN KEY([WorkoutPlanId])
REFERENCES [dbo].[WorkoutPlans] ([WorkoutPlanId])
GO
ALTER TABLE [dbo].[WorkoutWeeks] CHECK CONSTRAINT [FK_WorkoutWeeks_WorkoutPlans_WorkoutPlanId]
GO
USE [master]
GO
ALTER DATABASE [SmartPTUI] SET  READ_WRITE 
GO
