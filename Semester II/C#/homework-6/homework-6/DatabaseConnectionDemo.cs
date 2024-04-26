namespace homework_6;

using System.Data.SqlClient;

public class DatabaseConnectionDemo
{
    
    public static void Run()
    {
        string connectionString = "Server=localhost,1433;Database=ImaginaryWorld;User=sa;Password=1234;";

        RetrieveData(connectionString);
        InsertData(connectionString);
        UpdateData(connectionString);
        DeleteData(connectionString);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    
    static void RetrieveData(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Creatures";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Name: {reader["Name"]}, Type: {reader["Type"]}, Habitat: {reader["Habitat"]}, Age: {reader["Age"]}, Description: {reader["Description"]}");
            }

            reader.Close();
        }
    }

    static void InsertData(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Creatures (Name, Type, Habitat, Age, Description) VALUES ('Dragon', 'Mythical', 'Mountains', 1000, 'Breathes fire')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"Rows affected by insert: {rowsAffected}");
        }
    }

    static void UpdateData(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Creatures SET Age = 2000 WHERE Name = 'Dragon'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"Rows affected by update: {rowsAffected}");
        }
    }

    static void DeleteData(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Creatures WHERE Name = 'Dragon'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"Rows affected by delete: {rowsAffected}");
        }
    }
}