CREATE PROCEDURE [dbo].[spStudent_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@NationalCode bigint,
	@Mobile bigint,
	@RegisterDate DATETIME2
AS
begin
		update dbo.[Student]
		set FirstName=@FirstName,LastName=@LastName,NationalCode=@NationalCode,Mobile=@Mobile,RegisterDate=@RegisterDate
		where Id=@Id;
end
