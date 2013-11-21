--TASK 1 Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)



--TASK 2 Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary <= 
  (SELECT MIN(Salary) FROM Employees) * 1.1
ORDER BY Salary ASC

--TASK 3 Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement.
SELECT FirstName, LastName, DepartmentID, Salary
FROM Employees e
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID)
ORDER BY DepartmentID

--TASK 4 Write a SQL query to find the average salary in the department #1.
SELECT
  AVG(Salary) [Average Salary]
FROM Employees
WHERE DepartmentID = 1

--TASK 5 Write a SQL query to find the average salary  in the "Sales" department.
SELECT
  AVG(Salary) [Average Salary Sales dept]
FROM Employees
WHERE DepartmentID = 3


SELECT AVG(e.Salary) AS AvgSalary
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--TASK 6 Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) [Salary dept employees] FROM Employees
WHERE DepartmentID = 3

--TASK 7 Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*) [Employees with manager] FROM Employees
WHERE ManagerID IS NOT NULL

--TASK 8 Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) [Employees without manager] FROM Employees
WHERE ManagerID IS NULL


--TASK 9 Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name, AVG(e.Salary) as [Average Salary]
FROM Employees e
JOIN Departments d 
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name

--TASK 10 Write a SQL query to find the count of all employees in each department and for each town.
SELECT COUNT(*) AS [Employees count], d.Name AS [Deptartment Name], t.Name AS [Town name]
FROM Employees e 
  JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY [Employees count] DESC

--TASK 11 Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.LastName, m.FirstName
FROM Employees e 
  JOIN Employees m 
    ON e.ManagerID = m.EmployeeID
GROUP BY m.LastName, m.FirstName
HAVING COUNT(*) = 5

Select e.LastName, e.FirstName, e.EmployeeID
FROM Employees e 
WHERE 5 = 
		(
		SELECT COUNT(*)
		FROM Employees
		WHERE ManagerID = e.EmployeeID
		)


--TASK 12 Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName, e.LastName, ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') AS [Manager name]
FROM Employees e
JOIN Employees m 
ON e.ManagerID = m.EmployeeID

--TASK 13 Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT e.FirstName, e.LastName 
FROM Employees e 
WHERE LEN(e.LastName) = 5

--TASK 14 Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.
SELECT FORMAT(GETDATE(),'dd.MM.yyyy hh:mm:ss:ff')

--TASK 15 Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. Define a check constraint to ensure the password is at least 5 characters long
CREATE TABLE Users
	(
		UserID INT PRIMARY KEY IDENTITY,
		UserName nvarchar(20) UNIQUE NOT NULL,
		[Password] nvarchar(20) CHECK(LEN(Password) > 4) NOT NULL,
		FullName nvarchar(50) NOT NULL,
		LastLogin DATETIME
	)

--TASK 16 Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. Test if the view works correctly.
CREATE VIEW RecentUsersView
AS
        SELECT UserName, DAY(GETDATE() - LastLogin) AS DayDifference
        FROM Users
        WHERE DAY(GETDATE() - LastLogin) = 1

--TASK 17 Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). Define primary key and identity column.
CREATE Table Groups
	(
	GroupID INT PRIMARY KEY IDENTITY(1,1),
	GroupName nvarchar(20) UNIQUE
	)

--TASK 18 Write a SQL statement to add a column GroupID to the table Users. Fill some data in this new column and as well in the Groups table. Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users
        ADD GroupID INT
ALTER TABLE Users
        ADD CONSTRAINT FK_UsersGroup FOREIGN KEY(GroupID) REFERENCES Groups(GroupID)

--TASK 19 Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Users (UserName, [Password], FullName, LastLogin)

VALUES(
        'username1', 'somepass1', 'Georgi Kotzev', getdate()),
        ('username2', 'somepass2', 'Ficho Kotzev', getdate()),
		('username3', 'somepass3', 'Hristo Kotzev', getdate()),
		('username4', 'somepass4', 'Evlogi Kotzev', getdate()),
		('username5', 'somepass5', 'Ivan Kotzev', getdate()
)

INSERT INTO Groups (GroupName)

VALUES
        ('NewBornGroup1'),
        ('NewBornGroup2'),
		('NewBornGroup3'),
		('NewBornGroup4'),
		('NewBornGroup5')

select * from Users
select * from Groups

--TASK 20 Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET UserName = 'username1Updated', Password = 'passAlsoUpdated'
FROM Users
WHERE UserName = 'username1'
 
UPDATE Groups
SET GroupName = 'Group2Updated'
FROM Groups
WHERE GroupName = 'Group2'

select * from Users
select * from Groups

--TASK 21 Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE
FROM Users
WHERE UserName = 'username3'

DELETE
FROM Groups
WHERE GroupName='Group3'


--TASK 22 Write SQL statements to insert in the Users table the names of all employees from the Employees table. Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). Use the same for the password, and NULL for last login time.
INSERT INTO Users(UserName, [Password], FullName, LastLogin)
SELECT   LOWER(SUBSTRING(FirstName, 0, 1) + LastName),
         (FirstName + 'password'),
		 (FirstName + ' ' + LastName),
         getdate()
