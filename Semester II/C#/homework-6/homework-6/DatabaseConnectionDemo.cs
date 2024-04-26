namespace homework_6;

using System.Data.SqlClient;

public class DatabaseConnectionDemo
{
    
    // შექმენით პროექტი, სადაც დაამუშავებთ მონაცემთა ბაზას Connected რეჟიმის კლასების გამოყენებით. შეასრულეთ რამდენიმე sql მოთხოვნა.
    public static void Run()
    {
        string connectionString = "Server=localhost,1433;Database=ImaginaryWorld;User=sa;Password=1234;";

        RetrieveData(connectionString);
        InsertData(connectionString);
        UpdateData(connectionString);
        DeleteData(connectionString);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        Console.WriteLine("Enter new creature details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Type: ");
        string type = Console.ReadLine();
        Console.Write("Habitat: ");
        string habitat = Console.ReadLine();
        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Description: ");
        string description = Console.ReadLine();

        AddCreatureWithLocation(connectionString, name, type, habitat, age, description);

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
    
    static void AddCreatureWithLocation(string connectionString, string name, string type, string habitat, int age, string description)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string insertCreatureQuery = "INSERT INTO Creatures (Name, Type, Habitat, Age, Description) VALUES (@Name, @Type, @Habitat, @Age, @Description); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertCreatureCommand = new SqlCommand(insertCreatureQuery, connection, transaction);
                    insertCreatureCommand.Parameters.AddWithValue("@Name", name);
                    insertCreatureCommand.Parameters.AddWithValue("@Type", type);
                    insertCreatureCommand.Parameters.AddWithValue("@Habitat", habitat);
                    insertCreatureCommand.Parameters.AddWithValue("@Age", age);
                    insertCreatureCommand.Parameters.AddWithValue("@Description", description);
                    int creatureId = Convert.ToInt32(insertCreatureCommand.ExecuteScalar());

                    Console.WriteLine("Enter location details:");
                    Console.Write("Location Name: ");
                    string locationName = Console.ReadLine();
                    Console.Write("Terrain Type: ");
                    string terrainType = Console.ReadLine();
                    Console.Write("Climate: ");
                    string climate = Console.ReadLine();
                    Console.Write("Location Description: ");
                    string locationDescription = Console.ReadLine();

                    string insertLocationQuery = "INSERT INTO Locations (Name, TerrainType, Climate, Description) VALUES (@Name, @TerrainType, @Climate, @Description); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertLocationCommand = new SqlCommand(insertLocationQuery, connection, transaction);
                    insertLocationCommand.Parameters.AddWithValue("@Name", locationName);
                    insertLocationCommand.Parameters.AddWithValue("@TerrainType", terrainType);
                    insertLocationCommand.Parameters.AddWithValue("@Climate", climate);
                    insertLocationCommand.Parameters.AddWithValue("@Description", locationDescription);
                    int locationId = Convert.ToInt32(insertLocationCommand.ExecuteScalar());

                    string insertCreatureLocationQuery = "INSERT INTO CreatureLocations (CreatureID, LocationID) VALUES (@CreatureID, @LocationID)";
                    SqlCommand insertCreatureLocationCommand = new SqlCommand(insertCreatureLocationQuery, connection, transaction);
                    insertCreatureLocationCommand.Parameters.AddWithValue("@CreatureID", creatureId);
                    insertCreatureLocationCommand.Parameters.AddWithValue("@LocationID", locationId);
                    insertCreatureLocationCommand.ExecuteNonQuery();

                    transaction.Commit();

                    Console.WriteLine("Creature added with location.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred. Rolling back transaction.");
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                }
            }
        }
}