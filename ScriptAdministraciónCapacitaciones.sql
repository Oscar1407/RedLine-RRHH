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

--tabla para el correo del colaborador
create table [CorreoColaboradorCapacitaciones]
(
IDInstitucional varchar(25) not null,
correo varchar(100) not null,
primary key(IDInstitucional, correo),
constraint fk_colaboradorCorreo foreign key (IDInstitucional) references [ColaboradorCapacitacion] (IDInstitucional)
)
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

drop table [TelefonoColaboradorCapacitaciones]
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
