import pyodbc
import pandas as pd

# Define the connection details
server = 'localhost'
database = 'library'
username = 'sa'
password = 'NewStrongPassword123'
port = 1433

# Establish the connection
conn_str = f'DRIVER={{ODBC Driver 17 for SQL Server}};SERVER={server},{port};DATABASE={database};UID={username};PWD={password}'

# Connect to the database
conn = pyodbc.connect(conn_str)

# Query data from each table
query_authors = 'SELECT * FROM Authors'
query_books = 'SELECT * FROM Books'
query_members = 'SELECT * FROM Members'
query_loans = 'SELECT * FROM Loans'

# Read data into pandas DataFrames
df_authors = pd.read_sql_query(query_authors, conn)
df_books = pd.read_sql_query(query_books, conn)
df_members = pd.read_sql_query(query_members, conn)
df_loans = pd.read_sql_query(query_loans, conn)

# Export the data to an Excel file
output_path = 'library_data.xlsx'

# Use ExcelWriter to save multiple DataFrames to different sheets
with pd.ExcelWriter(output_path, engine='openpyxl') as writer:
    df_authors.to_excel(writer, sheet_name='Authors', index=False)
    df_books.to_excel(writer, sheet_name='Books', index=False)
    df_members.to_excel(writer, sheet_name='Members', index=False)
    df_loans.to_excel(writer, sheet_name='Loans', index=False)

# Close the connection
conn.close()

print(f'Data exported successfully to {output_path}')
