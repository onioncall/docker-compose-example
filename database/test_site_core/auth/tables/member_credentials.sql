create table auth.member_credentials (
	member_credentials_id serial primary key
,	member_id int references auth.member(member_id) not null
,	hashed_password varchar(100)
);
