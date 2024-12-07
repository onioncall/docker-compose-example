create table auth.department (
	department_id serial primary key
,	department_name varchar(100) not null
);

insert into auth.department(department_name)
values 
	('Other')
,	('Product');
