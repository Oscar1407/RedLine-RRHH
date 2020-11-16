use [RedLine-DataBase]
go

--tabla de los aspirantes registrados
create table [Aspirante]
(
idAspirante varchar(25) not null primary key,
cedula varchar(25) not null,
nombre varchar(25) not null,
primerApellido varchar(25) not null,
segundoApellido varchar(25) not null,
descripcion varchar (200) not null,
puestoAspirar varchar (50) not null
)
go

--tabla para el correo del aspirante
create table [CorreoAspirante]
(
idAspirante varchar(25) not null,
correo varchar(100),
primary key(idAspirante, correo),
constraint fk_correoAspirante foreign key (idAspirante) references [Aspirante] (idAspirante)
)
go

--tabla para el telefono del aspirante
create table [TelefonoAspirante]
(
idAspirante varchar(25) not null,
telefono varchar(15),
primary key(idAspirante, telefono),
constraint fk_telefonoAspirante foreign key (idAspirante) references [Aspirante] (idAspirante)
)
go

--procedimientos almacenados para agregar nuevos colaboradores
create procedure [PA_Ins_Aspirante]
(
@idAspirante varchar(25),
@cedula varchar(25),
@nombre varchar(25),
@primerApellido varchar(25),
@segundoApellido varchar(25),
@descripcion varchar (200),
@puestoAspirar varchar (50)
)
as
insert into [Aspirante](idAspirante, cedula, nombre, primerApellido, segundoApellido, descripcion, puestoAspirar)
values(@idAspirante, @cedula, @nombre, @primerApellido, @segundoApellido, @descripcion, @puestoAspirar)
go


--Correo
create procedure [PA_Ins_CorreoAspirante]
(
@idAspirante varchar(25),
@correo varchar(100)
)
as
insert into [CorreoAspirante](idAspirante, correo)
values(@idAspirante, @correo)
go
--Telefono
create procedure [PA_Ins_TelefonoAspirante]
(
@idAspirante varchar(25),
@telefono varchar(100)
)
as
insert into [TelefonoAspirante](idAspirante, telefono)
values(@idAspirante, @telefono)
go

--Procedimiento para consultar la existencia de un aspirante
create procedure [PA_Cns_Aspirantes](@idAspirante varchar(25))
as
select a.idAspirante as idAspirante,
a.cedula as Cedula,
a.nombre as Nombre,
a.primerApellido as Primer_Apellido,
a.segundoApellido as Segundo_Apellido,
t.telefono as Telefono,
c.correo as Correo,
a.puestoAspirar as Puesto_a_Aspirar,
a.descripcion as Descripcion
from [Aspirante] a with(nolock)
inner join [CorreoAspirante] c with(nolock) on c.idAspirante = a.idAspirante
inner join [TelefonoAspirante] t with(nolock) on t.idAspirante = a.idAspirante
where a.idAspirante = @idAspirante
go

select * from Aspirante

drop procedure [PA_Cns_Aspirantes]

insert into Aspirante values ('B61126', '116420357','Fabian','Bolaños','Muñoz','Joven, recien egresado','Analista de sistemas');
insert into CorreoAspirante values ('B61126','fabm16@hotmail.com');
insert into TelefonoAspirante values ('B61126', '62740524');

exec [PA_Cns_Aspirantes] @idAspirante ='B61126'
go

-- Procedimiento almacenado para consultar los empleados de la nómina
create procedure [PA_Cns_NominaDespidos](@IDInstitucional varchar(25))
as
select n.IDInstitucional as ID_Institucional,
n.cedula as Cedula,
n.nombre as Nombre,
n.primerApellido as Primer_Apellido,
n.segundoApellido as Segundo_Apellido,
c.correo as Correo,
t.telefono as Telefono,
n.puestoTrabajo as Puesto_trabajo
from [Nomina] n with(nolock)
inner join [NominaCorreo] c with(nolock) on c.IDInstitucional = n.IDInstitucional
inner join [NominaTelefono] t with(nolock) on t.IDInstitucional = n.IDInstitucional
where n.IDInstitucional = @IDInstitucional
go

--tabla de los colaboradores despidos registrados
create table [Despido]
(
idColaborador varchar(25) not null primary key,
cedula varchar(25) not null,
nombre varchar(25) not null,
primerApellido varchar(25) not null,
segundoApellido varchar(25) not null,
motivo varchar (200) not null,
puesto varchar (50) not null,
fechaDespido datetime not null,
)
go


--tabla para el correo del colaborador despedido
create table [CorreoDespido]
(
idColaborador varchar(25) not null,
correo varchar(100),
primary key(idColaborador, correo),
constraint fk_correoDespido foreign key (idColaborador) references [Despido] (idColaborador)
)
go

--tabla para el telefono del colaborador despedido
create table [TelefonoDespido]
(
idColaborador varchar(25) not null,
telefono varchar(15),
primary key(idColaborador, telefono),
constraint fk_telefonoDespido foreign key (idColaborador) references [Despido] (idColaborador)
)
go


