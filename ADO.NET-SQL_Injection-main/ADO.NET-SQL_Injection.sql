CREATE DATABASE Factory

USE Factory

CREATE TABLE LabEmployees(
    Id INT PRIMARY KEY IDENTITY,
    Fullname NVARCHAR(255)
)

SELECT Fullname FROM LabEmployees WHERE Id=4

SELECT Fullname FROM LabEmployees

DELETE FROM LabEmployees WHERE Id=7

SELECT Fullname FROM LabEmployees WHERE Fullname LIKE '%o%'