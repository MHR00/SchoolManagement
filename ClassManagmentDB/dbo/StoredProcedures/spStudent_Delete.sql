CREATE PROCEDURE [dbo].[spStudent_Delete]
	@Id int
AS
begin
		delete
		from dbo.[Student]
		where Id=@Id;

end
