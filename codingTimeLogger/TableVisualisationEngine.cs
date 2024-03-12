class TableVisualization{
    public void PrintConsole(){
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
                        CrudController.GetAllRecords();
                        break;
                    case "2":
                        CrudController.Insert();
                        break;
                    case "3":
                        CrudController.Delete();
                        break;
                    case "4":
                        CrudController.Update();
                        break;
                    default:
                        Console.WriteLine("Please enter a proper number!");
                        break;
                    
                } 

        } 
    }
}