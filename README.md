# DapperHelper

This is the Example branch! Here you can see some examples of how the DapperHelper can be implemented.  
If you want to read more about how the implementation works, [Check Out The Main Branch!](https://github.com/uhyeay2/DapperHelper/tree/main)

## DapperHelper.ExampleDatabase

This is a SqlServer Database Project - it holds a single Person table. If you clone the project you could Publish this project to your local database - or if it's easier you can just copy/paste the Create Table script from the Person.sql file.

## DapperHelper.ExampleConsumer

This is an Example of a project that would consume the Dapper Helper.  
Two simple folders, DapperRequests and DataTransferObjects. The requests implement the IDapperRequest interface to define their Parameters and InlineSql. DataTransferObject (DTO) is a representation of what the Query would return.

## DapperHelper.ExampleTests

This project has some tests so you can see how the IHandleInlineSql can be used. There's some basic tests set up to make sure all the requests worked.  
This test project was set up using xUnit. Here's a list of the tests created:

- GetPerson_Given_NoPersonExists_Should_ReturnNull
- GetPerson_Given_PersonExists_Should_ReturnPerson
- IsPlayerGuidTaken_Given_GuidTaken_Should_ReturnTrue
- IsPlayerGuidTaken_Given_GuidNotTaken_Should_ReturnFalse
- InsertPerson_Given_PersonIsInserted_Should_ReturnOne
- DeletePerson_Given_NoPersonExists_Should_ReturnZero
