CREATE PROCEDURE checkLogin
@username varchar(20),
@password varchar(30)
AS
begin
declare @count int
declare @res bit
	select @count = count(*) from [User] where Username = @username AND [Password] = @password
	if @count > 0
		set @res = 1
	else 
		set @res = 0
	select @res
end


select * from [User] where Username = 'admin' and [Password] = 'admin'