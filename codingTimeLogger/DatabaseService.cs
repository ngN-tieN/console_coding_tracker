using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using Dapper;

internal class DatabaseService{
    
    static IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
    static IConfigurationSection section = config.GetSection("ConnectionString");

    public static string GetConnectionStringSQLite(){
        return section["sqlite"]; 
    }


    public void InitDatabaseSQLite(){
        using(var connection = new SqliteConnection(GetConnectionStringSQLite())){
            connection.Open();
            var tableCmd = connection.CreateCommand();   
            string commandInput = @"CREATE TABLE IF NOT EXISTS coding_tracker(
	                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    StartTime TEXT,
                                    EndTime TEXT,
                                    Duration INTEGER)";
            tableCmd.CommandText = commandInput;
            tableCmd.ExecuteNonQuery();
            // commandInput = @"INSERT INTO coding_tracker (date, quantity)
            //                  VALUES('21-11-11', 3), ('21-11-12', 4), ('21-11-13', 5)";
            // tableCmd.CommandText = commandInput;                                                                    
            // tableCmd.ExecuteNonQuery();                
            connection.Close();

        }


    }

    public void InsertDatabaseSQLite(string StartTime, string EndTime, int Duration){
        using(var connection = new SqliteConnection(GetConnectionStringSQLite())){
            connection.Open();
            var tableCmd = connection.CreateCommand();
            string commandInput = $"INSERT INTO coding_tracker (StartTime, EndTime, Duration) VALUES (\"{StartTime}\", \"{EndTime}\", {Duration})";
            tableCmd.CommandText = commandInput;
            tableCmd.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void SelectAllRecord(){
        using(var connection = new SqliteConnection(GetConnectionStringSQLite())){
            connection.Open();
            string commandInput =  $"SELECT * FROM coding_tracker";

            var coding_trackers = connection.Query<coding_tracker>(commandInput);

            foreach(var coding_tracker in coding_trackers){
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine($"ID: {coding_tracker.Id} - Start time: {coding_tracker.StartTime} - End time: {coding_tracker.EndTime} - Duration: {coding_tracker.Duration}");
            } 
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }
    }







} 

                