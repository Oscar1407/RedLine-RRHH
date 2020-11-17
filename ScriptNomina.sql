use [RedLine-DataBase]
go

drop database [RedLine-DataBase]
go

--Tabla Nomina
create table [Nomina](
IDInstitucional varchar(25) not null primary key,
cedula varchar(25) not null,
nombre varchar(25) not null,
primerApellido varchar (25) not null,
SegundoApellido varchar (25) not null,
direccion varchar (150) not null,
puestoTrabajo varchar(30) not null,
salarioNeto decimal not null,
salarioBruto decimal not null
)
go

--Tabla NominaTelefono
create table [NominaTelefono](
IDInstitucional varchar (25) not null,
telefono varchar(25) not null
primary key (IDInstitucional, telefono),
constraint fk_nominaTelefono foreign key (IDInstitucional) references [Nomina](IDInstitucional)
)
go


--Tabla HorarioNomina
create table [HorarioNomina](
IDInstitucional varchar (25) not null,
tipoHorario varchar(25)
primary key(IDInstitucional, tipoHorario),
constraint fk_nominaHorario foreign key (IDInstitucional) references [Nomina](IDInstitucional)
)
go

select * from [HorarioNomina]

--Tabla NominaCorreo
create table [NominaCorreo](
IDInstitucional varchar (25) not null,
correo varchar(100) not null
primary key (IDInstitucional, correo),
constraint fk_nominaCorreo foreign key (IDInstitucional) references [Nomina](IDInstitucional)
)
go

--Insert Nomina
Insert into Nomina (IDInstitucional,cedula,nombre, primerApellido,SegundoApellido,direccion, puestoTrabajo, salarioNeto, salarioBruto) values('B77064','604470972','Daniel', 'Sánchez','Chaves', 'Parrita', 'Contador',500000, 800000)
Insert into Nomina (IDInstitucional,cedula,nombre, primerApellido,SegundoApellido,direccion, puestoTrabajo, salarioNeto, salarioBruto) values('B70988',603220198,'Roxana', 'Chaves', 'Sánchez', 'Puntarenas', 'Secretaria', 450000, 650000)
Insert into Nomina (IDInstitucional,cedula,nombre, primerApellido,SegundoApellido,direccion, puestoTrabajo, salarioNeto, salarioBruto) values('B88543',603280015, 'Jesus','Aguero', 'Chaves', 'San José', 'Analista de sistemas', 550000,850000)
select * from Nomina;

delete from nomina
go


--Insert NominaTelefono
Insert into NominaTelefono (IDInstitucional, telefono) values ('B77064','87336588')
Insert into NominaTelefono (IDInstitucional, telefono) values ('B70988','60457689')
Insert into NominaTelefono (IDInstitucional, telefono) values ('B88543','76345798')
select * from NominaTelefono;



--Insert NominaCorreo
Insert into NominaCorreo(IDInstitucional, correo) values ('B77064','chavesdan0@gmail.com')
Insert into NominaCorreo(IDInstitucional, correo) values ('B70988','rox123@gmail.com')
Insert into NominaCorreo(IDInstitucional, correo) values ('B88543','jesuscha@gmail.com')

select * from NominaCorreo;


Insert into HorarioNomina(IDInstitucional, diaLaboral, horaInicio,horaFin) values('B77064','Lunes',7,10)
Insert into HorarioNomina(IDInstitucional, diaLaboral, horaInicio,horaFin) values('B70988','Miercoles',9, 3)
Insert into HorarioNomina(IDInstitucional, diaLaboral, horaInicio,horaFin) values('B70988','Viernes',3,10)
Select * from HorarioNomina;


--Tabla Aguinaldo
create table [Aguinaldo](
IDInstitucional varchar (25) not null,
aguinaldoNeto decimal not null,
aguinaldoBruto decimal not null
primary key (IDInstitucional)
)
go

select * from [Aguinaldo]


--Insert aguinaldo
Insert into Aguinaldo (IDInstitucional,aguinaldoNeto, aguinaldoBruto) values ('B77064', 450000,330000)
Insert into Aguinaldo (IDInstitucional,aguinaldoNeto, aguinaldoBruto) values ('B70988',336000,40000)
Insert into Aguinaldo (IDInstitucional,aguinaldoNeto, aguinaldoBruto) values ('B88543',150000,332000)


-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--procedimientos almacenados de nominas

--procedimiento para consultar los aspirantes
create procedure [PA_Cns_Aspirantes_Nom](@idAspirante varchar(25))
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

create procedure [PA_Ins_NominaTelefono]
(
@IDInstitucional varchar(25),
@telefono varchar(100)
)
as
insert into NominaTelefono(IDInstitucional, telefono)
values(@IDInstitucional, @telefono)
go

create procedure [PA_Ins_NominaCorreo]
(
@IDInstitucional varchar(25),
@correo varchar(100)
)
as
insert into NominaCorreo(IDInstitucional, correo)
values(@IDInstitucional, @correo)
go


create procedure [PA_Ins_NominaHorario]
(
@IDInstitucional varchar(25),
@tipoHorario varchar(100)
)
as
insert into HorarioNomina(IDInstitucional, tipoHorario)
values(@IDInstitucional, @tipoHorario)
go

--procedimientos almacenados para agregar nuevos colaboradores a la nomina
create procedure [PA_Ins_ColaboradorNomina]
(
@idColaborador varchar(25),
@cedula varchar(25),
@nombre varchar(25),
@primerApellido varchar(25),
@segundoApellido varchar(25),
@direccion varchar (200),
@puestoTrabajo varchar (50),
@salarioNeto decimal(12,2),
@salarioBruto decimal (12,2))
as
insert into [Nomina](IDInstitucional, cedula, nombre, primerApellido, segundoApellido, direccion, puestoTrabajo, salarioBruto, salarioNeto)
values(@idColaborador, @cedula, @nombre, @primerApellido, @segundoApellido, @direccion, @puestoTrabajo,@salarioBruto,@salarioNeto)
go


create procedure [PA_Eli_Aspirante](@IDInstitucional varchar(25))
as
delete from Aspirante where idAspirante = @IDInstitucional
go

create procedure [PA_Eli_AspiranteCorreo](@IDInstitucional varchar(25))
as
delete from [CorreoAspirante] where idAspirante = @IDInstitucional
go

create procedure [PA_Eli_AspiranteTelefono](@IDInstitucional varchar(25))
as
delete from [TelefonoAspirante] where idAspirante = @IDInstitucional
go


