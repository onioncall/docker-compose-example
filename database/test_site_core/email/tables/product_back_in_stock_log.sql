create table email.product_back_in_stock_log (
  product_back_in_stock_log_id serial primary key
,	product_base_id varchar(50)
,	email_address varchar(100) not null
);
