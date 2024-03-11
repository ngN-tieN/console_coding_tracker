using System;
using Microsoft.Data.Sqlite;

internal class CrudController{
    static ValidationService val = new();
    static UserInput input = new();

    static DatabaseService db = new();
    public void PrintConsole(){
        Console.Clear();
        bool closeApp = false;
        while(!closeApp)
        {
            Console.WriteLine("\n\n\t\t\tMAIN MENU");
                Console.WriteLine("\n\t\t\tWhat would you like to do?");
                Console.WriteLine("\nType 0 to close app.");
                Console.WriteLine("Type 1 to View all records.");
                Console.WriteLine("Type 2 to Insert record.");
                Console.WriteLine("Type 3 to Delete record.");
                Console.WriteLine("Type 4 to Update record.");
                Console.WriteLine("__________________________________\n");
                string commandInput = Console.ReadLine(); 

                switch(commandInput)
                {
                    case "0":
                        closeApp = true; 
                        break;
                    case "1":
                        GetAllRecords();
                        break;
                    case "2":
                        Insert();
                        break;
                    // case "3":
                    //     Delete();
                    //     break;
                    case "4":
                        Update();
                        break;
                    default:
                        Console.WriteLine("Please enter a proper number!");
                        break;
                    
                } 

        } 
    } 
    public static void Insert(){
        Console.Clear();
        string StartTime = input.GetDateTimeInput("\n\nPlease insert the start time: (Format DD-MM-YY hh:mm). Type 0 to return to main menu"); 
        if(StartTime == "0") return;
        string EndTime = input.GetDateTimeInput("\n\nPlease insert the end time: (Format DD-MM-YY hh:mm). Type 0 to return to main menu");
        if(EndTime =="0") return;
        if(!(val.ValDateTimeInput(StartTime) 
            && val.ValDateTimeInput(EndTime))) 
            {
                Console.WriteLine("Wrong format, return to main menu");
                return;
            }    
        int Duration = CalculateDuration(StartTime:StartTime, EndTime:EndTime);    
        db.InsertDatabaseSQLite(StartTime:StartTime, EndTime:EndTime, Duration:Duration);


    }
    internal static int CalculateDuration(string StartTime, string EndTime){
        var totalHours = (DateTime.Parse(EndTime) - DateTime.Parse(StartTime)).TotalHours;
        return (int) totalHours;
    }

    public static void GetAllRecords(){
        Console.Clear();
        db.SelectAllRecord();
    }

    public static void Update(){
        Console.Clear();
        GetAllRecords();
        int Id = input.GetNumberInput("\n\nPlease insert the id you want to update: (Format DD-MM-YY hh:mm). Type 0 to return to main menu"); 
        if(Id == 0) return;
        if(Id == -1) 
        {
            Console.WriteLine("Invalid input. Return to main menu.");
        }
        
        string StartTime = input.GetDateTimeInput("\n\nPlease insert the start time you want to update: (Format MM-DD-YY hh:mm). Type 0 to return to main menu"); 
        string EndTime = input.GetDateTimeInput("\n\nPlease insert the end time you want to update: (Format MM-DD-YY hh:mm). Type 0 to return to main menu");
        if(!(val.ValDateTimeInput(StartTime) 
            && val.ValDateTimeInput(EndTime))) 
        {
            Console.WriteLine("Wrong format, return to main menu");
            return;
        }    
        int Duration = CalculateDuration(StartTime, EndTime);
        if(db.UpdateDatabase(Id:Id, StartTime:StartTime, EndTime:EndTime, Duration:Duration))
        {
            Console.WriteLine($"Update record with ID:{Id}");
            return;
        }
        Console.WriteLine($"Record with ID:{Id} not found.");


    }

    
}