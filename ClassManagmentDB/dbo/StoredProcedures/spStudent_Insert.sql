﻿CREATE PROCEDURE [dbo].[spStudent_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@NationalCode int,
	@Mobile int,
	@RegisterDate DATETIME2
AS
begin
		insert into dbo.[Student] (FirstName, LastName, NationalCode , Mobile,RegisterDate)
		values (@FirstName,@LastName,@NationalCode,@Mobile,@RegisterDate);
end
