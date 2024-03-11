using System;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
internal class ValidationService{

    
    
    
    public bool ValDateTimeInput(string DateTimeInput){
        Regex DateRegex = new Regex("(\\d{2}-\\d{2}-\\d{2} \\d{2}:\\d{2})", RegexOptions.IgnoreCase);
        return DateRegex.IsMatch(DateTimeInput);
    }

    
}