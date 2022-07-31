CREATE TABLE [dbo].[Teacher]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [NationalCode] INT NOT NULL, 
    [Age] INT NOT NULL, 
    [Mobile] INT NOT NULL
)
