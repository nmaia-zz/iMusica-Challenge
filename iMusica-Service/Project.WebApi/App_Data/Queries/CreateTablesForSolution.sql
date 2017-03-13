go
create table Employee (
	IdEmployee uniqueidentifier,
	[Name] varchar(100) not null,
	Email varchar(100),
	BirthDate datetime,
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