The app consists of Two Parts :
1- Back end side using .Net 8 ( The solution contains 5 projects )
MyApp.WebAPI ---> has controllers and API end points and global excpetion handling middleware
MyApp.Application ----> has DTOs , Services to encapsulate business logic
MyApp.Common ---> Contains any constants , helper methods and extensions to be used across all the solution 
MyApp.Infrastructure ---> contains the Db context based on Entity framwork Code first approach , it contains also the implementaion to the Reposatory of Employee Entity , also contains the migration file
MyApp.Domain ---> this is the domain entity which is the Employee and the interfaces needed like IEmployeeRepostaory

libraries used : Entity Framework -  AutoMapper

2- Frond end side using Angular 8.2.14
It Contains Two modules 
employee Module ----> has 2 components ( employeesList - employeesAddEdit)
home module ---> has 1 component ( landing page )

Libraries used : Angular material for UI components and better layout 


The app is named ( MyApp ) and it is used to manage Employees entity ( Add- Edit - Update - Delete)
There is an initial migration in the infrastructure project that will create the main Employees Table 

I didn't have time to implement authentication and autorization , but will do it as a future enhancment. 

