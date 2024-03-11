// See https://aka.ms/new-console-template for more information
using System;

class codingTimeLoggerApp{
    

    public static void Main(){
        //Initialize and add some dummy data to sqlite db
        DatabaseService dbService = new();
        CrudController controller = new();
        dbService.InitDatabaseSQLite();

        //
        controller.PrintConsole();
    }
}