FROM Employees


--TASK 23 Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET [Password] = NULL
FROM Users
WHERE LastLogin < CONVERT(datetime, '10-03-2014')
                AND [Password] IS NOT NULL

--TASK 24 Write a SQL statement that deletes all users without passwords (NULL password).
BEGIN TRAN
DELETE FROM Users
WHERE [Password] = 'username4'
 
ROLLBACK TRAN

--TASK 25 Write a SQL query to display the average employee salary by department and job title.
SELECT e.DepartmentID, d.Name, COUNT(e.EmployeeID) as CountEmployees, 
  AVG(e.Salary) AverageSalary
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, d.Name

SELECT d.Name, e.JobTitle, AVG(e.Salary) as [Average Salary] 
FROM Employees e
JOIN Departments d 
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle

--TASK 26 Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT d1.Name, e.JobTitle, e.Salary, e.FirstName + ' ' + e.LastName AS [Employee name]
FROM Employees e
JOIN Departments d1
ON d1.DepartmentID = e.DepartmentID
WHERE e.Salary IN (SELECT MIN(e2.Salary)
	FROM Employees e2
	JOIN Departments d2 
	ON d2.DepartmentID = e2.DepartmentID 
	WHERE d2.DepartmentID = d1.DepartmentID 
	AND e2.JobTitle = e.JobTitle
	GROUP BY d2.Name, e2.JobTitle)

--TASK 27 Write a SQL query to display the town where maximal number of employees work.
SELECT TOP(1) t.Name as [Most popolated employees town], COUNT(e.EmployeeID) AS WorkingEmployees
FROM Towns t
	JOIN Addresses a	
	ON t.TownID = a.TownID
	JOIN Employees e
	ON e.AddressID = a.AddressID
GROUP BY t.Name
ORDER BY WorkingEmployees DESC

--TASK 28 Write a SQL query to display the number of managers from each town.
SELECT COUNT(DISTINCT e.ManagerID) AS [Number of Managers], t.Name as [Town name]
FROM Employees e
        JOIN Employees m
        ON e.ManagerID = m.EmployeeID
        JOIN Addresses a
        ON a.AddressID = m.AddressID
        JOIN Towns t
        ON a.TownID = t.TownID
GROUP BY t.Name

--TASK 29 Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). Don't forget to define  identity, primary key and appropriate foreign key. Issue few SQL statements to insert, update and delete of some data in the table.Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours(
	WorkHoursID INT IDENTITY NOT NULL,
	EmployeeID INT NULL,
	LogDate DATETIME NOT NULL,
	Task NVARCHAR(50) NOT NULL,
	LogHours INT NOT NULL,
	Comment NVARCHAR(250) NULL
	CONSTRAINT PK_WorkHoursID PRIMARY KEY (WorkHoursID)
	CONSTRAINT FK_EmployeeID FOREIGN KEY (EmployeeID)
	REFERENCES Employees(EmployeeID)
)

INSERT INTO WorkHours(LogDate, Task, LogHours)
VALUES 
	(GETDATE(), 'Sample task 1', 12),
	(GETDATE(), 'Sample task 2', 13),
	(GETDATE(), 'Sample task 3', 14),
	('2013-07-08', 'Sample task 4', 15)

DELETE FROM WorkHours
WHERE Task = 'Sample task 4'

UPDATE WorkHours
SET Task = 'Sample task 3'
WHERE Task = 'Sample task 4'

CREATE TABLE WorkHoursLogs(
	LogID INT IDENTITY(1,1) PRIMARY KEY,
	ExecuteCommand NVARCHAR(20) NULL,
	WorkHoursID INT NULL,
	OldEmployeeID INT FOREIGN KEY(OldEmployeeID) REFERENCES Employees(EmployeeID) NULL,
	OldDate DATETIME NULL,
	OldTask NVARCHAR(50) NULL,
	OldComment NVARCHAR(250) NULL,
	NewEmployeeID INT FOREIGN KEY(NewEmployeeID) REFERENCES Employees(EmployeeID) NULL,
	NewDate DATETIME NULL,
	NewTask NVARCHAR(50) NULL,
	NewComment NVARCHAR(250) NULL,
)

--TASK 30 Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction.
BEGIN TRAN
DELETE FROM Employees
	SELECT d.Name
	FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	GROUP BY d.Name
ROLLBACK TRAN

--TASK 31 Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?
BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

--TASK 32 Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
CREATE TABLE #TemporaryTable(
        EmployeeID int NOT NULL,
        ProjectID int NOT NULL
)

INSERT INTO #TemporaryTable
        SELECT EmployeeID, ProjectID
        FROM EmployeesProjects
DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
        EmployeeID int NOT NULL,
        ProjectID int NOT NULL,
        CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
        CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
        CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
)

INSERT INTO EmployeesProjects
SELECT EmployeeID, ProjectID
FROM #TemporaryTable







 

