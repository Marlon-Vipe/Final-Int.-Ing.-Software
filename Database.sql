create database Employee_ITLA_DB

use Employee_ITLA_DB

create table Employee(
	id int primary key identity not null,
	name_employee varchar(60),
	identification_card varchar(50) unique not null,
	date_of_birth date,
	role_employee varchar(50),
	phone_number varchar(50),
	email varchar(50),
	hire_date date
)

create table Vacations (
	id_Vacations int primary key identity not null,
	identification_card varchar(50) unique not null,
	from_vacations date,
	to_vacations date,
	status_vacation BIT
)

create table Payroll ( 
	id int identity primary key not null,
	id_employee int foreign key references Employee(id),
	date_payroll date default getDate(),
	AFP decimal,
	secure decimal,
	commission decimal
)


create table job_history(
	id_job_history int identity,
	id_employee int,
	entry_date date,
	end_date date,
	name_employee varchar(60),
	identification_card varchar(50) unique not null,
	role_employee varchar(50)
)	


create table admins (
	users varchar(50),
	pass varchar(25)
)

exec sp_vacationRequests

create procedure sp_vacationRequests 

@identification_card varchar(50)
as

	begin
	--if(@identification_card == '')
	select  E.id, E.identification_card, E.name_employee, E.role_employee ,
				E.phone_number , E.email , E.date_of_birth , E.hire_date

		from Employee E 
		inner Join Vacations v on v.identification_card = E.identification_card
		where E.identification_card = '0' 
end




-- store procedure Payroll descuentos



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


----  

-- trigger when delete employee se vaya to

create trigger delete_Employee on Employee

after delete

as

  begin
select
  delete from Employee where id in (select id from deleted) 

  delete from Vacations where id in (select id from deleted)

  delete from Payroll where id in ( id from deleted)

  end


 
 ---------------------------- Selects -----------------------------------------
select * from Employee
select * from job_history
select * from Vacations
select * from Payroll

----------------------------- Inserts --------------------------------------

insert into Employee values('Juan','0','01/01/2000','programador','00100100001','juan@gmail.com','01/01/2020')
insert into Employee values('Pedro','2','01/01/2001','frontend','00112333','pedro@gmail.com','01/01/2020')
insert into Vacations values ('0','10/12/2021','10/10/2000',0)

------------------------ deletes -----------------------

delete from Employee where id = 6
delete from job_history 



------------ drops -----------
drop table Employee
drop table Vacations
drop table Payroll
drop table job_history
drop table admins
