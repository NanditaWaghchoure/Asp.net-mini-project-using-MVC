/****** Script for SelectTopNRows command from SSMS  ******/

  select *from [Sample1].[dbo].[tbEmployee]
  CREATE PROCEDURE spGetAllEmployees
  AS 
  BEGIN
       Select Id, Name, City, DateOfBirth from [Sample1].[dbo].[tbEmployee]
   End