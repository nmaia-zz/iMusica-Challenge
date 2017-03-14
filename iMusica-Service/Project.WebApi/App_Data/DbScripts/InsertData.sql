
insert into [Role] values ((select NEWID()), 'Business Analyst')
insert into [Role] values ((select NEWID()), 'System Analyst')
insert into [Role] values ((select NEWID()), 'Project Manager')
insert into [Role] values ((select NEWID()), 'IT Director')
insert into [Role] values ((select NEWID()), 'Human Resource')

-- change the last column for new Guids from Role table
insert into Employee values ((select NEWID()), 'Joao da Silva', 'josilva@mail.com', '19870210', 'Male', '24E4FA79-8330-4B55-90E6-CD2FC8C959BC');
insert into Employee values ((select NEWID()), 'Ana Beatriz Muniz', 'amuniz@mail.com', '19840312', 'Female', '19305936-E8F7-4C3B-A524-AC1B3FAA5A13');

-- change the last column for new Guids from Employee table
insert into [Dependent] values ((select NEWID()), 'Bruna da Silva', '6506FAB7-2C26-4736-B16C-AD26F02B29CA');
insert into [Dependent] values ((select NEWID()), 'Jackson da Silva', '6506FAB7-2C26-4736-B16C-AD26F02B29CA');
insert into [Dependent] values ((select NEWID()), 'Danilo Silvestre', '6506FAB7-2C26-4736-B16C-AD26F02B29CA');
