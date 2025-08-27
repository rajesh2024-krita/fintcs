
#!/bin/bash

echo "Setting up Fintcs PostgreSQL Database..."

# Check if DATABASE_URL environment variable exists
if [ -z "$DATABASE_URL" ]; then
    echo "Error: DATABASE_URL environment variable not found."
    echo "Please create a PostgreSQL database in Replit and set the connection string."
    echo "Go to the Database tab and create a new PostgreSQL database."
    exit 1
fi

echo "DATABASE_URL found: $DATABASE_URL"

# Extract connection details from DATABASE_URL
DB_HOST=$(echo $DATABASE_URL | sed 's/.*@\([^:]*\):.*/\1/')
DB_PORT=$(echo $DATABASE_URL | sed 's/.*:\([0-9]*\)\/.*/\1/')
DB_NAME=$(echo $DATABASE_URL | sed 's/.*\/\([^?]*\).*/\1/')
DB_USER=$(echo $DATABASE_URL | sed 's/.*:\/\/\([^:]*\):.*/\1/')
DB_PASS=$(echo $DATABASE_URL | sed 's/.*:\/\/[^:]*:\([^@]*\)@.*/\1/')

echo "Connecting to database: $DB_NAME at $DB_HOST:$DB_PORT"

# Install PostgreSQL client if not available
if ! command -v psql &> /dev/null; then
    echo "Installing PostgreSQL client..."
    apt-get update && apt-get install -y postgresql-client
fi

# Run schema creation
echo "Creating database schema..."
psql "$DATABASE_URL" -f database/schema.sql

if [ $? -eq 0 ]; then
    echo "Schema created successfully!"
else
    echo "Error creating schema. Please check the connection and try again."
    exit 1
fi

# Run sample data insertion
echo "Inserting sample data..."
psql "$DATABASE_URL" -f database/sample_data.sql

if [ $? -eq 0 ]; then
    echo "Sample data inserted successfully!"
    echo ""
    echo "Database setup complete! Your Fintcs database now contains:"
    echo "- 3 Societies (Green Valley Apartments, Sunrise Residency, Ocean View Society)"
    echo "- 8 Members across all societies"
    echo "- 4 Loans with different types"
    echo "- 4 Vouchers with accounting entries"
    echo "- Monthly demand data for January-February 2024"
    echo "- Lookup data for loan types, banks, voucher types, and months"
    echo ""
    echo "Default login credentials:"
    echo "Username: admin"
    echo "Password: admin"
else
    echo "Error inserting sample data. Schema was created but data insertion failed."
    exit 1
fi
