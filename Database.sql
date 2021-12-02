create database Employee_ITLA_DB

use Employee_ITLA_DB

create table Employee(
	id int primary key identity (1,1) not null,
	name_employee varchar(60),
	identification_card varchar(50) unique not null,
	date_of_birth date,
	role_employee varchar(50),
	phone_number varchar(50),
	email varchar(50),
	hire_date date,
	salary decimal
)
go
create table Vacations (
	id_Vacations int primary key identity (1,1) not null,
	identification_card varchar(50) unique not null,
	from_vacations date,
	to_vacations date,
	status_vacation BIT default 0
)
go
create table Payroll ( 
	id int identity (1,1) primary key not null,
	id_employee int foreign key references Employee(id)on delete cascade,
	date_payroll date default getDate(),
	AFP decimal,
	secure decimal,
	net_income int
)

go
create table job_history(
	id_job_history int identity (1,1) primary key,
	id_employee int,
	entry_date date,
	end_date date,
	name_employee varchar(60),
	identification_card varchar(50) unique not null,
	role_employee varchar(50)
)	

go
create table admins (
	id_admin int identity (1,1) primary key,
	users varchar (50),
	pass varchar(25)
)
go

exec sp_vacationRequests

--create procedure sp_vacationRequests 

--@identification_card varchar(50)
--as

--	begin
--	--if(@identification_card == '')
--	select  E.id, E.identification_card, E.name_employee, E.role_employee ,
--				E.phone_number , E.email , E.date_of_birth , E.hire_date

--		from Employee E 
--		inner Join Vacations v on v.identification_card = E.identification_card
--		where E.identification_card = '0' 
--end


-- store procedure Payroll descuentos
CREATE PROCEDURE sp_payroll
as
begin
	SELECT E.name_employee,E.identification_card,E.salary AS "Gross Salary",P.AFP,P.secure, P.net_income 
	FROM Payroll AS P JOIN Employee AS E ON E.id=P.id_employee  
end




create trigger add_To_Payroll
on Employee 
for insert
as
	
	declare @salary decimal
	DECLARE @ID INT
	declare @afp decimal
	declare @secure decimal
	declare @net_income decimal

	select @ID=id, @salary = salary from inserted


	set @afp = @salary * 0.05 
	set @secure = @salary * 0.03 
	set @net_income = @salary - @afp - @secure


	--INSERT INTO Payroll
 --       (id_employee,date_payroll, AFP, secure)
 --   SELECT id, hire_date FROM inserted

	INSERT INTO Payroll  (id_employee, AFP, secure, net_income) VALUES(@ID,@afp,@secure,@net_income)

	



-- trigger Payrroll
create trigger add_To_Payroll
on Employee 
for insert
as
	INSERT INTO Payroll
        (id_employee, identification_card)
    SELECT id,hire_date, name_employee, identification_card, role_employee FROM inserted
--------------------------------------------------------------------------------------------------------

-- trigger job history cuando se cree empleado agregue los datos al job_history menos el end_date).
create trigger add_To_jobHistory_When
on Employee 
for insert
as
	INSERT INTO job_history 
        (id_employee, entry_date,name_employee, identification_card, role_employee )
    SELECT id,hire_date, name_employee, identification_card, role_employee FROM inserted


-- trigger job history cuando se elimine un empleado, actualice el job history (solamente el end date).
create trigger update_Job_History on Employee
after delete
as

begin

	UPDATE job_history
	SET end_date = getDate()
	WHERE id_employee = (select id from deleted)

end


-- trigger when delete employee se vaya to

alter trigger delete_Employee on Employee

instead of delete

as

  begin

  delete from Payroll where id_employee in (select identification_card from deleted)

  delete from Vacations where identification_card in (select identification_card from deleted)

  delete from Employee where id in (select id from deleted)

  end


 
 ---------------------------- Selects -----------------------------------------
select * from Employee
select * from job_history
select * from Vacations
select * from Payroll

----------------------------- Inserts --------------------------------------

insert into Employee values('Abel','01117234','01/01/2000','qa','001001','abel@gmail.com','01/01/2020',1000)
insert into Employee values('Pedro','222','01/01/2001','frontend','00112333','pedro@gmail.com','01/01/2020',250)

insert into Employee values('Isidro','33','01/01/2000','programador','00100100001','juan@gmail.com','01/01/2020',450)
insert into Employee values('Juanita','4423','01/01/2001','frontend','00112333','pedro@gmail.com','01/01/2020',60000)

insert into Vacations values ('01117234','10/12/2021','10/10/2000',0)

------------------------ deletes -----------------------

delete from Employee where id = 16
delete from Employee where identification_card = 4423
delete from Employee where id = 3
delete from Vacations where id_Vacations = 1
delete from job_history 
delete from Vacations where identification_card = 22


------------ drops -----------
drop table Employee
drop table Vacations
drop table Payroll
drop table job_history
drop table admins


------------ drop triggers-----------
drop trigger add_To_jobHistory_When;

------------- delete-------------
delete from Employee
delete from Vacations 
delete from Payroll 
delete from job_history 

truncate table Employee