using System;

internal class UserInput{
    public string GetDateTimeInput(string message){
        Console.WriteLine(message);
        string dateInput = Console.ReadLine();
        return dateInput;
    }

    public int GetNumberInput(string message){
        Console.WriteLine(message);
        string number_string = Console.ReadLine();
        if(Int32.TryParse(number_string, out int number)) return number;
        return -1;
    }
}