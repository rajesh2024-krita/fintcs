
-- Fintcs Database Schema for SQL Server

USE master;
GO

-- Create database if not exists
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Fintcs')
BEGIN
    CREATE DATABASE Fintcs;
END
GO

USE Fintcs;
GO

-- Drop existing tables in correct order (to handle foreign keys)
IF OBJECT_ID('VoucherLines', 'U') IS NOT NULL DROP TABLE VoucherLines;
IF OBJECT_ID('Vouchers', 'U') IS NOT NULL DROP TABLE Vouchers;
IF OBJECT_ID('MonthlyDemandRows', 'U') IS NOT NULL DROP TABLE MonthlyDemandRows;
IF OBJECT_ID('MonthlyDemandHeaders', 'U') IS NOT NULL DROP TABLE MonthlyDemandHeaders;
IF OBJECT_ID('Loans', 'U') IS NOT NULL DROP TABLE Loans;
IF OBJECT_ID('Members', 'U') IS NOT NULL DROP TABLE Members;
IF OBJECT_ID('AppUsers', 'U') IS NOT NULL DROP TABLE AppUsers;
IF OBJECT_ID('Societies', 'U') IS NOT NULL DROP TABLE Societies;
IF OBJECT_ID('PendingEdits', 'U') IS NOT NULL DROP TABLE PendingEdits;
IF OBJECT_ID('LookupItems', 'U') IS NOT NULL DROP TABLE LookupItems;
IF OBJECT_ID('SuperAdmins', 'U') IS NOT NULL DROP TABLE SuperAdmins;
GO

-- SuperAdmins Table
CREATE TABLE SuperAdmins (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    CreatedAt DATETIME2 DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2
);

-- LookupItems Table (for reference data)
CREATE TABLE LookupItems (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Code NVARCHAR(20) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL, -- LoanType, Bank, VoucherType, Month, etc.
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME2 DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    INDEX IX_LookupItems_Category_Code (Category, Code)
);

-- Societies Table
CREATE TABLE Societies (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(200) NOT NULL,
    Address NVARCHAR(500),
    City NVARCHAR(100),
    Phone NVARCHAR(20),
    Fax NVARCHAR(20),
    Email NVARCHAR(100),
    Website NVARCHAR(200),
    RegistrationNo NVARCHAR(50),
    
    -- Interest rates
    InterestDividend DECIMAL(5,2) DEFAULT 0,
    InterestOD DECIMAL(5,2) DEFAULT 0,
    InterestCD DECIMAL(5,2) DEFAULT 0,
    InterestLoan DECIMAL(5,2) DEFAULT 0,
    InterestEmergencyLoan DECIMAL(5,2) DEFAULT 0,
    InterestLAS DECIMAL(5,2) DEFAULT 0,
    
    -- Limits
    LimitShare DECIMAL(18,2) DEFAULT 0,
    LimitLoan DECIMAL(18,2) DEFAULT 0,
    LimitEmergencyLoan DECIMAL(18,2) DEFAULT 0,
    
    -- Ch bounce charge
    ChBounceChargeAmount DECIMAL(18,2) DEFAULT 0,
    ChBounceChargeMode NVARCHAR(50), -- Excess Provision, Cash, HDFC Bank, Inverter
    
    CreatedAt DATETIME2 DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2
);

-- AppUsers Table
CREATE TABLE AppUsers (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Role NVARCHAR(20) NOT NULL, -- SuperAdmin, SocietyAdmin, User, Member
    EDPNo NVARCHAR(20),
    Name NVARCHAR(100) NOT NULL,
    AddressO NVARCHAR(500), -- Office Address
    AddressR NVARCHAR(500), -- Residence Address
    Designation NVARCHAR(100),
    PhoneO NVARCHAR(20), -- Office Phone
    PhoneR NVARCHAR(20), -- Residence Phone
    Mobile NVARCHAR(20),
    Email NVARCHAR(100),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    SocietyId UNIQUEIDENTIFIER,
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME2 DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    
    FOREIGN KEY (SocietyId) REFERENCES Societies(Id) ON DELETE SET NULL
);

