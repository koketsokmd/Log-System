
-----------------------------------------------------------------------------
-------------------------  CREATING DATABASE --------------------------------
-----------------------------------------------------------------------------

--- NB. ------------------

-- Create a SQL Folder in the C:\ Then Execute the whole statement from line 10 to line 30

USE[master]
go
CREATE DATABASE [DDNA_DB]

ON PRIMARY
(
  NAME = db_DDNA,
  FILENAME = 'C:\SQL\DDNA_db.mdf',
  SIZE = 50MB,
  MAXSIZE = 100MB,
  FILEGROWTH = 10KB
)

LOG ON
(
  NAME = db_DDNA_Log,
  FILENAME = 'C:\SQL\DDNA_db.ldf',
  SIZE = 50MB,
  MAXSIZE = 100MB,
  FILEGROWTH = 10KB
)


-----------------------------------------------------------------------------
-------------------------  CREATING TABLES --------------------------------
-----------------------------------------------------------------------------


Use[DDNA_DB]
go
create table[Roles]
(
[RoleID] VARCHAR(20) PRIMARY KEY not null,
[RoleName] VARCHAR(50) not null
)


Use[DDNA_DB]
go
create table[Classes]
(
[ClassID] VARCHAR(20) PRIMARY KEY not null,
[Class] VARCHAR(40) not null
)


Use[DDNA_DB]
go
create table[Students]
(
[StudentID] VARCHAR(13) PRIMARY KEY not null,
[Username] VARCHAR(30) not null,
[Password] VARCHAR (30) not null,
[Name] VARCHAR(40) not null,
[Surname] VARCHAR(40) not null,
[RoleID] VARCHAR(20) FOREIGN KEY REFERENCES dbo.[Roles](RoleID),
[ClassID] VARCHAR(20) FOREIGN KEY REFERENCES dbo.[Classes](ClassID)
)


Use[DDNA_DB]
go
create table[Mentors]
(
[MentorID] VARCHAR(13) PRIMARY KEY not null,
[Username] VARCHAR(30) not null,
[Password] VARCHAR (30) not null,
[Name] VARCHAR(40) not null,
[Surname] VARCHAR(40) not null,
[RoleID] VARCHAR(20) FOREIGN KEY REFERENCES dbo.[Roles](RoleID)
)


Use[DDNA_DB]
go
create table[Admin]
(
[ID] INT IDENTITY PRIMARY KEY NOT NULL,
[Username] VARCHAR(30) not null,
[Password] VARCHAR (30) not null,
[RoleID] VARCHAR(20) FOREIGN KEY REFERENCES dbo.[Roles](RoleID)
)


Use[DDNA_DB]
go
create table[Mentor_Eval]
(
[ID] VARCHAR(13) PRIMARY KEY not null,
[StudentID] VARCHAR(13) FOREIGN KEY REFERENCES dbo.[Students](StudentID),
[MentorID] VARCHAR(13) FOREIGN KEY REFERENCES dbo.[Mentors](MentorID),
[Relevance] VARCHAR(12) not null,
[Knowledge] VARCHAR (12) not null,
[Communication] VARCHAR(12) not null,
[Teamwork] VARCHAR(12) not null,
[ProblemSolving] VARCHAR(12) not null,
[FinalJudgement] VARCHAR (12) not null,
[Punctuality] VARCHAR(12) not null,
[Manners] VARCHAR(12) not null,
[Instructions] VARCHAR(12) not null,
[Enthusiasm] VARCHAR (12) not null,
[Workload] VARCHAR(12) not null,
[Adaptibility] VARCHAR(12) not null,
[JobKnowledge] VARCHAR(12) not null,
[PeerTeamwork] VARCHAR (12) not null,
[Assistance] VARCHAR(12) not null,
[Comments] VARCHAR(150) not null,
[LeanerSign] VARCHAR(20) not null,
[MentorSign] VARCHAR(20) not null
)


Use[DDNA_DB]
go
create table[Student_Eval]
(
[ID] VARCHAR(13) PRIMARY KEY not null,
[MentorID] VARCHAR(13) FOREIGN KEY REFERENCES dbo.[Mentors](MentorID),
[StudentID] VARCHAR(13) FOREIGN KEY REFERENCES dbo.[Students](StudentID),
[WorkplaceExperience] VARCHAR(12) not null,
[LearningProcess] VARCHAR (12) not null,
[CommunicationSkills] VARCHAR(12) not null,
[AccomodationOfLearners] VARCHAR(12) not null,
[LearnerProblemSolving] VARCHAR(12) not null,
[FinalJudgement] VARCHAR (12) not null,
[Comments] VARCHAR(150) not null,
[LeanerSign] VARCHAR(20) not null,
[MentorSign] VARCHAR(20) not null

)


Use[DDNA_DB]
go
create table[TBL_Weekly]
(
[ID] INT Identity PRIMARY KEY not null,
[MentorID] VARCHAR(13) FOREIGN KEY REFERENCES dbo.[Mentors](MentorID),
[StudentID] VARCHAR(13) FOREIGN KEY REFERENCES dbo.[Students](StudentID),
[CellPhone] VARCHAR(10) not null,
[LearnershipIntk] VARCHAR (50) not null,
[Date] date not null,
[Task] VARCHAR(50) not null,
[CompletedToSatisifaction] VARCHAR(3) not null,
[Time] VARCHAR (2) not null,
[ProblemsExperienced] VARCHAR(3) not null,
[GeneralComments] VARCHAR(50) not null,
[LeanerSign] VARCHAR(20) not null,
[MentorSign] VARCHAR(20) not null

)


Use[DDNA_DB]
go
create table[Daily_Register]
(
[ID] INT Identity PRIMARY KEY not null,
[StudentID] VARCHAR(13) FOREIGN KEY REFERENCES dbo.[Students](StudentID),
[Date] date not null
)


-----------------------------------------------------------------------------
-------------------------  VIEWS --------------------------------------------
-----------------------------------------------------------------------------

---- Creating View That Adds Everyones Usernames, Id's And Passwords

Use[DDNA_DB]
go
CREATE VIEW vw_LoginInfo
AS 
SELECT UserID, Username, Password, RoleID
FROM
(
  SELECT StudentID AS UserID, Username, Password, RoleID
  From
  dbo.Students
  union all 
  SELECT MentorID AS UserID, Username, Password, RoleID
  from
  dbo.Mentors
  union all 
  SELECT ID AS UserID, Username, Password, RoleID
  from
  dbo.Admin
 ) t    
 group by
 UserID,
 Username,
 Password,
 RoleID


-----------------------------------------------------------------------------
-------------------------  Stored Procedures --------------------------------
-----------------------------------------------------------------------------

--- Procedure For User To Log In

Use[DDNA_DB]
go
CREATE PROCEDURE [dbo].[LoginWithUsernamePassword]   
@dUsername varchar(30),   
@dPassword varchar(30)   
AS   
BEGIN   
SELECT UserID, Username, Password, RoleID   
FROM vw_LoginInfo   
WHERE Username = @dUsername   
AND Password = @dPassword   
END   



