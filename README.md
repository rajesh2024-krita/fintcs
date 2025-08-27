
# Fintcs - Finance Management System

A comprehensive finance management system for societies with role-based access control.

## Architecture
- **Frontend**: Angular v18 (Standalone APIs) + Tailwind CSS
- **Backend**: ASP.NET Core Web API (C#)
- **Database**: SQL Server (Fintcs database on localhost)

## Roles
1. **Super Admin** - System-wide management
2. **Society Admin** - Society-specific management
3. **User** - Read-only access to society data
4. **Member** - Personal profile and loan management

## Default Login
- Username: `admin`
- Password: `admin`

## Setup Instructions

### Prerequisites
- Node.js (v18+)
- .NET 8 SDK
- SQL Server (LocalDB or full instance)

### Frontend Setup (Angular)
```bash
# Install Angular CLI globally
npm install -g @angular/cli

# Install dependencies
cd frontend
npm install

# Start development server
ng serve
```

### Backend Setup (ASP.NET Core)
```bash
cd backend

# Restore packages
dotnet restore

# Update connection string in appsettings.json if needed
# Default: "Server=localhost;Database=Fintcs;Trusted_Connection=true;"

# Apply database migrations
dotnet ef database update

# Run the API
dotnet run
```

### Database
The system will automatically create the Fintcs database and seed initial data including:
- Super Admin (admin/admin)
- Lookup data (loan types, banks, voucher types, etc.)

## Features
- JWT Authentication with role-based authorization
- Society Management with approval workflows
- User and Member Management
- Loan Processing and Reporting
- Monthly Demand Processing
- Voucher Creation and Management
- File uploads for member photos/signatures
- Export to Excel functionality
- Responsive Tailwind CSS design

## Development Notes
- Frontend runs on http://localhost:4200
- Backend API runs on http://localhost:5000
- All passwords are securely hashed
- Role-based route guards protect sensitive areas
- Auto-generated IDs for members, loans, vouchers