-- Members Table
CREATE TABLE Members (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    MemNo NVARCHAR(20) NOT NULL, -- Auto-generated: MEM_001, MEM_002, etc.
    Name NVARCHAR(100) NOT NULL,
    FatherHusbandName NVARCHAR(100),
    OfficeAddress NVARCHAR(500),
    City NVARCHAR(100),
    PhoneOffice NVARCHAR(20),
    Branch NVARCHAR(100),
    PhoneRes NVARCHAR(20),
    Mobile NVARCHAR(20),
    Designation NVARCHAR(100),
    ResidenceAddress NVARCHAR(500),
    DOB DATE,
    DOJSociety DATE,
    Email NVARCHAR(100),
    DOJOrg DATE, -- Date of Joining Organization
    DOR DATE, -- Date of Retirement
    Nominee NVARCHAR(100),
    NomineeRelation NVARCHAR(50),
    OpeningBalanceShare DECIMAL(18,2) DEFAULT 0,
    Value DECIMAL(18,2) DEFAULT 0,
    CrDrCd NVARCHAR(10), -- Cr / Dr / CD
    
    -- Bank details
    BankName NVARCHAR(100),
    PayableAt NVARCHAR(100),
    AccountNo NVARCHAR(50),
    
    -- Status
    Status NVARCHAR(20) DEFAULT 'Active', -- Active/Deactive
    StatusDate DATE,
    
    -- Deductions (stored as JSON or comma-separated)
    DeductionsJson NVARCHAR(MAX), -- Share, Withdrawal, G Loan Instalment, E Loan Instalment
    
    -- File paths
    PhotoPath NVARCHAR(500),
    SignaturePath NVARCHAR(500),
    
    SocietyId UNIQUEIDENTIFIER NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    
    FOREIGN KEY (SocietyId) REFERENCES Societies(Id) ON DELETE CASCADE,
    UNIQUE (MemNo, SocietyId)
);

-- Loans Table
CREATE TABLE Loans (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    LoanNo NVARCHAR(20) NOT NULL, -- Auto-generated
    LoanTypeId UNIQUEIDENTIFIER NOT NULL,
    LoanDate DATE NOT NULL,
    EDPNo NVARCHAR(20) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    LoanAmount DECIMAL(18,2) NOT NULL,
    PrevLoan DECIMAL(18,2) DEFAULT 0,
    NetLoan AS (LoanAmount - PrevLoan), -- Computed column
    Installments INT NOT NULL,
    InstallmentAmount DECIMAL(18,2) NOT NULL,
    Purpose NVARCHAR(MAX),
    AuthorizedBy NVARCHAR(100),
    PaymentMode NVARCHAR(20) NOT NULL, -- Cash, Cheque, Opening
    BankId UNIQUEIDENTIFIER,
    ChequeNo NVARCHAR(50),
    ChequeDate DATE,
    Share DECIMAL(18,2) DEFAULT 0,
    CD DECIMAL(18,2) DEFAULT 0,
    LastSalary DECIMAL(18,2) DEFAULT 0,
    MWF DECIMAL(18,2) DEFAULT 0,
    PayAmount DECIMAL(18,2) DEFAULT 0,
    
    -- Given/Taken tables stored as JSON
    GivenJson NVARCHAR(MAX),
    TakenJson NVARCHAR(MAX),
    
    SocietyId UNIQUEIDENTIFIER NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    
    FOREIGN KEY (LoanTypeId) REFERENCES LookupItems(Id),
    FOREIGN KEY (BankId) REFERENCES LookupItems(Id),
    FOREIGN KEY (SocietyId) REFERENCES Societies(Id) ON DELETE CASCADE,
    UNIQUE (LoanNo, SocietyId)
);

