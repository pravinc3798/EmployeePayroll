create database dbPayrollService;
use dbPayrollService;

create table tblEmployeePayroll
(
	EmployeeId int identity(1,1) primary key,
	EmployeeName varchar (50),
	EmployeeSalary float,
	StartDate date
);

insert into tblEmployeePayroll values ('Abc', 25.36, cast ('2022-01-04' as date));
insert into tblEmployeePayroll values ('Def', 35.36, cast ('2022-04-01' as date));
insert into tblEmployeePayroll values ('Ghi', 45.36, cast ('2022-06-04' as date));
insert into tblEmployeePayroll values ('Jkl', 55.36, cast ('2022-07-04' as date));
insert into tblEmployeePayroll values ('Mno', 65.36, cast ('2022-08-04' as date));
insert into tblEmployeePayroll values ('Pqr', 75.36, cast ('2022-09-04' as date));

select * from tblEmployeePayroll;

select EmployeeSalary from tblEmployeePayroll where EmployeeName = 'Pqr';
select employeeSalary from tblEmployeePayroll where StartDate between cast ('2022-05-01' as date) and GETDATE();

alter table tblemployeepayroll add Gender varchar(1);

update tblEmployeePayroll set gender = 'M' where EmployeeId between 2 and 4; 
update tblEmployeePayroll set gender = 'M' where gender is null;

update tblEmployeePayroll set gender = 'F' where EmployeeId < 2;
update tblEmployeePayroll set gender = 'F' where EmployeeId >= 4; 

select gender, SUM(employeesalary) as TotalSalary from tblEmployeePayroll group by gender;
select gender, Avg(employeesalary) as AverageSalary from tblEmployeePayroll group by gender;
select gender, Min(employeesalary) as MinimumSalary from tblEmployeePayroll group by gender;
select gender, Max(employeesalary) as MaximumSalary from tblEmployeePayroll group by gender;
select gender, Count(EmployeeId) as HeadCount from tblEmployeePayroll group by gender;

create table tblEmployeeDetails
(
	EmployeeId int foreign key references tblEmployeePayroll(EmployeeId),
	Contact varchar (10),
	City varchar (20),
	States varchar(20),
	Zip varchar (6)
);

create table tblTaxDetails
(
	EmployeeId int foreign key references tblEmployeePayroll(EmployeeId),
	Deductions float,
	TaxPercent float
);

exec sp_rename 'tblEmployeePayroll.employeesalary','BasicPay','column';

insert into tblEmployeeDetails values (1,'9876543210','Pune','Maharashtra','400000');
insert into tblEmployeeDetails values (2,'1234567890','Mumbai','Maharashtra','400000');
insert into tblEmployeeDetails values (3,'8888999912','Nasik','Maharashtra','400000');
insert into tblEmployeeDetails values (4,'8877992255','New Delhi','Delhi','400000');
insert into tblEmployeeDetails values (5,'1122334455','Bangalore','Karnataka','400000');
insert into tblEmployeeDetails values (6,'7744552244','Goa','Goa','400000');

insert into tblTaxDetails values (1,2.5,0.02);
insert into tblTaxDetails values (2,2.1,0.04);
insert into tblTaxDetails values (3,3.0,0.05);
insert into tblTaxDetails values (4,1.2,0.06);
insert into tblTaxDetails values (5,0.4,0.06);
insert into tblTaxDetails values (6,7.8,0.09);

create procedure GetCompleteDetails
as
select tblemployeedetails.EmployeeId,Gender,EmployeeName,Contact,City,States,Zip,BasicPay,StartDate,Deductions,TaxPercent,(BasicPay - Deductions) * TaxPercent as Taxpaid, (BasicPay - Deductions - (BasicPay - Deductions) * TaxPercent) as NetPay from tblEmployeePayroll,tblEmployeeDetails,tblTaxDetails where tblEmployeeDetails.EmployeeId = tblEmployeePayroll.EmployeeId and tblEmployeeDetails.EmployeeId = tblTaxDetails.EmployeeId;

exec GetCompleteDetails;

create procedure AddEmployee 
@name varchar(50), @gender varchar (1), @contact varchar(10), @city varchar(20), @state varchar(20), @zip varchar(6), @startdate date, @basicpay float, @deductions float, @taxpercent float
as
insert into tblEmployeePayroll values (@name, @basicpay, @startdate, @gender)
declare @id int
select @id = SCOPE_IDENTITY()
insert into tblEmployeeDetails values (@id,@contact,@city,@state,@zip)
insert into tblTaxDetails values (@id,@deductions,@taxpercent)

exec AddEmployee 'Xyz','M','9887766550','someCity','someState','123456','2022-09-01',1000,100,0.01

exec GetCompleteDetails;

create procedure DeleteEmployee 
@name varchar(60)
as
declare @id as int
select @id = EmployeeId from tblEmployeePayroll where EmployeeName = @name 
delete from tblTaxDetails where EmployeeId = @id
delete from tblEmployeeDetails where EmployeeId = @id
delete from tblEmployeePayroll where EmployeeId = @id


