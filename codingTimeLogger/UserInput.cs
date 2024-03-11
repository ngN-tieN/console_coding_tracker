using System;

internal class UserInput{
    public string GetDateTimeInput(string message){
        Console.WriteLine(message);
        string dateInput = Console.ReadLine();
        return dateInput;
    }
}