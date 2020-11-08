use [RedLine-DataBase]
go
--tabla de los colaboradores registrados para capacitaciones
create table [ColaboradorCapacitacion]
(
IDInstitucional varchar(25) not null primary key,
cedula varchar(25) not null,
nombre varchar(25) not null,
primerApellido varchar(25) not null,
segundoApellido varchar(25) not null
)
go

drop table [ColaboradorCapacitacion]

select * from [ColaboradorCapacitacion]

--tabla para el correo del colaborador
create table [CorreoColaboradorCapacitaciones]
(
IDInstitucional varchar(25) not null,
correo varchar(100) not null,
primary key(IDInstitucional, correo),
constraint fk_colaboradorCorreo foreign key (IDInstitucional) references [ColaboradorCapacitacion] (IDInstitucional)
)
go

select * from [CorreoColaboradorCapacitaciones]
go

drop table [CorreoColaboradorCapacitaciones]
go

--tabla para el telefono del colaborador
create table [TelefonoColaboradorCapacitaciones]
(
IDInstitucional varchar(25) not null,
telefono varchar(15) not null,
primary key(IDInstitucional, telefono),
constraint fk_colaboradorTelefono foreign key (IDInstitucional) references [ColaboradorCapacitacion] (IDInstitucional)
)
go

select * from [TelefonoColaboradorCapacitaciones]
go

drop table [TelefonoColaboradorCapacitaciones]
go

delete from [ColaboradorCapacitacion] 
go

--tabla de los cursos de las capacitaciones
create table [Curso]
(
IDCurso varchar(25) not null primary key,
nombreCurso varchar(50) not null,
duracion varchar(45) not null
)
go

--tabla de los horarios del curso de las capacitaciones
create table [HorarioCurso]
(
IDCurso varchar(25),
dia varchar(15),
horaInicio int,
horaFin int,
constraint fk_d_HorarioCurso foreign key (IDCurso) references [Curso] (IDCurso)
)
go

--tabla de la matricula
create table [Matricula]
(
IDMatricula varchar(25) not null primary key,
IDCurso varchar(25) not null,
IDInstitucional varchar(25) not null,
estado varchar(25) not null,
periodo varchar(25) not null
constraint fk_curso foreign key (IDCurso) references [Curso] (IDCurso),
constraint fk_colaborador foreign key (IDInstitucional) references [ColaboradorCapacitacion] (IDInstitucional)
)
go

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--procedimientos almacenados del modulo de capacitaciones

--procedimientos almacenados para agregar nuevos colaboradores
create procedure [PA_Ins_Colaborador]
(
@IDInstitucional varchar(25),
@cedula varchar(25),
@nombre varchar(25),
@primerApellido varchar(25),
@segundoApellido varchar(25)
)
as
insert into [ColaboradorCapacitacion](IDInstitucional, cedula, nombre, primerApellido, segundoApellido)
values(@IDInstitucional, @cedula, @nombre, @primerApellido, @segundoApellido)
go

create procedure [PA_Ins_ColaboradorCorreo]
(
@IDInstitucional varchar(25),
@correo varchar(100)
)
as
insert into [CorreoColaboradorCapacitaciones](IDInstitucional, correo)
values(@IDInstitucional, @correo)
go

create procedure [PA_Ins_ColaboradorTelefono]
(
@IDInstitucional varchar(25),
@telefono varchar(100)
)
as
insert into [TelefonoColaboradorCapacitaciones](IDInstitucional, telefono)
values(@IDInstitucional, @telefono)
go

--procedimiento para comprobar existencia de un colaborador repetido
create procedure [PA_Cns_ExistenciaColaborador](@IDInstitucional varchar(25))
as
select count(*) as existe from [ColaboradorCapacitacion] where IDInstitucional = @IDInstitucional
go

exec [PA_Cns_ExistenciaColaborador] @IDInstitucional = '1'
go

--procedimiento almacenado para consultar colaborador por IDInstitucional
create procedure [PA_Cns_Colaboradores](@IDInstitucional varchar(25))
as
select c.IDInstitucional as ID_Institucional,
c.cedula as Cedula,
c.nombre as Nombre,
c.primerApellido as Primer_Apellido,
c.segundoApellido as Segundo_Apellido,
e.correo as Correo,
t.telefono as Telefono
from [ColaboradorCapacitacion] c with(nolock)
inner join [CorreoColaboradorCapacitaciones] e with(nolock) on e.IDInstitucional = c.IDInstitucional
inner join [TelefonoColaboradorCapacitaciones] t with(nolock) on t.IDInstitucional = c.IDInstitucional
where c.IDInstitucional = @IDInstitucional
go