-- MonthlyDemandHeaders Table
CREATE TABLE MonthlyDemandHeaders (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    MonthId UNIQUEIDENTIFIER NOT NULL,
    YearValue INT NOT NULL,
    TotalAmount DECIMAL(18,2) DEFAULT 0,
    TotalMembers INT DEFAULT 0,
    SocietyId UNIQUEIDENTIFIER NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    
    FOREIGN KEY (MonthId) REFERENCES LookupItems(Id),
    FOREIGN KEY (SocietyId) REFERENCES Societies(Id) ON DELETE CASCADE,
    UNIQUE (MonthId, YearValue, SocietyId)
);

-- MonthlyDemandRows Table
CREATE TABLE MonthlyDemandRows (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    HeaderId UNIQUEIDENTIFIER NOT NULL,
    EDPNo NVARCHAR(20) NOT NULL,
    MemberName NVARCHAR(100) NOT NULL,
    LoanAmt DECIMAL(18,2) DEFAULT 0,
    CD DECIMAL(18,2) DEFAULT 0,
    Loan DECIMAL(18,2) DEFAULT 0,
    Interest DECIMAL(18,2) DEFAULT 0,
    ELoan DECIMAL(18,2) DEFAULT 0,
    InterestExtra DECIMAL(18,2) DEFAULT 0,
    Net DECIMAL(18,2) DEFAULT 0,
    IntDue DECIMAL(18,2) DEFAULT 0,
    PInt DECIMAL(18,2) DEFAULT 0,
    PDed DECIMAL(18,2) DEFAULT 0,
    LAS DECIMAL(18,2) DEFAULT 0,
    Int DECIMAL(18,2) DEFAULT 0,
    LASIntDue DECIMAL(18,2) DEFAULT 0,
    
    FOREIGN KEY (HeaderId) REFERENCES MonthlyDemandHeaders(Id) ON DELETE CASCADE
);

-- Vouchers Table
CREATE TABLE Vouchers (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    VoucherNo NVARCHAR(20) NOT NULL, -- Auto-generated
    VoucherTypeId UNIQUEIDENTIFIER NOT NULL,
    Date DATE NOT NULL,
    ChNo NVARCHAR(50),
    ChequeDate DATE,
    Narration NVARCHAR(MAX),
    Remarks NVARCHAR(MAX),
    PassDate DATE,
    TotalDebit DECIMAL(18,2) DEFAULT 0,
    TotalCredit DECIMAL(18,2) DEFAULT 0,
    SocietyId UNIQUEIDENTIFIER NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    
    FOREIGN KEY (VoucherTypeId) REFERENCES LookupItems(Id),
    FOREIGN KEY (SocietyId) REFERENCES Societies(Id) ON DELETE CASCADE,
    UNIQUE (VoucherNo, SocietyId)
);

-- VoucherLines Table
CREATE TABLE VoucherLines (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    VoucherId UNIQUEIDENTIFIER NOT NULL,
    ParticularsName NVARCHAR(200) NOT NULL,
    Debit DECIMAL(18,2) DEFAULT 0,
    Credit DECIMAL(18,2) DEFAULT 0,
    DbCr NVARCHAR(10), -- Debit, Credit
    Ibldbc DECIMAL(18,2) DEFAULT 0,
    
    FOREIGN KEY (VoucherId) REFERENCES Vouchers(Id) ON DELETE CASCADE
);

-- PendingEdits Table (for approval workflow)
CREATE TABLE PendingEdits (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Entity NVARCHAR(50) NOT NULL, -- Society, Member, etc.
    EntityId UNIQUEIDENTIFIER NOT NULL,
    PayloadJson NVARCHAR(MAX) NOT NULL,
    Status NVARCHAR(20) DEFAULT 'Pending', -- Pending, Approved, Rejected
    CreatedByUserId UNIQUEIDENTIFIER NOT NULL,
    ApprovedByAllUsers BIT DEFAULT 0,
    CreatedAt DATETIME2 DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    
    FOREIGN KEY (CreatedByUserId) REFERENCES AppUsers(Id)
);

PRINT 'Fintcs database schema created successfully!';
