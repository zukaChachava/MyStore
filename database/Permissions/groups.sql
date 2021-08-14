-- Groups
use MyStore
go

insert into Groups (Name, Description)
values ('Admin', 'Main User which controls other users, Providers, Categories');

insert into Groups (Name, Description)
values ('Cashier', 'User which sells products');

insert into Groups (Name, Description)
values ('Manager', 'User which can edit product flow in store');

insert into Groups (Name, Description)
values ('Supply Manager', 'User which controls import in store');
