-- GroupPermissions
-- Admin
Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 1);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 7);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 10);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 11);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 17);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 20);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 21);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 30);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 31);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 2);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 12);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 22);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 3);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 13);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 23);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 33);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 4);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 14);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 24);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 34);

Insert into GroupPermissions (GroupID, PermissionCode)
values (1, 32);

-- Cashier

Insert into GroupPermissions (GroupID, PermissionCode)
values (2, 8);

Insert into GroupPermissions (GroupID, PermissionCode)
values (2, 18);

Insert into GroupPermissions (GroupID, PermissionCode)
values (2, 9);

Insert into GroupPermissions (GroupID, PermissionCode)
values (2, 19);

-- Manager

Insert into GroupPermissions (GroupID, PermissionCode)
values (3, 5);

Insert into GroupPermissions (GroupID, PermissionCode)
values (3, 25);

Insert into GroupPermissions (GroupID, PermissionCode)
values (3, 6);

Insert into GroupPermissions (GroupID, PermissionCode)
values (3, 26);

Insert into GroupPermissions (GroupID, PermissionCode)
values (3, 8);

Insert into GroupPermissions (GroupID, PermissionCode)
values (3, 28);

Insert into GroupPermissions (GroupID, PermissionCode)
values (3, 9);

Insert into GroupPermissions (GroupID, PermissionCode)
values (3, 29);

-- Supply Manager

Insert into GroupPermissions (GroupID, PermissionCode)
values (4, 5);

Insert into GroupPermissions (GroupID, PermissionCode)
values (4, 15);

Insert into GroupPermissions (GroupID, PermissionCode)
values (4, 25);

Insert into GroupPermissions (GroupID, PermissionCode)
values (4, 6);

Insert into GroupPermissions (GroupID, PermissionCode)
values (4, 16);

Insert into GroupPermissions (GroupID, PermissionCode)
values (4, 26);
go

-- Group Permission Function

create function GetPermissionById_F(@UserId int)
returns table
as
    return
        select P.PermissionCode, p.Description
        from UserGroups UG join Groups G on UG.GroupID = G.ID
        join GroupPermissions GP on G.ID = GP.GroupID
        join Permissions P on GP.PermissionCode = P.PermissionCode
        where UG.UserID = @UserId
go

-- Add Standart User

insert into Employees values ('Admin', 'Adminovich', '62402004578', '593354578',
                                'Admin@gmail.com', 'Tbilisi', '2021-06-05', null, 0);

insert into Users (Id, Username, Password) values (1, 'Admin',  hashbytes('MD5', 'Admin1234'));

insert into UserGroups (UserID, GroupID) values (1, 1);
