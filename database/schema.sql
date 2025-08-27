
-- Fintcs Database Schema
-- Drop tables if they exist (for clean setup)
DROP TABLE IF EXISTS VoucherLines CASCADE;
DROP TABLE IF EXISTS Vouchers CASCADE;
DROP TABLE IF EXISTS MonthlyDemandRows CASCADE;
DROP TABLE IF EXISTS MonthlyDemandHeaders CASCADE;
DROP TABLE IF EXISTS PendingEdits CASCADE;
DROP TABLE IF EXISTS Loans CASCADE;
DROP TABLE IF EXISTS Members CASCADE;
DROP TABLE IF EXISTS AppUsers CASCADE;
DROP TABLE IF EXISTS Societies CASCADE;
DROP TABLE IF EXISTS LookupItems CASCADE;
DROP TABLE IF EXISTS SuperAdmins CASCADE;

-- Create LookupItems table first (referenced by other tables)
CREATE TABLE LookupItems (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    Code VARCHAR(20) NOT NULL UNIQUE,
    Name VARCHAR(100) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    IsActive BOOLEAN DEFAULT true,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP
);

-- Create SuperAdmins table
CREATE TABLE SuperAdmins (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create Societies table
CREATE TABLE Societies (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    Code VARCHAR(20) NOT NULL UNIQUE,
    Name VARCHAR(100) NOT NULL,
    Address TEXT,
    Phone VARCHAR(20),
    Email VARCHAR(100),
    RegistrationNumber VARCHAR(50),
    IsActive BOOLEAN DEFAULT true,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP
);

-- Create AppUsers table
CREATE TABLE AppUsers (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('SocietyAdmin', 'User')),
    SocietyId UUID NOT NULL REFERENCES Societies(Id),
    IsActive BOOLEAN DEFAULT true,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP
);

-- Create Members table
CREATE TABLE Members (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    SocietyId UUID NOT NULL REFERENCES Societies(Id),
    MemNo VARCHAR(20) NOT NULL,
    MemberCode VARCHAR(20),
    Name VARCHAR(100) NOT NULL,
    FatherName VARCHAR(100),
    Address TEXT,
    Phone VARCHAR(20),
    Email VARCHAR(100),
    JoiningDate DATE NOT NULL,
    IsActive BOOLEAN DEFAULT true,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP,
    UNIQUE(SocietyId, MemNo)
);

-- Create Loans table
CREATE TABLE Loans (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    SocietyId UUID NOT NULL REFERENCES Societies(Id),
    MemberId UUID REFERENCES Members(Id),
    LoanTypeId UUID NOT NULL REFERENCES LookupItems(Id),
    BankId UUID REFERENCES LookupItems(Id),
    Amount DECIMAL(18,2) NOT NULL,
    InterestRate DECIMAL(5,2),
    StartDate DATE NOT NULL,
    EndDate DATE,
    Status VARCHAR(20) DEFAULT 'Active',
    Description TEXT,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP
);

-- Create Vouchers table
CREATE TABLE Vouchers (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    SocietyId UUID NOT NULL REFERENCES Societies(Id),
    VoucherNo VARCHAR(20) NOT NULL,
    VoucherTypeId UUID NOT NULL REFERENCES LookupItems(Id),
    Date DATE NOT NULL,
    Description TEXT,
    TotalAmount DECIMAL(18,2) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP,
    UNIQUE(SocietyId, VoucherNo)
);

-- Create VoucherLines table
CREATE TABLE VoucherLines (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    VoucherId UUID NOT NULL REFERENCES Vouchers(Id) ON DELETE CASCADE,
    Description VARCHAR(255) NOT NULL,
    DebitAmount DECIMAL(18,2) DEFAULT 0,
    CreditAmount DECIMAL(18,2) DEFAULT 0,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create MonthlyDemandHeaders table
CREATE TABLE MonthlyDemandHeaders (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    SocietyId UUID NOT NULL REFERENCES Societies(Id),
    MonthId UUID NOT NULL REFERENCES LookupItems(Id),
    Year INTEGER NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP,
    UNIQUE(SocietyId, MonthId, Year)
);

-- Create MonthlyDemandRows table
CREATE TABLE MonthlyDemandRows (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    HeaderId UUID NOT NULL REFERENCES MonthlyDemandHeaders(Id) ON DELETE CASCADE,
    MemberId UUID NOT NULL REFERENCES Members(Id),
    Amount DECIMAL(18,2) NOT NULL,
    IsPaid BOOLEAN DEFAULT false,
    PaidDate DATE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create PendingEdits table
CREATE TABLE PendingEdits (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    SocietyId UUID NOT NULL REFERENCES Societies(Id),
    TableName VARCHAR(50) NOT NULL,
    RecordId UUID NOT NULL,
    FieldName VARCHAR(50) NOT NULL,
    OldValue TEXT,
    NewValue TEXT,
    RequestedBy VARCHAR(100) NOT NULL,
    Status VARCHAR(20) DEFAULT 'Pending',
    RequestedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    ReviewedAt TIMESTAMP,
    ReviewedBy VARCHAR(100)
);

-- Create indexes for better performance
CREATE INDEX idx_appusers_society ON AppUsers(SocietyId);
CREATE INDEX idx_members_society ON Members(SocietyId);
CREATE INDEX idx_loans_society ON Loans(SocietyId);
CREATE INDEX idx_vouchers_society ON Vouchers(SocietyId);
CREATE INDEX idx_demand_headers_society ON MonthlyDemandHeaders(SocietyId);
CREATE INDEX idx_lookup_type ON LookupItems(Type);
