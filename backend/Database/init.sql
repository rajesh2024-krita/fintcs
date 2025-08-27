
-- Create Fintcs Database
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Fintcs')
BEGIN
    CREATE DATABASE Fintcs;
END
GO

USE Fintcs;
GO

-- The Entity Framework will create the tables automatically
-- This script is just for reference and manual database creation if needed

PRINT 'Database Fintcs is ready for Entity Framework Code First approach';
PRINT 'Run the application to automatically create tables and seed data';
