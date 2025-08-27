
-- Fintcs Sample Data for SQL Server

USE Fintcs;
GO

-- Clear existing data
DELETE FROM VoucherLines;
DELETE FROM Vouchers;
DELETE FROM MonthlyDemandRows;
DELETE FROM MonthlyDemandHeaders;
DELETE FROM Loans;
DELETE FROM Members;
DELETE FROM AppUsers;
DELETE FROM Societies;
DELETE FROM PendingEdits;
DELETE FROM LookupItems;
DELETE FROM SuperAdmins;
GO

-- Insert SuperAdmin
INSERT INTO SuperAdmins (Id, Username, PasswordHash, Name, Email) VALUES 
('00000000-0000-0000-0000-000000000001', 'admin', '$2a$11$rQG/WzMwO9j9n5gPkwV35u5qjOsNfHqp7BI/WqJSlJvV.HrOg5.XW', 'System Administrator', 'admin@fintcs.com');

-- Insert LookupItems
-- Loan Types
INSERT INTO LookupItems (Id, Code, Name, Category) VALUES 
('11111111-1111-1111-1111-111111111111', 'GENERAL', 'General Loan', 'LoanType'),
('22222222-2222-2222-2222-222222222222', 'PERSONAL', 'Personal Loan', 'LoanType'),
('33333333-3333-3333-3333-333333333333', 'HOUSING', 'Housing Loan', 'LoanType'),
('44444444-4444-4444-4444-444444444444', 'VEHICLE', 'Vehicle Loan', 'LoanType'),
('55555555-5555-5555-5555-555555555555', 'EDUCATION', 'Education Loan', 'LoanType'),
('66666666-6666-6666-6666-666666666666', 'OTHERS', 'Others', 'LoanType');

