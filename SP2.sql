select * from [Sample1].[dbo].[tbEmployee]


create procedure spAddEmployee
@Name nchar(10),
@City nchar(10),
@DateOfBirth DateTime

as 
Begin
 Insert into [Sample1].[dbo].[tbEmployee](Name,City,DateOfBirth)
 values(@Name,@City,@DateOfBirth)
 End