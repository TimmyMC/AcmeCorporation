CREATE TABLE [dbo].[Submission]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(100) NOT NULL, 
    [SerialNumber] UNIQUEIDENTIFIER NOT NULL 
)
