# iMusica-Challenge

This repo was created in order to build a small system to control the employee register via web.

## Branch status

iMusica-Service.sln ![travis-ci](https://travis-ci.org/nmaia/iMusica-Challenge.svg?branch=master)

## We'll use the following stack :point_down:

- [ ] Web Api (Restful) :heart_eyes:
- [ ] N-Hibernate (ORM) :yum:
- [ ] JQuery :eyes:
- [ ] .Net Razor :eyes:
- [x] loading... :hourglass_flowing_sand:

## UML POCO (Plain Old C# Object) Class Digram v1.0

![UML Class Diagram](/Images/ClassDiagram/ClassDiagram_v1.0.png)

## SQL Scripts to create solution tables v1.0

```
go
create table Employee (
	IdEmployee uniqueidentifier,
	[Name] varchar(100) not null,
	Email varchar(100) not null,
	BirthDate datetime not null,
	Genre varchar(6) not null constraint ck_employee_genre check (Genre in ('Female', 'Male')),

	primary key(IdEmployee)
);

go
create table [Role] (
	IdRole uniqueidentifier,
	RoleType varchar(16) not null constraint ck_role_type check (RoleType in ('Business Analyst', 'System Analyst', 'Project Manager', 'IT Director', 'Human Resource')),
	IdEmployee uniqueidentifier not null,

	primary key (IdRole),
	constraint fk_employee_role foreign key (IdEmployee) references Employee(IdEmployee)
);

go
create table [Dependent] (
	IdDependent uniqueidentifier,
	[Name] varchar(100) not null,
	IdEmployee uniqueidentifier not null,

	primary key (IdDependent),
	constraint fk_employee_dependent foreign key (IdEmployee) references Employee(IdEmployee)
);
```
