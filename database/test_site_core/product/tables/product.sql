create table product.product (
	product_id serial primary key
,	item_number varchar(20)
,	product_name varchar(50)
,	product_description text
,	quantity int
,	cost int
,	unit_price int
);
