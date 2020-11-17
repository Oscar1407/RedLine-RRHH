use [RedLine-DataBase]
go
--tabla de los colaboradores registrados para capacitaciones
create table [ColaboradorCapacitacion]
(
IDInstitucional varchar(25) not null primary key,
cedula varchar(25) not null,
nombre varchar(25) not null,
primerApellido varchar(25) not null,
segundoApellido varchar(25) not null,
constraint fk_colaborador foreign key (IDInstitucional) references [Nomina] (IDInstitucional)
)
go

delete from [ColaboradorCapacitacion]
go

--tabla para el correo del colaborador
create table [CorreoColaboradorCapacitaciones]
(
IDInstitucional varchar(25) not null,
correo varchar(100),
primary key(IDInstitucional, correo),
constraint fk_colaboradorCorreo foreign key (IDInstitucional) references [ColaboradorCapacitacion] (IDInstitucional)
)
go

delete from [CorreoColaboradorCapacitaciones]
go


--tabla para el telefono del colaborador
create table [TelefonoColaboradorCapacitaciones]
(
IDInstitucional varchar(25) not null,
telefono varchar(15),
primary key(IDInstitucional, telefono),
constraint fk_colaboradorTelefono foreign key (IDInstitucional) references [ColaboradorCapacitacion] (IDInstitucional)
)
go

delete from [TelefonoColaboradorCapacitaciones]
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
primary key (IDCurso, dia),
constraint fk_d_HorarioCurso foreign key (IDCurso) references [Curso] (IDCurso)
)
go


--tabla de la matricula
create table [Matricula]
(
IDMatricula int identity(1,1) not null primary key,
IDCurso varchar(25) not null,
IDInstitucional varchar(25) not null,
estado varchar(25) not null default 'En curso',
periodo varchar(25) not null
constraint fk_curso foreign key (IDCurso) references [Curso] (IDCurso),
constraint fk_colaboradorCapacitaciones foreign key (IDInstitucional) references [ColaboradorCapacitacion] (IDInstitucional)
)
go

delete from [Matricula]
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

--procedimiento almacenado para consultar lista de colaboradores
create procedure [PA_Cns_ListaColaboradores]
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
go

--procedimientos almacenados para modificar informacion de los colaboradores
create procedure [PA_Act_Colaborador]
(
@IDInstitucional varchar(25),
@cedula varchar(25),
@nombre varchar(25),
@primerApellido varchar(25),
@segundoApellido varchar(25))
as 
update [ColaboradorCapacitacion] set
cedula = @cedula,
nombre = @nombre,
primerApellido = @primerApellido,
segundoApellido = @segundoApellido
where IDInstitucional = @IDInstitucional
go

create procedure [PA_Act_ColaboradorCorreo]
(
@IDInstitucional varchar(25),
@correo varchar(100))
as
update [CorreoColaboradorCapacitaciones] set
correo = @correo
where IDInstitucional = @IDInstitucional
go

create procedure [PA_Act_ColaboradorTelefono]
(
@IDInstitucional varchar(25),
@telefono varchar(15))
as
update [TelefonoColaboradorCapacitaciones] set
telefono = @telefono
where IDInstitucional = @IDInstitucional
go

--procedimientos almacenados para eliminar un colaborador
create procedure [PA_Eli_Colaborador](@IDInstitucional varchar(25))
as
delete from [ColaboradorCapacitacion] where IDInstitucional = @IDInstitucional
go

create procedure [PA_Eli_ColaboradorCorreo](@IDInstitucional varchar(25))
as
delete from [CorreoColaboradorCapacitaciones] where IDInstitucional = @IDInstitucional
go

create procedure [PA_Eli_ColaboradorTelefono](@IDInstitucional varchar(25))
as
delete from [TelefonoColaboradorCapacitaciones] where IDInstitucional = @IDInstitucional
go

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--procedimientos almacenados para el modulo de cursos

