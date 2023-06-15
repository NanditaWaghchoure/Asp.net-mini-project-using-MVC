Select * from [Sample1].[dbo].[tbEmployee]

Create procedure spDeleteEmployee
@Id int
as 
Begin
     Delete from [Sample1].[dbo].[tbEmployee]
     where Id=@Id
End