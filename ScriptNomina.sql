use [RedLine-DataBase]
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

--Insert Nomina
Insert into Nomina (IDInstitucional,cedula,nombre, primerApellido,SegundoApellido,direccion, puestoTrabajo, salarioNeto, salarioBruto) values('B77064',604470972,'Daniel', 'Sánchez','Chaves', 'Parrita', 'Analista',500000, 800000)
Insert into Nomina (IDInstitucional,cedula,nombre, primerApellido,SegundoApellido,direccion, puestoTrabajo, salarioNeto, salarioBruto) values('B70988',603220198,'Roxana', 'Chaves', 'Sánchez', 'Puntarenas', 'Secretaria', 450000, 650000)
Insert into Nomina (IDInstitucional,cedula,nombre, primerApellido,SegundoApellido,direccion, puestoTrabajo, salarioNeto, salarioBruto) values('B88543',603280015, 'Jesus','Aguero', 'Chaves', 'San José', '	jefe capacitaciones', 550000,850000)
select * from Nomina;

--Tabla NominaTelefono
create table [NominaTelefono](
IDInstitucional varchar (25) not null,
telefono varchar(25) not null
primary key (IDInstitucional, telefono),
constraint fk_nominaTelefono foreign key (IDInstitucional) references [Nomina](IDInstitucional)
)
go

--Insert NominaTelefono
Insert into NominaTelefono (IDInstitucional, telefono) values ('B77064','87336588')
Insert into NominaTelefono (IDInstitucional, telefono) values ('B70988','60457689')
Insert into NominaTelefono (IDInstitucional, telefono) values ('B88543','76345798')


--Tabla NominaCorreo
create table [NominaCorreo](
IDInstitucional varchar (25) not null,
correo varchar(100) not null
primary key (IDInstitucional, correo),
constraint fk_nominaCorreo foreign key (IDInstitucional) references [Nomina](IDInstitucional)
)
go

--Insert NominaCorreo
Insert into NominaCorreo(IDInstitucional, correo) values ('B77064','chavesdan0@gmail.com')
Insert into NominaCorreo(IDInstitucional, correo) values ('B70988','rox123@gmail.com')
Insert into NominaCorreo(IDInstitucional, correo) values ('B88543','jesuscha@gmail.com')

select * from NominaCorreo;
--Tabla HorarioNomina
create table [HorarioNomina](
IDInstitucional varchar (25) not null,
diaLaboral varchar (15) not null,
horaInicio int not null,
horaFin int not null
primary key(IDInstitucional, diaLaboral),
constraint fk_nominaHorario foreign key (IDInstitucional) references [Nomina](IDInstitucional)
)
go

Insert into HorarioNomina(IDInstitucional, diaLaboral, horaInicio,horaFin) values('B77064','Lunes',7,10)
Insert into HorarioNomina(IDInstitucional, diaLaboral, horaInicio,horaFin) values('B70988','Miercoles',9, 3)
Insert into HorarioNomina(IDInstitucional, diaLaboral, horaInicio,horaFin) values('B70988','Viernes',3,10)
Select * from HorarioNomina;

--Tabla Deducciones
create table [Deducciones](
IDDeduccion varchar (25) not null,
tipo varchar (30) not null,
monto decimal not null,
descripcion varchar (200) not null
primary key (IDDeduccion)
)
go
--Insert Deducciones
Insert into Deducciones(IDDeduccion,tipo,monto,descripcion)values('1010','Seguro',25000,'Deducción por seguro médico.')
Insert into Deducciones(IDDeduccion,tipo,monto,descripcion)values('1011','Salario',55000,'Deducción por salario y comisión.')
Insert into Deducciones(IDDeduccion,tipo,monto,descripcion)values('1012','Aguinaldo',120000,'Deducción por aguinaldo.')

--Tabla DeduccionLaboral
create table[DeduccionLaboral](
IDDeduccion varchar (25) not null,
IDInstitucional varchar (25) not null
primary key (IDDeduccion, IDInstitucional),
constraint fk_deduccionlaboral foreign key (IDInstitucional) references [Nomina](IDInstitucional)
)
go
--Insert deduccionLaboral
Insert into DeduccionLaboral(IDDeduccion, IDInstitucional)values('1010','B77064')
Insert into DeduccionLaboral(IDDeduccion, IDInstitucional)values('1011','B70988')
Insert into DeduccionLaboral(IDDeduccion, IDInstitucional)values('1012','B88543')


--Tabla Aguinaldo
create table [Aguinaldo](
IDInstitucional varchar (25) not null,
aguinaldoNeto decimal not null,
aguinaldoBruto decimal not null
primary key (IDInstitucional)
)
go

--Insert aguinaldo
Insert into Aguinaldo (IDInstitucional,aguinaldoNeto, aguinaldoBruto) values ('B77064', 450000,330000)
Insert into Aguinaldo (IDInstitucional,aguinaldoNeto, aguinaldoBruto) values ('B70988',336000,40000)
Insert into Aguinaldo (IDInstitucional,aguinaldoNeto, aguinaldoBruto) values ('B88543',150000,332000)

--Tabla deduccionAguinaldo
create table[DeduccionAguinaldo](
IDDeduccion varchar (25) not null,
IDInstitucional varchar (25) not null
primary key (IDDeduccion, IDInstitucional),
constraint fk_deduccionAguinaldo foreign key (IDInstitucional) references [Nomina](IDInstitucional)
)
go

--Insert DeduccionAguinaldo
Insert into DeduccionAguinaldo (IDDeduccion, IDInstitucional) values ('100000','B77064')
Insert into DeduccionAguinaldo (IDDeduccion, IDInstitucional) values ('120000','B70988')
Insert into DeduccionAguinaldo (IDDeduccion, IDInstitucional) values ('150000','B88543')


-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--procedimientos almacenados de nominas

--procedimiento para consultar una nomina por ID Institucional
create procedure [PA_Cns_Nomina](@IDInstitucional varchar(25))
as
select n.IDInstitucional as ID_Institucional,
n.cedula as Cedula,
n.nombre as Nombre,
n.primerApellido as Primer_Apellido,
n.segundoApellido as Segundo_Apellido,
c.correo as Correo,
t.telefono as Telefono
from [Nomina] n with(nolock)
inner join [NominaCorreo] c with(nolock) on c.IDInstitucional = n.IDInstitucional
inner join [NominaTelefono] t with(nolock) on t.IDInstitucional = n.IDInstitucional
where n.IDInstitucional = @IDInstitucional
go

exec [PA_Cns_Nomina] @IDInstitucional = 'B77064'
go











