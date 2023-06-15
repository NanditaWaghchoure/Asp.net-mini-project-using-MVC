select * from [Sample1].[dbo].[tbEmployee]

create procedure spSaveEmployee
@Id int,
@Name nchar(10),
@City nchar(10),
@DateOfBirth DateTime

as 
Begin
 Update [Sample1].[dbo].[tbEmployee]
 Set Name=@Name,City=@City,DateOfBirth=@DateOfBirth
 where Id = @Id
 End