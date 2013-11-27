--1.Create a table in SQL Server with 10 000 000 log entries (date + text). Search in the table by date range. Check the speed (without caching).

CREATE TABLE Logs(
  Id int NOT NULL 
  IDENTITY,
  [Text] nvarchar(300),
  LogDate datetime
)
GO

CREATE PROCEDURE uspAddLogs
AS
DECLARE @counter int
SET @counter = 1;
WHILE(@counter < 10000000)
BEGIN
	INSERT INTO Logs (LogDate, [Text])
	VALUES(DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate()), 'this is texxxt')
	SET @counter = @counter + 1;
END


EXEC uspAddLogs

--This clears the cache
CHECKPOINT; 
GO 
DBCC DROPCLEANBUFFERS; 
GO

SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) > 2002 AND YEAR(l.LogDate) < 2015

--2.Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)

SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) > 2002 AND YEAR(l.LogDate) < 2015

--3.Add a full text index for the text column. Try to search with and without the full-text index and compare the speed

CREATE INDEX IDX_Logs_MsgText ON Logs([Text])

SELECT l.[Text]
FROM Logs l
WHERE YEAR(l.LogDate) > 2002 AND YEAR(l.LogDate) < 2015
GO
--4.Create the same table in MySQL and partition it by date (1990, 2000, 2010). Fill 1 000 000 log entries. Compare the searching speed in all partitions (random dates) to certain partition (e.g. year 1995).

CREATE DATABASE Performance_Partitioning_DB;
GO
USE Performance_Partitioning_DB;

CREATE TABLE Logs(
	LogId int NOT NULL AUTO_INCREMENT,
	LogDate datetime,
	LogText nvarchar(100),
	CONSTRAINT PK_Logs_LogId PRIMARY KEY(LogId, LogDate)
) PARTITION BY RANGE(YEAR(LogDate))(
	PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
	PARTITION p2 VALUES LESS THAN (2010),
	PARTITION p3 VALUES LESS THAN MAXVALUE
);
GO
--------------------

DELIMITER $$
DROP PROCEDURE IF EXISTS insert_million_rows $$

CREATE PROCEDURE InsertMilionRowsInDB () 
BEGIN
DECLARE counter INT DEFAULT 0;
	START TRANSACTION;
	WHILE counter < 1000000 DO
		INSERT INTO Logs(LogDate, LogText)
		VALUES(TIMESTAMPADD(DAY, FLOOR(1 + RAND() * 10000), '1990-01-01'),
		CONCAT('Sample text ', counter));
SET counter = counter + 1;
END WHILE;
END $$

CALL InsertMilionRowsInDB ();

SELECT * FROM logs PARTITION(p2);

SELECT * FROM logs WHERE YEAR(LogDate) = 1995;