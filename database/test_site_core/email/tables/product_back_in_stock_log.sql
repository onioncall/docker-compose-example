create table email.product_back_in_stock_log (
	product_back_in_stock_log_id serial primary key
,	product_id references product.product(product_id) int
,	email_address varchar(100) not null
,	IsSent boolean
);
