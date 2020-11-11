use [RedLine-DataBase]
go
--tabla de los usuarios
use [RedLine-DataBase]
go
create table[Usuarios]
(
IDInstitucional varchar(25) not null primary key,
contrasenia varchar(100) not null,
rol varchar(50)
)
go

drop table Usuarios
go

--valores predeterminados de los usuarios
insert into Usuarios(IDInstitucional, contrasenia, rol)
values('B65275', 'oscar', 'Administrador Capacitaciones')
go

insert into Usuarios(IDInstitucional, contrasenia, rol)
values('B77064', 'roy', 'Administrador Nomina')
go

insert into Usuarios(IDInstitucional, contrasenia, rol)
values('B61126', 'fabian', 'Administrador Contrataciones')
go

select * from Usuarios
go

--procedimiento almacenado para el intento de autenticación
create procedure [PA_IntentoAutenticacion](@ID varchar(25), @password varchar(100), @perfil varchar(50))
as select u.IDInstitucional, u.contrasenia, u.rol from Usuarios u with(nolock)
where rtrim(ltrim(@ID)) = rtrim(ltrim(u.IDInstitucional)) and rtrim(ltrim(@password)) = rtrim(ltrim(u.contrasenia)) and rtrim(ltrim(@perfil)) = rtrim(ltrim(u.rol))
go

select * from Usuarios;