-- Banks
INSERT INTO LookupItems (Id, Code, Name, Category) VALUES 
('77777777-7777-7777-7777-777777777777', 'SBI', 'State Bank of India', 'Bank'),
('88888888-8888-8888-8888-888888888888', 'HDFC', 'HDFC Bank', 'Bank'),
('99999999-9999-9999-9999-999999999999', 'ICICI', 'ICICI Bank', 'Bank'),
('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'AXIS', 'Axis Bank', 'Bank'),
('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'PNB', 'Punjab National Bank', 'Bank'),
('cccccccc-cccc-cccc-cccc-cccccccccccc', 'BOI', 'Bank of India', 'Bank');

-- Voucher Types
INSERT INTO LookupItems (Id, Code, Name, Category) VALUES 
('dddddddd-dddd-dddd-dddd-dddddddddddd', 'PAYMENT', 'Payment Voucher', 'VoucherType'),
('eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'RECEIPT', 'Receipt Voucher', 'VoucherType'),
('ffffffff-ffff-ffff-ffff-ffffffffffff', 'JOURNAL', 'Journal Voucher', 'VoucherType'),
('10101010-1010-1010-1010-101010101010', 'CONTRA', 'Contra Voucher', 'VoucherType'),
('20202020-2020-2020-2020-202020202020', 'ADJUSTMENT', 'Adjustment Voucher', 'VoucherType'),
('30303030-3030-3030-3030-303030303030', 'OTHERS', 'Others', 'VoucherType');

-- Months
INSERT INTO LookupItems (Id, Code, Name, Category) VALUES 
('40404040-4040-4040-4040-404040404040', 'JAN', 'January', 'Month'),
('50505050-5050-5050-5050-505050505050', 'FEB', 'February', 'Month'),
('60606060-6060-6060-6060-606060606060', 'MAR', 'March', 'Month'),
('70707070-7070-7070-7070-707070707070', 'APR', 'April', 'Month'),
('80808080-8080-8080-8080-808080808080', 'MAY', 'May', 'Month'),
('90909090-9090-9090-9090-909090909090', 'JUN', 'June', 'Month'),
('a0a0a0a0-a0a0-a0a0-a0a0-a0a0a0a0a0a0', 'JUL', 'July', 'Month'),
('b0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0', 'AUG', 'August', 'Month'),
('c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0', 'SEP', 'September', 'Month'),
('d0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0', 'OCT', 'October', 'Month'),
('e0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0', 'NOV', 'November', 'Month'),
('f0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0', 'DEC', 'December', 'Month');

-- Sample Society
INSERT INTO Societies (Id, Name, Address, City, Phone, Email, RegistrationNo, InterestDividend, InterestLoan, LimitShare, LimitLoan) VALUES 
('12121212-1212-1212-1212-121212121212', 'ABC Employees Society', '123 Main Street', 'Mumbai', '022-12345678', 'abc@society.com', 'REG001', 8.5, 12.0, 50000, 500000);

-- Sample Society Admin User
INSERT INTO AppUsers (Id, Role, EDPNo, Name, Username, PasswordHash, SocietyId, Email) VALUES 
('13131313-1313-1313-1313-131313131313', 'SocietyAdmin', 'EDP001', 'John Society Admin', 'societyadmin', '$2a$11$rQG/WzMwO9j9n5gPkwV35u5qjOsNfHqp7BI/WqJSlJvV.HrOg5.XW', '12121212-1212-1212-1212-121212121212', 'societyadmin@abc.com');

-- Sample User
INSERT INTO AppUsers (Id, Role, EDPNo, Name, Username, PasswordHash, SocietyId, Email) VALUES 
('14141414-1414-1414-1414-141414141414', 'User', 'EDP002', 'Jane User', 'user', '$2a$11$rQG/WzMwO9j9n5gPkwV35u5qjOsNfHqp7BI/WqJSlJvV.HrOg5.XW', '12121212-1212-1212-1212-121212121212', 'user@abc.com');

-- Sample Members
INSERT INTO Members (Id, MemNo, Name, EDPNo, SocietyId, Status, OpeningBalanceShare, Mobile, Email) VALUES 
('15151515-1515-1515-1515-151515151515', 'MEM_001', 'Alice Member', 'EDP003', '12121212-1212-1212-1212-121212121212', 'Active', 10000, '9876543210', 'alice@abc.com'),
('16161616-1616-1616-1616-161616161616', 'MEM_002', 'Bob Member', 'EDP004', '12121212-1212-1212-1212-121212121212', 'Active', 15000, '9876543211', 'bob@abc.com'),
('17171717-1717-1717-1717-171717171717', 'MEM_003', 'Charlie Member', 'EDP005', '12121212-1212-1212-1212-121212121212', 'Active', 12000, '9876543212', 'charlie@abc.com');

-- Sample Loans
INSERT INTO Loans (Id, LoanNo, LoanTypeId, LoanDate, EDPNo, Name, LoanAmount, InstallmentAmount, Installments, PaymentMode, SocietyId) VALUES 
('18181818-1818-1818-1818-181818181818', 'LOAN_000001', '11111111-1111-1111-1111-111111111111', '2024-01-15', 'EDP003', 'Alice Member', 100000, 5000, 20, 'Cheque', '12121212-1212-1212-1212-121212121212'),
('19191919-1919-1919-1919-191919191919', 'LOAN_000002', '22222222-2222-2222-2222-222222222222', '2024-02-01', 'EDP004', 'Bob Member', 50000, 2500, 20, 'Cash', '12121212-1212-1212-1212-121212121212');

-- Sample Vouchers
INSERT INTO Vouchers (Id, VoucherNo, VoucherTypeId, Date, Narration, TotalDebit, TotalCredit, SocietyId) VALUES 
('1a1a1a1a-1a1a-1a1a-1a1a-1a1a1a1a1a1a', 'VCH_000001', 'dddddddd-dddd-dddd-dddd-dddddddddddd', '2024-01-15', 'Loan disbursement to Alice', 100000, 100000, '12121212-1212-1212-1212-121212121212'),
('1b1b1b1b-1b1b-1b1b-1b1b-1b1b1b1b1b1b', 'VCH_000002', 'eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', '2024-01-20', 'Receipt from member contribution', 25000, 25000, '12121212-1212-1212-1212-121212121212');

-- Sample Voucher Lines
INSERT INTO VoucherLines (Id, VoucherId, ParticularsName, Debit, Credit, DbCr) VALUES 
('1c1c1c1c-1c1c-1c1c-1c1c-1c1c1c1c1c1c', '1a1a1a1a-1a1a-1a1a-1a1a-1a1a1a1a1a1a', 'Loan Account', 100000, 0, 'Debit'),
('1d1d1d1d-1d1d-1d1d-1d1d-1d1d1d1d1d1d', '1a1a1a1a-1a1a-1a1a-1a1a-1a1a1a1a1a1a', 'Cash Account', 0, 100000, 'Credit'),
('1e1e1e1e-1e1e-1e1e-1e1e-1e1e1e1e1e1e', '1b1b1b1b-1b1b-1b1b-1b1b-1b1b1b1b1b1b', 'Cash Account', 25000, 0, 'Debit'),
('1f1f1f1f-1f1f-1f1f-1f1f-1f1f1f1f1f1f', '1b1b1b1b-1b1b-1b1b-1b1b-1b1b1b1b1b1b', 'Member Contribution', 0, 25000, 'Credit');

-- Sample Monthly Demand
INSERT INTO MonthlyDemandHeaders (Id, MonthId, YearValue, TotalAmount, TotalMembers, SocietyId) VALUES 
('20202020-2020-2020-2020-202020202020', '40404040-4040-4040-4040-404040404040', 2024, 75000, 3, '12121212-1212-1212-1212-121212121212');

INSERT INTO MonthlyDemandRows (Id, HeaderId, EDPNo, MemberName, LoanAmt, CD, Loan, Interest) VALUES 
('21212121-2121-2121-2121-212121212121', '20202020-2020-2020-2020-202020202020', 'EDP003', 'Alice Member', 100000, 0, 5000, 1000),
('22222222-2222-2222-2222-222222222222', '20202020-2020-2020-2020-202020202020', 'EDP004', 'Bob Member', 50000, 0, 2500, 500),
('23232323-2323-2323-2323-232323232323', '20202020-2020-2020-2020-202020202020', 'EDP005', 'Charlie Member', 0, 15000, 0, 0);

PRINT 'Sample data inserted successfully!';
PRINT 'Default login: admin/admin';
GO
