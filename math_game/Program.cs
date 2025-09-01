using System.ComponentModel.Design;
var date = DateTime.UtcNow;
string name = GetName();

Menu(name);
string GetName()
{
    Console.WriteLine("Please type your name");
    var name = Console.ReadLine();
    return name;
}

// aparently visual studio has a feature to auto generate a method from context. Refactoring?
void Menu(string name)
{
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine(
        $"Hello {name.ToUpper()}. This is a math game. It's currently {date.DayOfWeek}, which means it's time to code!");
    Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
A - Addition
S- Subtraction
M - Multiplication
D - Division
Q - Quit");
    Console.WriteLine("--------------------------------------------");

    var gameSelected = Console.ReadLine();

    switch (gameSelected.Trim().ToLower())
    {
        case "a":
            AdditionGame("Addiction game selected");
            break;
        case "s":
            SubtractionGame("Subtraction game selected");
            break;
        case "m":
            MultiplicationGame("Multiplication game selected");
            break;
        case "d":
            DivisionGame("Division game selected");
            break;
        case "q":
            Console.WriteLine("Bye!");
            Environment.Exit(1);
            break;
        default:
            Console.WriteLine("You did not enter a valid option");
            Environment.Exit(1);
            break;

    }
        
}

void MultiplicationGame(string messaage)
{
    Console.WriteLine(messaage);
}

void DivisionGame(string message)
{
    Console.WriteLine(message);
}

void SubtractionGame(string message)
{
    Console.WriteLine(message);
}

void AdditionGame(string message)
{
    Console.WriteLine(message);
}

   