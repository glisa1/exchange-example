#!/bin/bash
set -e

# Check if environment variables are set
if [ -z "$APP_DB_NAME" ] || [ -z "$KC_DB_NAME" ]; then
  echo "Error: One or both environment variables are missing (APP_DB_NAME, KC_DB_NAME)."
  exit 1
fi

echo "Creating databases..."

# Use psql to create the databases with the environment variables
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" <<-EOSQL
    CREATE DATABASE "$APP_DB_NAME";
    CREATE DATABASE "$KC_DB_NAME";
EOSQL

echo "Databases created successfully!"
