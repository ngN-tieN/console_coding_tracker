using System;
using Microsoft.Data.Sqlite;

internal class CrudController{
    static DatabaseService db = new();
    
    public static void Insert(){
        Console.Clear();
        string StartTime = UserInput.GetDateTimeInput
                        (
                            "\n\nPlease insert the start time you want to Insert:" 
                            + "(Format MM-DD-YY hh:mm). Type 0 to return to main menu"
                        ); 
        if(StartTime == "0") return;
        
        string EndTime = UserInput.GetDateTimeInput
                        (
                         "\n\nPlease insert the end time you want to Insert:" 
                         + "(Format MM-DD-YY hh:mm). Type 0 to return to main menu"
                        ); 
        if(EndTime =="0") return;
        
        if(!(ValidationService.ValDateTimeInput(StartTime) 
            && ValidationService.ValDateTimeInput(EndTime))) 
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
        int Id = UserInput.GetNumberInput
                (
                "\n\nPlease insert the id you want to update:"
                 + "(Format DD-MM-YY hh:mm). Type 0 to return to main menu"
                ); 
        if(Id == 0) return;
        if(Id == -1) 
        {
            Console.WriteLine("Invalid input. Return to main menu.");
            return;
        }
        
        string StartTime = UserInput.GetDateTimeInput
                        (
                            "\n\nPlease insert the start time you want to update:" 
                            +"(Format MM-DD-YY hh:mm). Type 0 to return to main menu"
                        ); 
        if(!ValidationService.ValDateTimeInput(StartTime)) 
        {
            Console.WriteLine("Wrong format, return to main menu");
            return;
        }    
        string EndTime = UserInput.GetDateTimeInput
                        (
                         "\n\nPlease insert the end time you want to update:" 
                         + "(Format MM-DD-YY hh:mm). Type 0 to return to main menu"
                        );

        if(!ValidationService.ValDateTimeInput(EndTime)) 
        {
            Console.WriteLine("Wrong format, return to main menu");
            return;
        }    
        int Duration = CalculateDuration(StartTime, EndTime);

        if(db.UpdateDatabase(Id:Id, StartTime:StartTime, EndTime:EndTime, Duration:Duration))
        {
            Console.WriteLine($"Updated record with ID:{Id}");
            return;
        }
        Console.WriteLine($"UPDATE - Record with ID:{Id} not found.");


    }

    public static void Delete(){
        Console.Clear();
        GetAllRecords();
        int Id = UserInput.GetNumberInput
                (
                "\n\nPlease insert the id you want to delete:"
                +"(Format DD-MM-YY hh:mm). Type 0 to return to main menu"
                ); 
        if(Id == 0) return;
        
        if(Id == -1) 
        {
            Console.WriteLine("Invalid input. Return to main menu.");
            return;
        }

        if(db.DeleteDatabase(Id:Id))
        {
            Console.WriteLine($"Deleted record with ID:{Id}");
            return;
        }
        Console.WriteLine($"DELETE - Record with ID:{Id} not found.");
    }
    
}