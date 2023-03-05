# DapperHelper

This project is a barebones Class Library of a pattern I have created for using Dapper.  
The main branch is left without any examples of the pattern being used.  
If you would like to see how it can be implemented, [Check Out The Example Branch!](https://github.com/uhyeay2/DapperHelper/tree/Example)  

## Abstraction

This folder is where the contracts are held. This pattern relies on the following contracts:
- IDapperRequest
  - GetParameters() is used to define the Parameters a request object would use. Return null if no parameters.
  - GetSql() is used to define the Sql Query or StoredProcedure Name a request object would use.
- IDapperRequest < TResponse >
  - Inherits methods from IDapperRequest.
  - Used to define what Type of response that Dapper will Fetch/FetchList of.
- IDapperHandler
  - ExecuteAsync() is used to Execute commands such as Insert, Update, or Delete.
  - FetchAsync() is used to Query for a single record.
  - FetchListAsync() is used to Query for multiple records.
- IHandleStoredProcedures / IHandleInlineSql
  - These interfaces inherit the IDapperHandler methods.
- IDbConnectionFactory
  - NewConnection() is used to return a new IDbConnection for Dapper to use. For example a 'new SqlConnection()'.
  
## Implementation

This folder is where the implementation for the DapperHelper is housed.

- DapperHandler
  - Abstract Class used as a base for InlineSqlHandler and StoredProcHandler.
  - Holds IDbConnectionFactory property and reusable constructor.
- InLineSqlHandler
  - Implements the IHandleInlineSql interface.
  - Uses IDapperRequest to GetSql() and GetParameters() to pass into Dapper methods.
- StoredProcHandler
  - Implements the IHandleStoredProcedures interface.
  - Works Similarly to InlineSqlHandler, but passes in CommandType parameter to Dapper methods.
- SqlConnectionFactory
  - Implements IDbConnectionFactory interface.
  - Returns 'new SqlConnection()' when NewConnection() is called.
  - Optional to use, since you can define your own IDbConnectionFactory to use with your DapperHandlers.
  
## DependencyInjection

In this folder I have the ServiceInjection class which exposes the implementations through their contracts.

- InjectDapperHandler
  - Used for injecting services into IServiceCollection.
  - Pass in your own implementation of IDbConnectionFactory for DapperHandlers to connect to the database with.
  - Adds IDbConnectionFactory as Singleton.
  - Adds IHandleInlineSql as Scoped.
  - Adds IHandleStoredProcedures as Scoped.
- InjectDapperHandlerWithSqlConnectionFactory
  - Use this to inject services with default SqlConnectionFactory.
  - Instead of passing in an implementation of IDbConnectionFactory, pass in your connection string.
- NewSqlConnectionFactory
  - Private helper method.
  - Used to reduce repeated code for creating new instace of SqlConnectionFactory.
- NewSqlHandler
  - Use this to get an instance of IHandleInlineSql if you need an instance without IServiceCollection.
  - Overload so you can get an instance by passing in an IDbConnectionFactory, or by passing in your connection string.
- NewStoredProcHandler
  - Similar to NewSqlHandler, but for getting an instance of IHandleStoredProcedures.
