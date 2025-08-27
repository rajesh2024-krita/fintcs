
-- Fintcs Sample Data
-- Insert LookupItems first
INSERT INTO LookupItems (Id, Code, Name, Type) VALUES 
-- Loan Types
('11111111-1111-1111-1111-111111111111', 'HOME', 'Home Loan', 'LoanType'),
('22222222-2222-2222-2222-222222222222', 'PERSONAL', 'Personal Loan', 'LoanType'),
('33333333-3333-3333-3333-333333333333', 'VEHICLE', 'Vehicle Loan', 'LoanType'),
('44444444-4444-4444-4444-444444444444', 'EDUCATION', 'Education Loan', 'LoanType'),

-- Banks
('55555555-5555-5555-5555-555555555555', 'SBI', 'State Bank of India', 'Bank'),
('66666666-6666-6666-6666-666666666666', 'HDFC', 'HDFC Bank', 'Bank'),
('77777777-7777-7777-7777-777777777777', 'ICICI', 'ICICI Bank', 'Bank'),
('88888888-8888-8888-8888-888888888888', 'AXIS', 'Axis Bank', 'Bank'),

-- Voucher Types
('99999999-9999-9999-9999-999999999999', 'RECEIPT', 'Receipt Voucher', 'VoucherType'),
('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'PAYMENT', 'Payment Voucher', 'VoucherType'),
('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'JOURNAL', 'Journal Voucher', 'VoucherType'),

-- Months
('cccccccc-cccc-cccc-cccc-cccccccccccc', 'JAN', 'January', 'Month'),
('dddddddd-dddd-dddd-dddd-dddddddddddd', 'FEB', 'February', 'Month'),
('eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'MAR', 'March', 'Month'),
('ffffffff-ffff-ffff-ffff-ffffffffffff', 'APR', 'April', 'Month'),
('00000000-0000-0000-0000-000000000001', 'MAY', 'May', 'Month'),
('00000000-0000-0000-0000-000000000002', 'JUN', 'June', 'Month'),
('00000000-0000-0000-0000-000000000003', 'JUL', 'July', 'Month'),
('00000000-0000-0000-0000-000000000004', 'AUG', 'August', 'Month'),
('00000000-0000-0000-0000-000000000005', 'SEP', 'September', 'Month'),
('00000000-0000-0000-0000-000000000006', 'OCT', 'October', 'Month'),
('00000000-0000-0000-0000-000000000007', 'NOV', 'November', 'Month'),
('00000000-0000-0000-0000-000000000008', 'DEC', 'December', 'Month');

-- Insert Super Admin
INSERT INTO SuperAdmins (Id, Username, PasswordHash, Name) VALUES 
('10000000-0000-0000-0000-000000000001', 'admin', '$2a$11$dummy.hash.for.admin.password', 'System Administrator');

-- Insert Societies
INSERT INTO Societies (Id, Code, Name, Address, Phone, Email, RegistrationNumber) VALUES 
('20000000-0000-0000-0000-000000000001', 'SOC001', 'Green Valley Apartments', '123 Main Street, Mumbai, Maharashtra 400001', '+91-9876543210', 'admin@greenvalley.com', 'REG123456'),
('20000000-0000-0000-0000-000000000002', 'SOC002', 'Sunrise Residency', '456 Park Avenue, Delhi, Delhi 110001', '+91-9876543211', 'info@sunriseresidency.com', 'REG789012'),
('20000000-0000-0000-0000-000000000003', 'SOC003', 'Ocean View Society', '789 Beach Road, Chennai, Tamil Nadu 600001', '+91-9876543212', 'contact@oceanview.com', 'REG345678');

-- Insert App Users
INSERT INTO AppUsers (Id, Username, PasswordHash, Name, Email, Phone, Role, SocietyId) VALUES 
('30000000-0000-0000-0000-000000000001', 'society1admin', '$2a$11$dummy.hash.for.society1.admin', 'Rajesh Kumar', 'rajesh@greenvalley.com', '+91-9876543213', 'SocietyAdmin', '20000000-0000-0000-0000-000000000001'),
('30000000-0000-0000-0000-000000000002', 'society1user', '$2a$11$dummy.hash.for.society1.user', 'Priya Sharma', 'priya@greenvalley.com', '+91-9876543214', 'User', '20000000-0000-0000-0000-000000000001'),
('30000000-0000-0000-0000-000000000003', 'society2admin', '$2a$11$dummy.hash.for.society2.admin', 'Amit Patel', 'amit@sunriseresidency.com', '+91-9876543215', 'SocietyAdmin', '20000000-0000-0000-0000-000000000002'),
('30000000-0000-0000-0000-000000000004', 'society3admin', '$2a$11$dummy.hash.for.society3.admin', 'Sunita Rao', 'sunita@oceanview.com', '+91-9876543216', 'SocietyAdmin', '20000000-0000-0000-0000-000000000003');

-- Insert Members
INSERT INTO Members (Id, SocietyId, MemNo, MemberCode, Name, FatherName, Address, Phone, Email, JoiningDate) VALUES 
-- Green Valley Apartments Members
('40000000-0000-0000-0000-000000000001', '20000000-0000-0000-0000-000000000001', 'MEM001', 'GV001', 'Suresh Gupta', 'Ram Gupta', 'Flat A-101, Green Valley Apartments', '+91-9876543217', 'suresh@email.com', '2020-01-15'),
('40000000-0000-0000-0000-000000000002', '20000000-0000-0000-0000-000000000001', 'MEM002', 'GV002', 'Meera Singh', 'Raj Singh', 'Flat A-102, Green Valley Apartments', '+91-9876543218', 'meera@email.com', '2020-02-20'),
('40000000-0000-0000-0000-000000000003', '20000000-0000-0000-0000-000000000001', 'MEM003', 'GV003', 'Ravi Agarwal', 'Mohan Agarwal', 'Flat A-103, Green Valley Apartments', '+91-9876543219', 'ravi@email.com', '2020-03-10'),
('40000000-0000-0000-0000-000000000004', '20000000-0000-0000-0000-000000000001', 'MEM004', 'GV004', 'Kavita Sharma', 'Vinod Sharma', 'Flat A-104, Green Valley Apartments', '+91-9876543220', 'kavita@email.com', '2020-04-05'),

-- Sunrise Residency Members
('40000000-0000-0000-0000-000000000005', '20000000-0000-0000-0000-000000000002', 'MEM001', 'SR001', 'Deepak Joshi', 'Prakash Joshi', 'Flat B-201, Sunrise Residency', '+91-9876543221', 'deepak@email.com', '2021-01-10'),
('40000000-0000-0000-0000-000000000006', '20000000-0000-0000-0000-000000000002', 'MEM002', 'SR002', 'Anita Verma', 'Sunil Verma', 'Flat B-202, Sunrise Residency', '+91-9876543222', 'anita@email.com', '2021-02-15'),

-- Ocean View Society Members
('40000000-0000-0000-0000-000000000007', '20000000-0000-0000-0000-000000000003', 'MEM001', 'OV001', 'Vikram Reddy', 'Sekhar Reddy', 'Villa C-301, Ocean View Society', '+91-9876543223', 'vikram@email.com', '2019-12-01'),
('40000000-0000-0000-0000-000000000008', '20000000-0000-0000-0000-000000000003', 'MEM002', 'OV002', 'Lakshmi Nair', 'Krishna Nair', 'Villa C-302, Ocean View Society', '+91-9876543224', 'lakshmi@email.com', '2020-01-20');

-- Insert Loans
INSERT INTO Loans (Id, SocietyId, MemberId, LoanTypeId, BankId, Amount, InterestRate, StartDate, EndDate, Status, Description) VALUES 
('50000000-0000-0000-0000-000000000001', '20000000-0000-0000-0000-000000000001', '40000000-0000-0000-0000-000000000001', '11111111-1111-1111-1111-111111111111', '55555555-5555-5555-5555-555555555555', 2500000.00, 8.5, '2023-01-15', '2043-01-15', 'Active', 'Home loan for apartment purchase'),
('50000000-0000-0000-0000-000000000002', '20000000-0000-0000-0000-000000000001', '40000000-0000-0000-0000-000000000002', '22222222-2222-2222-2222-222222222222', '66666666-6666-6666-6666-666666666666', 500000.00, 12.0, '2023-06-01', '2028-06-01', 'Active', 'Personal loan for home renovation'),
('50000000-0000-0000-0000-000000000003', '20000000-0000-0000-0000-000000000002', '40000000-0000-0000-0000-000000000005', '33333333-3333-3333-3333-333333333333', '77777777-7777-7777-7777-777777777777', 800000.00, 9.5, '2023-03-20', '2030-03-20', 'Active', 'Car loan for new vehicle'),
('50000000-0000-0000-0000-000000000004', '20000000-0000-0000-0000-000000000003', '40000000-0000-0000-0000-000000000007', '44444444-4444-4444-4444-444444444444', '88888888-8888-8888-8888-888888888888', 300000.00, 10.0, '2023-08-10', '2033-08-10', 'Active', 'Education loan for child');

-- Insert Vouchers
INSERT INTO Vouchers (Id, SocietyId, VoucherNo, VoucherTypeId, Date, Description, TotalAmount) VALUES 
('60000000-0000-0000-0000-000000000001', '20000000-0000-0000-0000-000000000001', 'REC001', '99999999-9999-9999-9999-999999999999', '2024-01-15', 'Monthly maintenance collection - January 2024', 50000.00),
('60000000-0000-0000-0000-000000000002', '20000000-0000-0000-0000-000000000001', 'PAY001', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '2024-01-20', 'Electricity bill payment', 15000.00),
('60000000-0000-0000-0000-000000000003', '20000000-0000-0000-0000-000000000002', 'REC001', '99999999-9999-9999-9999-999999999999', '2024-01-10', 'Security deposit collection', 25000.00),
('60000000-0000-0000-0000-000000000004', '20000000-0000-0000-0000-000000000003', 'JOU001', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '2024-01-25', 'Maintenance fund transfer', 30000.00);

-- Insert Voucher Lines
INSERT INTO VoucherLines (Id, VoucherId, Description, DebitAmount, CreditAmount) VALUES 
-- For REC001 - Green Valley
('70000000-0000-0000-0000-000000000001', '60000000-0000-0000-0000-000000000001', 'Cash received from members', 50000.00, 0.00),
('70000000-0000-0000-0000-000000000002', '60000000-0000-0000-0000-000000000001', 'Maintenance income', 0.00, 50000.00),

-- For PAY001 - Green Valley
('70000000-0000-0000-0000-000000000003', '60000000-0000-0000-0000-000000000002', 'Electricity expense', 15000.00, 0.00),
('70000000-0000-0000-0000-000000000004', '60000000-0000-0000-0000-000000000002', 'Cash payment', 0.00, 15000.00),

-- For REC001 - Sunrise Residency
('70000000-0000-0000-0000-000000000005', '60000000-0000-0000-0000-000000000003', 'Bank account', 25000.00, 0.00),
('70000000-0000-0000-0000-000000000006', '60000000-0000-0000-0000-000000000003', 'Security deposit liability', 0.00, 25000.00),

-- For JOU001 - Ocean View
('70000000-0000-0000-0000-000000000007', '60000000-0000-0000-0000-000000000004', 'Reserve fund', 30000.00, 0.00),
('70000000-0000-0000-0000-000000000008', '60000000-0000-0000-0000-000000000004', 'Maintenance fund', 0.00, 30000.00);

-- Insert Monthly Demand Headers
INSERT INTO MonthlyDemandHeaders (Id, SocietyId, MonthId, Year, TotalAmount) VALUES 
('80000000-0000-0000-0000-000000000001', '20000000-0000-0000-0000-000000000001', 'cccccccc-cccc-cccc-cccc-cccccccccccc', 2024, 40000.00), -- January 2024 - Green Valley
('80000000-0000-0000-0000-000000000002', '20000000-0000-0000-0000-000000000001', 'dddddddd-dddd-dddd-dddd-dddddddddddd', 2024, 40000.00), -- February 2024 - Green Valley
('80000000-0000-0000-0000-000000000003', '20000000-0000-0000-0000-000000000002', 'cccccccc-cccc-cccc-cccc-cccccccccccc', 2024, 20000.00), -- January 2024 - Sunrise
('80000000-0000-0000-0000-000000000004', '20000000-0000-0000-0000-000000000003', 'cccccccc-cccc-cccc-cccc-cccccccccccc', 2024, 16000.00); -- January 2024 - Ocean View

-- Insert Monthly Demand Rows
INSERT INTO MonthlyDemandRows (Id, HeaderId, MemberId, Amount, IsPaid, PaidDate) VALUES 
-- January 2024 - Green Valley Apartments
('90000000-0000-0000-0000-000000000001', '80000000-0000-0000-0000-000000000001', '40000000-0000-0000-0000-000000000001', 10000.00, true, '2024-01-05'),
('90000000-0000-0000-0000-000000000002', '80000000-0000-0000-0000-000000000001', '40000000-0000-0000-0000-000000000002', 10000.00, true, '2024-01-08'),
('90000000-0000-0000-0000-000000000003', '80000000-0000-0000-0000-000000000001', '40000000-0000-0000-0000-000000000003', 10000.00, false, null),
('90000000-0000-0000-0000-000000000004', '80000000-0000-0000-0000-000000000001', '40000000-0000-0000-0000-000000000004', 10000.00, true, '2024-01-12'),

-- February 2024 - Green Valley Apartments
('90000000-0000-0000-0000-000000000005', '80000000-0000-0000-0000-000000000002', '40000000-0000-0000-0000-000000000001', 10000.00, false, null),
('90000000-0000-0000-0000-000000000006', '80000000-0000-0000-0000-000000000002', '40000000-0000-0000-0000-000000000002', 10000.00, true, '2024-02-03'),
('90000000-0000-0000-0000-000000000007', '80000000-0000-0000-0000-000000000002', '40000000-0000-0000-0000-000000000003', 10000.00, false, null),
('90000000-0000-0000-0000-000000000008', '80000000-0000-0000-0000-000000000002', '40000000-0000-0000-0000-000000000004', 10000.00, false, null),

-- January 2024 - Sunrise Residency
('90000000-0000-0000-0000-000000000009', '80000000-0000-0000-0000-000000000003', '40000000-0000-0000-0000-000000000005', 10000.00, true, '2024-01-07'),
('90000000-0000-0000-0000-000000000010', '80000000-0000-0000-0000-000000000003', '40000000-0000-0000-0000-000000000006', 10000.00, true, '2024-01-15'),

-- January 2024 - Ocean View Society
('90000000-0000-0000-0000-000000000011', '80000000-0000-0000-0000-000000000004', '40000000-0000-0000-0000-000000000007', 8000.00, true, '2024-01-02'),
('90000000-0000-0000-0000-000000000012', '80000000-0000-0000-0000-000000000004', '40000000-0000-0000-0000-000000000008', 8000.00, false, null);

-- Insert some Pending Edits for demonstration
INSERT INTO PendingEdits (Id, SocietyId, TableName, RecordId, FieldName, OldValue, NewValue, RequestedBy, Status) VALUES 
('a0000000-0000-0000-0000-000000000001', '20000000-0000-0000-0000-000000000001', 'Members', '40000000-0000-0000-0000-000000000001', 'Phone', '+91-9876543217', '+91-9876543299', 'Suresh Gupta', 'Pending'),
('a0000000-0000-0000-0000-000000000002', '20000000-0000-0000-0000-000000000001', 'Members', '40000000-0000-0000-0000-000000000002', 'Email', 'meera@email.com', 'meera.singh@newemail.com', 'Meera Singh', 'Approved'),
('a0000000-0000-0000-0000-000000000003', '20000000-0000-0000-0000-000000000002', 'Members', '40000000-0000-0000-0000-000000000005', 'Address', 'Flat B-201, Sunrise Residency', 'Flat B-201, Sunrise Residency, Near Metro Station', 'Deepak Joshi', 'Pending');

-- Display summary
SELECT 'Database schema and sample data inserted successfully!' as Status;
