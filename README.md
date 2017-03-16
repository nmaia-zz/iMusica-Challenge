# iMusica-Challenge

This repo was created in order to build a small system to control the employee register via web.

## Build status

iMusica-Service.sln ![travis-ci](https://travis-ci.org/nmaia/iMusica-Challenge.svg?branch=master)

## We'll use the following stack

- [ ] Web Api (Restful)
- [ ] N-Hibernate (ORM)
- [ ] JQuery 
- [ ] .Net Razor

## Here is some information you need to know in order to test this project locally

- Change the connection string in the web.config file (Project.WebApi)
- Run the solution and make requests using some REST Client (e.g: [Postman](https://www.getpostman.com/))


## UML POCO (Plain Old C# Object) Class Digram v1.1

![UML Class Diagram](/Images/ClassDiagram/ClassDiagram_v1.2.png)

## SQL Scripts (DDL) to create solution tables v2.0

```
go
create table [Role] (
    IdRole uniqueidentifier,
    RoleType varchar(16) not null constraint ck_role_type check (RoleType in ('Business Analyst', 'System Analyst', 'Project Manager', 'IT Director', 'Human Resource')),

    primary key (IdRole)
);

go
create table Employee (
    IdEmployee uniqueidentifier,
    [Name] varchar(100) not null,
    Email varchar(100),
    BirthDate datetime,
    Gender varchar(6) not null constraint ck_employee_genre check (Gender in ('Female', 'Male')),
    IdRole uniqueidentifier not null,

    primary key(IdEmployee),
	constraint fk_role_employee foreign key (IdRole) references [Role](IdRole)
);

go
create table [Dependent] (
    IdDependent uniqueidentifier,
    [Name] varchar(100) not null,
	IdEmployee uniqueidentifier not null

    primary key (IdDependent),
	constraint fk_employee_dependent foreign key (IdEmployee) references Employee(IdEmployee)
);

```

## SQL Scripts (DML) to insert some data v1.0

```
-- [ scripts to create the job roles ] --

insert into [Role] values ((select NEWID()), 'Business Analyst')
insert into [Role] values ((select NEWID()), 'System Analyst')
insert into [Role] values ((select NEWID()), 'Project Manager')
insert into [Role] values ((select NEWID()), 'IT Director')
insert into [Role] values ((select NEWID()), 'Human Resource')

-- [ scripts to create two employees ] --
-- these commands are using an example of guid for the last column (get the correct IdRole in the role table)

insert into Employee values ((select NEWID()), 'Joao da Silva', 'josilva@mail.com', '19870210', 'Male', '24E4FA79-8330-4B55-90E6-CD2FC8C959BC');
insert into Employee values ((select NEWID()), 'Ana Beatriz Muniz', 'amuniz@mail.com', '19840312', 'Female', '19305936-E8F7-4C3B-A524-AC1B3FAA5A13');

-- [ scripts to create the dependents of employees  ] --
-- these commands are using an example of guid for the last column (get the correct IdEmployee in the employee table)

insert into [Dependent] values ((select NEWID()), 'Bruna da Silva', '6506FAB7-2C26-4736-B16C-AD26F02B29CA');
insert into [Dependent] values ((select NEWID()), 'Jackson da Silva', '6506FAB7-2C26-4736-B16C-AD26F02B29CA');
insert into [Dependent] values ((select NEWID()), 'Danilo Silvestre', '6506FAB7-2C26-4736-B16C-AD26F02B29CA');
```
