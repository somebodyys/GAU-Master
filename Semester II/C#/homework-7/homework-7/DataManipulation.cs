namespace homework_7;
using System;
using System.Data;
using System.Data.SqlClient;

public class DataManipulation
{
    public static void Run()
    {
        string connectionString = "Server=localhost,1433;Database=ImaginaryWorld;User=sa;Password=1234;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            DataSet dataSet = new DataSet("ImaginaryWorld");
            DataTable creaturesTable = new DataTable("Creatures");
            
            creaturesTable.Columns.Add(new DataColumn("CreatureID", typeof(int)) { AutoIncrement = true });
            creaturesTable.Columns.Add("Name", typeof(string));
            creaturesTable.Columns.Add("Type", typeof(string));
            creaturesTable.Columns.Add("Habitat", typeof(string));
            creaturesTable.Columns.Add("Age", typeof(int));
            creaturesTable.Columns.Add("Description", typeof(string));
            
            dataSet.Tables.Add(creaturesTable);
            
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Creatures", connection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            commandBuilder.DataAdapter = adapter;

            commandBuilder.GetUpdateCommand();
            commandBuilder.GetInsertCommand();
            commandBuilder.GetDeleteCommand();
            
            adapter.Fill(dataSet, "Creatures");
            
            Console.WriteLine("Creatures before changes:");
            DisplayTable(dataSet.Tables["Creatures"]);
            
            DataRow newCreature = creaturesTable.NewRow();
            newCreature["Name"] = "Phoenix";
            newCreature["Type"] = "Mythical";
            newCreature["Habitat"] = "Mountains";
            newCreature["Age"] = 500;
            newCreature["Description"] = "A mythical bird that regenerates.";
            creaturesTable.Rows.Add(newCreature);
            
            adapter.Update(dataSet, "Creatures");
            
            Console.WriteLine("Creatures after adding a new row:");
            DisplayTable(dataSet.Tables["Creatures"]);
            
            DataRow creatureToModify = creaturesTable.Rows[0];
            creatureToModify["Age"] = 1000;
            
            adapter.Update(dataSet, "Creatures");
            
            Console.WriteLine("Creatures after modification:");
            DisplayTable(dataSet.Tables["Creatures"]);

           
            string creatureName = "Phoenix";
            DataRow[] foundRows = creaturesTable.Select($"Name = '{creatureName}'");

            Console.WriteLine($"Creatures with the name '{creatureName}':");
            foreach (DataRow row in foundRows)
            {
                foreach (DataColumn column in creaturesTable.Columns)
                {
                    Console.Write($"{column.ColumnName}: {row[column]} ");
                }
                Console.WriteLine();
            }
        }
    }
    
    private static void DisplayTable(DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            foreach (DataColumn column in table.Columns)
            {
                Console.Write($"{column.ColumnName}: {row[column]} ");
            }
            Console.WriteLine();
        }
    }
}