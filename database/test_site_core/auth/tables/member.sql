create table auth.member (
	member_id serial primary key
,	first_name varchar(50)
,	last_name varchar(50) 
,	email_address varchar(100) not null
,	phone_number varchar(13)
,	username varchar(100)
,	department_id int
);
