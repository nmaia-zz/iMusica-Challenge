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
