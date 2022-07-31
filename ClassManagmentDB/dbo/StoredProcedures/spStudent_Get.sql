CREATE PROCEDURE [dbo].[spStudent_Get]
	@Id int
AS
begin 
	select Id, FirstName,LastName,NationalCode,Mobile,RegisterDate
	from dbo.[Student]
	where Id=@Id;
		
end
