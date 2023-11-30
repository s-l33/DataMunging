
using DataMunging.Client;

Console.WriteLine("Hello, Welcome to Data Munging application. " +
    "Press 'w' for 'weather.dat' or 'f' for the 'football.dat' file result: \n");

Console.Write("File type: ");
string fileType = Console.ReadLine();

DataFinder dataFinder = new();

string result = fileType switch
{
    "w" or "W" => dataFinder.FindSmallestTemperatureDay(),
    "f" or "F" => dataFinder.FindTeamName(),
    _ => "You should type 'w' or 'f'"
};

Console.WriteLine($"Result: {result}");

Console.ReadLine();