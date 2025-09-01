using System.ComponentModel.Design;
using System.Runtime.InteropServices.ComTypes;

var date = DateTime.UtcNow;
string name = GetName();
int score = 0;
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
    for (var i = 0; i < 5; i++)
    {
        var divisionNumbers = GetDivisionNumbers();
        int answer = divisionNumbers[0] / divisionNumbers[1];
        Console.WriteLine($"{divisionNumbers[0]} / {divisionNumbers[1]} = ");
        var userAnswer = Console.ReadLine();
        
        if (answer.ToString() == userAnswer)
        {
            Console.WriteLine("Correct");
            score++;
            Console.WriteLine($"score: {score}\n");
        }
        else
        {
            Console.WriteLine("Incorrect");
        }
    }
    
}

if (score >= 3) 
{ Console.WriteLine("YOU WON!"); } 
else {
    Console.WriteLine( "you lost..."); 
}
;

void SubtractionGame(string message)
{
    Console.WriteLine(message);
}

void AdditionGame(string message)
{
    Console.WriteLine(message);
}

int[] GetDivisionNumbers()
{
    var random = new Random();
    var firstNumber = random.Next(2, 99);
    var secondNumber = random.Next(2, 99);
    
    var result = new int[2];
    
    var divResult = firstNumber / (double)secondNumber;

    // n % 1 == 0 checks if anything is past decimal point; true if int, false if decimal
    // alternativley use while(firstNumber % secondNumber != 0)
    while ((divResult) % 1 != 0)
    {
        firstNumber = random.Next(2, 99);
        secondNumber = random.Next(2, 99);

        divResult = firstNumber / (double)secondNumber;;
    }

    result[0] = firstNumber;
    result[1] = secondNumber;
    
    return result;
}

//GetDivisionNumbers();


   
// game: two random numbers are presented with an operation
// player must provide answer, game gives feedback
// game loops a set number of times until deciding player win/loose - best 3/5
// for division, only provide random numbers that result in integers
// idea - keep generating numbers between 0-99 until result is an integer