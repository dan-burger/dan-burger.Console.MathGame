using System.Diagnostics;

bool userPlaying = true;
int gameNumber = 1;
List<string> results = new List<string>();
Stopwatch stopwatch = new Stopwatch();

while (userPlaying)
{
    ShowMenu();
}

void ShowMenu()
{
    Console.WriteLine("Welcome to the Math Game! You will play ten rounds of your choice.");
    Console.WriteLine("Please make a selection.");
    Console.WriteLine("1 - Addition\n2 - Subtraction\n3 - Multiplication\n4 - Division\n5 - Past Results\n6 - Quit\n");
    var userSelection = Console.ReadLine();
    int choice;
    if (!Int32.TryParse(userSelection, out choice))
    {
        Console.WriteLine("Please enter a valid selection.");
    }
    else
    {
        switch (choice)
        {
            case 1:
                StartGame('+');
                break;
            case 2:
                StartGame('-');
                break;
            case 3:
                StartGame('*');
                break;
            case 4:
                StartGame('/');
                break;
            case 5:
                ListResults();
                break;
            case 6:
                Console.WriteLine("\nThank you for playing.");
                userPlaying = false;
                break;
            default:
                Console.WriteLine("\nInvalid selection.\n");
                break;
        }
    }




}

void StartGame(char operation)
{
    stopwatch.Start();
    int amountCorrect = 0;
    int counter = 0;
    Random random = new Random();

    for (int i = 0; i < 10; i++)
    {
        Console.Clear();
        counter++;
        int one;
        int two;
        if (operation == '/')
        {
            do
            {
                one = random.Next(1, 100);
                two = random.Next(1, 20);
            } while (one % two != 0);
        }
        else
        {
            one = random.Next(1, 10);
            two = random.Next(1, 10);
        }

        int answer = 0;
        string questionString = "";
        switch (operation)
        {
            case '+':
                answer = one + two;
                questionString = @$"Question {counter}:
{one} + {two} = ";
                break;
            case '-':
                answer = one - two;
                questionString = @$"Question {counter}:
{one} - {two} = ";
                break;
            case '*':
                answer = one * two;
                questionString = @$"Question {counter}:
{one} * {two} = ";
                break;
            case '/':
                answer = one / two;
                questionString = @$"Question {counter}:
{one} / {two} = ";
                break;
        }

        var userAnswerInt = 0;
        string ?userAnswer = null;
        while (string.IsNullOrEmpty(userAnswer))
        {
            Console.Write(questionString);
            userAnswer = Console.ReadLine();
            if (!Int32.TryParse(userAnswer, out userAnswerInt))
            {
                Console.WriteLine("Please enter a valid integer.\n");
                userAnswer = null;
            }
            else
            {
                if (userAnswerInt == answer)
                {
                    amountCorrect++;
                    Console.WriteLine("\nThat is correct!");
                    if (counter == 10)
                    {
                        Console.WriteLine("Press enter to see your final score.");
                    }
                    else
                    {
                        Console.WriteLine("Press enter for the next question.");
                    }
                    
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("That is incorrect.");
                    if (counter == 10)
                    {
                        Console.WriteLine("Press enter to see your final score.");
                    }
                    else
                    {
                        Console.WriteLine("Press enter for the next question.");
                    }
                    Console.ReadLine();
                }
            }
        }
    }
    stopwatch.Stop();
    Console.WriteLine($"You answered {amountCorrect} out of 10 correct in {stopwatch.ElapsedMilliseconds/1000} seconds!\n");
    results.Add($"Game {gameNumber}: {amountCorrect} correct out of 10 in {stopwatch.ElapsedMilliseconds/1000} seconds using {operation} operator.");
    gameNumber++;
    stopwatch.Restart();
}

void ListResults()
{
    Console.WriteLine("\nPast Results:");
    foreach(var result in results)
    {
        Console.WriteLine(result);
    }
    Console.WriteLine();
}