--procedimiento almacenado para guardar cursos
create procedure [PA_Ins_Curso]
(
@IDCurso varchar(25),
@nombreCurso varchar(50),
@duracion varchar(45))
as
insert into [Curso](IDCurso, nombreCurso, duracion)
values(@IDCurso, @nombreCurso, @duracion)
go

--procedimiento para consultar un curso por ID
create procedure [PA_Cns_ExistenciaCurso](@IDCurso varchar(25))
as
select count(*) from [Curso] where IDCurso = @IDCurso
go

--procedimiento para consultar la información de un curso
create procedure [PA_Cns_Curso](@IDCurso varchar(25))
as
select IDCurso as Identificador,
nombreCurso as Nombre_del_curso,
duracion as Duración
from [Curso]
where IDCurso = @IDCurso
go

--procedimiento para listar los horarios
create procedure [PA_Cns_Horario](@IDCurso varchar(25))
as
select IDCurso as Identificador,
dia as Día,
horaInicio as Hora_inicio,
horaFin as Hora_fin
from [HorarioCurso]
where IDCurso = @IDCurso
go

--procedimientos para eliminar un curso
create procedure [PA_Eli_Curso](@IDCurso varchar(25))
as
delete from [Curso] where IDCurso = @IDCurso
go

create procedure [PA_Eli_CursoHorario](@IDCurso varchar(25))
as
delete from [HorarioCurso] where IDCurso = @IDCurso
go

--procedimiento para almacenar los horarios de un curso
create procedure [PA_Ins_Horario]
(
@IDCurso varchar(25),
@dia varchar(15),
@horaInicio int,
@horaFin int
)
as
insert into [HorarioCurso](IDCurso, dia, horaInicio, horaFin)
values(@IDCurso, @dia, @horaInicio, @horaFin)
go

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--procedimientos almacenados para las matriculas

--procedimiento almacenado para agregar a la matricula
create procedure [PA_Ins_Matricula]
(
@IDCurso varchar(25),
@IDInstitucional varchar(25),
@estado varchar(25),
@periodo varchar(25)
)
as insert into [Matricula]
values (@IDCurso, @IDInstitucional, @estado, @periodo)
go

--procedimiento almacenado para consultar por ID Curso
create procedure [PA_Cns_Matricula](@IDCurso varchar(25))
as
select c.IDInstitucional as ID_Institucional,
c.cedula as Cedula,
c.nombre as Nombre,
c.primerApellido as Primer_Apellido,
c.segundoApellido as Segundo_Apellido,
a.IDCurso as ID_Curso,
a.nombreCurso as Nombre_Curso,
m.estado as Estado
from [Matricula] m with(nolock)
inner join [ColaboradorCapacitacion] c with(nolock) on c.IDInstitucional = m.IDInstitucional
inner join [Curso] a with(nolock) on a.IDCurso = m.IDCurso
where m.IDCurso = @IDCurso
go

--procedimiento almacenado para consultar el estado de la matrícula
create procedure [PA_Cns_MatriculaEstado](@IDInstitucional varchar(25))
as
select c.IDInstitucional,
c.cedula,
c.nombre,
c.primerApellido,
c.segundoApellido,
e.correo,
t.telefono,
a.IDCurso,
a.nombreCurso,
a.duracion,
m.periodo,
m.estado
from [Matricula] m with(nolock)
inner join [ColaboradorCapacitacion] c with(nolock) on c.IDInstitucional = m.IDInstitucional
inner join [CorreoColaboradorCapacitaciones] e with(nolock) on e.IDInstitucional = m.IDInstitucional
inner join [TelefonoColaboradorCapacitaciones] t with(nolock) on t.IDInstitucional = m.IDInstitucional
inner join [Curso] a with(nolock) on a.IDCurso = m.IDCurso
where c.IDInstitucional = @IDInstitucional
go

create procedure [PA_Act_EstadoMatricula](@IDCurso varchar(25), @IDInstitucional varchar(25), @estado varchar(25))
as
update [Matricula] set
estado = @estado
where IDCurso = @IDCurso and IDInstitucional = @IDInstitucional
go