--procedimientos almacenados para agregar nuevos despidos
create procedure [PA_Ins_Despido]
(
@idColaborador varchar(25),
@cedula varchar(25),
@nombre varchar(25),
@primerApellido varchar(25),
@segundoApellido varchar(25),
@puesto varchar (50),
@motivo varchar (200),
@fechaDespido datetime
)
as
insert into [Despido](idColaborador, cedula, nombre, primerApellido, segundoApellido, motivo, puesto, fechaDespido)
values(@idColaborador, @cedula, @nombre, @primerApellido, @segundoApellido, @motivo, @puesto, @fechaDespido)
go

--Correo
create procedure [PA_Ins_CorreoDespido]
(
@idColaborador varchar(25),
@correo varchar(100)
)
as
insert into [CorreoDespido](idColaborador, correo)
values(@idColaborador, @correo)
go
--Telefono
create procedure [PA_Ins_TelefonoDespido]
(
@idColaborador varchar(25),
@telefono varchar(100)
)
as
insert into [TelefonoDespido](idColaborador, telefono)
values(@idColaborador, @telefono)
go


-- Procedimiento para buscar despidos por fechas
if ( exists(select name from dbo.sysobjects where name = 'Sp_Cns_Despidos_X_Fechas'))
drop procedure [Sp_Cns_Despidos_X_Fechas]
go
create  procedure [Sp_Cns_Despidos_X_Fechas](
@fechaInicial datetime,
@fechaFinal datetime)
as
select  
d.idColaborador, 
d.cedula, 
d.nombre, 
d.primerApellido, 
d.segundoApellido,
d.motivo,
d.puesto,
d.fechaDespido,
c.correo,
t.telefono
from  Despido d with(nolock)
inner join [CorreoDespido] c with(nolock) on c.idColaborador = d.idColaborador
inner join [TelefonoDespido] t with(nolock) on t.idColaborador = d.idColaborador
where  d.fechaDespido between @fechaInicial and  @fechaFinal
order by  d.fechaDespido
go

select * from Despido
--procedimiento para comprobar existencia de un despido repetido
create procedure [PA_Cns_ExistenciaDespido](@idColaborador varchar(25))
as
select count(*) as existe from [Despido] where idColaborador = @idColaborador
go

exec [PA_Cns_ExistenciaDespido] @idColaborador = 'B88543'
go

delete from CorreoDespido
delete from TelefonoDespido
delete from Despido

select * from Despido

--procedimientos almacenados para eliminar un colaborador de la nómina desde el modulo de contrataciones y despidos
create procedure [PA_Eli_ColaboradorNomina](@IDInstitucional varchar(25))
as
delete from [Nomina] where IDInstitucional = @IDInstitucional
go

create procedure [PA_Eli_ColaboradorCorreoNomina](@IDInstitucional varchar(25))
as
delete from [NominaCorreo] where IDInstitucional = @IDInstitucional
go

create procedure [PA_Eli_ColaboradorTelefonoNomina](@IDInstitucional varchar(25))
as
delete from [NominaTelefono] where IDInstitucional = @IDInstitucional
go

create procedure [PA_Eli_ColaboradorHorarioNomina](@IDInstitucional varchar(25))
as
delete from [HorarioNomina] where IDInstitucional = @IDInstitucional
go

create procedure [PA_Eli_ColaboradorDeduccionLaboralNomina](@IDInstitucional varchar(25))
as
delete from [DeduccionLaboral] where IDInstitucional = @IDInstitucional
go

create procedure [PA_Eli_ColaboradorDeduccionLaboralNomina](@IDInstitucional varchar(25))
as
delete from [DeduccionLaboral] where IDInstitucional = @IDInstitucional
go

create procedure [PA_Eli_ColaboradorAguinaldolNomina](@IDInstitucional varchar(25))
as
delete from [Aguinaldo] where IDInstitucional = @IDInstitucional
go

create procedure D(@IDInstitucional varchar(25))
as
delete from [DeduccionAguinaldo] where IDInstitucional = @IDInstitucional
go

select * from Aspirante

drop procedure [PA_Cns_ListaAspirantes]

--procedimiento almacenado para consultar lista de despidos por puesto
create procedure [PA_Cns_ListaAspirantes] (@puestoTrabajo varchar(100))
as
select n.idAspirante as idAspirante,
n.cedula as Cedula,
n.nombre as Nombre,
n.primerApellido as Primer_Apellido,
n.segundoApellido as Segundo_Apellido,
c.correo as Correo,
t.telefono as Telefono,
n.puestoAspirar as Puesto_Concurso,
n.descripcion
from [Aspirante] n with(nolock)
inner join [CorreoAspirante] c with(nolock) on c.idAspirante = n.idAspirante
inner join [TelefonoAspirante] t with(nolock) on t.idAspirante = n.idAspirante
where n.puestoAspirar = @puestoTrabajo
go


exec [PA_Cns_ListaAspirantes] @puestoTrabajo = 'Administrador de bases de datos'
go

select * from Despido