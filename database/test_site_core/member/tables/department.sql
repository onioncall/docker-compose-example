create table member.department (
	department_id serial primary key
,	department_name varchar(100) not null
);

insert into member.department(department_name)
values 
	('Other')
,	('Product');
