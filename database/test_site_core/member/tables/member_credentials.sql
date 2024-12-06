create table member.member_credentials (
	member_credentials_id serial primary key
,	member_id int references member.member(member_id) not null
,	hashed_password varchar(100)
);
