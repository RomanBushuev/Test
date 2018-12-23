create database colors;

go
use colors;
create sequence ids
 as [int]
 start with 1
 increment by 1
 cache 1000;
 
go
use colors;
create table colors(
	id_colour int primary key constraint colors_id default next value for ids,
	title varchar(max) unique)