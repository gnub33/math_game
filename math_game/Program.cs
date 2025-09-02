using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

/*
 * Currently allows you to choose one mode, each 5 rounds, best 3/5
 * future: eitherm manually switch modes or reprompt user to choose before each round
 * implement play again feature
 * save score between games
 * 
 */


var date = DateTime.UtcNow;

//var games = new List <string>();
// global scope variable, dynamic
List<string> games = new List<string>();


string name = GetName();
int score = 0;

bool playAgain = true;

string GetName()
{
    Console.WriteLine("Please type your name");
    var name = Console.ReadLine();
    return name;
}

do {
    Menu(name);

    Console.WriteLine("\n");

    if (score >= 3) 
    { Console.WriteLine("YOU WON!"); } 
    else {
        Console.WriteLine( "you lost..."); 
    }

    Console.WriteLine("Play again? Enter 'y' or 'n' ");
    string response = Console.ReadLine().ToLower();

    if (response == "n" || response == "no")
    {
        playAgain = false;
    }
    
} 
while (playAgain);


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
            AdditionGame("Addiction game");
            break;
        case "s":
            SubtractionGame("Subtraction game");
            break;
        case "m":
            MultiplicationGame("Multiplication game");
            break;
        case "d":
            DivisionGame("Division game");
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
    Console.Clear();
    Console.WriteLine(messaage);
    
    int[] operands = GetNumbers();
    var answer = 0;
    
    string userAnswer = "";
    
    for (int i = 0; i < 5; i++)
    {
        answer = operands[0] * operands[1];
    
        Console.WriteLine($"{operands[0]} * {operands[1]} = ");
        userAnswer = Console.ReadLine();
        
        if (answer.ToString() == userAnswer)
        {
            score++;
            Console.WriteLine($"Correct! score: {score}\nPress any key to continue...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Incorrect. Press any key to continue...");
            Console.ReadLine();
        }
        
        operands = GetNumbers();
        Console.WriteLine("\n");
        Console.Clear();
    }
    
    // add game score to list
    games.Add($"{DateTime.Now} - Multiplication: Score={score}");
}

void DivisionGame(string message)
{
    Console.Clear();
    Console.WriteLine(message);
    
    var divisionNumbers = GetDivisionNumbers();
    int answer = divisionNumbers[0] / divisionNumbers[1];
    
    var userAnswer = Console.ReadLine();
    
    for (var i = 0; i < 5; i++)
    {
        
        Console.WriteLine($"{divisionNumbers[0]} / {divisionNumbers[1]} = ");
        userAnswer = Console.ReadLine();
        
        // if (int.Parse(result) == firstNumber / secondNumber)
        if (answer.ToString() == userAnswer)
        {
            score++;
            Console.WriteLine($"Correct! score: {score}\nPress any key to continue...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Incorrect. Press any key to continue...");
            Console.ReadLine();
        }
        
        //get new values
        divisionNumbers = GetDivisionNumbers();
        answer = divisionNumbers[0] / divisionNumbers[1];

        
    }
    
    games.Add($"{DateTime.Now} - Division: Score={score}");
}

void SubtractionGame(string message)
{
    Console.Clear();
    Console.WriteLine(message);
    
    int[] operands = GetNumbers();
    var answer = 0;
    
    string userAnswer = "";
    
    for (int i = 0; i < 5; i++)
    {
        answer = operands[0] - operands[1];
    
        Console.WriteLine($"{operands[0]} - {operands[1]} = ");
        userAnswer = Console.ReadLine();
        
        if (answer.ToString() == userAnswer)
        {
            score++;
            Console.WriteLine($"Correct! score: {score}\nPress any key to continue...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Incorrect. Press any key to continue...");
            Console.ReadLine();
        }
        
        operands = GetNumbers();
        Console.WriteLine("\n");
    }
    games.Add($"{DateTime.Now} - Subtraction: Score={score}");
}

void AdditionGame(string message)
{
    Console.Clear();
    Console.WriteLine(message);
    
    int[] operands = GetNumbers();
    var answer = 0;
    
    string userAnswer = "";
    
    for (int i = 0; i < 5; i++)
    {
        
        answer = operands[0] + operands[1];
    
        Console.WriteLine($"{operands[0]} + {operands[1]} = ");
        userAnswer = Console.ReadLine();
        
        if (answer.ToString() == userAnswer)
        {
            score++;
            Console.WriteLine($"Correct! score: {score}\nPress any key to continue...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Incorrect. Press any key to continue...");
            Console.ReadLine();
        }
        
        operands = GetNumbers();
        Console.Clear();
    }
    games.Add($"{DateTime.Now} - Addition: Score={score}");
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
int[] GetNumbers()
{
    var random = new Random();
    var firstNumber = random.Next(1, 13);
    var secondNumber = random.Next(1, 13);
    
    int[] numbers = new int[2];
    numbers[0] = firstNumber;
    numbers[1] = secondNumber;

    return numbers;

}

   
// game: two random numbers are presented with an operation
// player must provide answer, game gives feedback
// game loops a set number of times until deciding player win/loose - best 3/5
// for division, only provide random numbers that result in integers
// idea - keep generating numbers between 0-99 until result is an integer

// c#academy version - no win/loose. just game over and print score.