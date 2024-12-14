create table email.product_in_stock_email_subscriber(
	product_in_stock_email_subscriber_id serial primary key
,	product_id int references product.product(product_id) 
,	email_address varchar(50) 
,	is_sent boolean
);
