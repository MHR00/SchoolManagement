CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [NationalCode] BIGINT NOT NULL, 
    [Mobile] BIGINT NOT NULL, 
    [RegisterDate] DATETIME2 NOT NULL DEFAULT GETDATE(), 

	
)
