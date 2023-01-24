Console.WriteLine("This is the Tarasse's (David's) first solution to the ping problem");


string amountStr;

while (true)
{
    Console.WriteLine("Write down the amount of values you want to use: ");
    string AmountStr = Console.ReadLine();

    if(int.TryParse(AmountStr, out _))
    {
        amountStr = AmountStr;
        break;
    }
    Console.WriteLine("Invalid value");
}

int amount = int.Parse(amountStr);
int[] IArray = new int[amount];

Console.WriteLine("Do you want to set the values manually or you want the computer to choose random values? (r if random/m if manually)");
while (true)
{
    string ValuesSelection = Console.ReadLine();
    if(ValuesSelection == "r")
    {
        Console.WriteLine("What do you want to be the maximum value? ");
        int Max = 50;
        while (true)
        {
            string max = Console.ReadLine();
            if(int.TryParse(max, out _))
            {
                Max = int.Parse(max);
                break;
            }
            Console.WriteLine("Invalid value");
        }

        SelectRandom(Max, IArray, out IArray);
        break;
    }
    else if(ValuesSelection == "m")
    {
        Console.WriteLine("Write the values (after inputing each value click enter please)");
        for (int i = 0; i < IArray.Length; i++)
        {
            while (true)
            {
                Console.WriteLine("Write down the value: ");
                string valueStr = Console.ReadLine();
                if (int.TryParse(valueStr, out _))
                {
                    int value = int.Parse(valueStr);
                    IArray[i] = value;
                    break;
                }
                Console.WriteLine("Invalid value");
            }
        }
        break;
    }
}







while (true)
{
    


    Console.WriteLine("Choose the solving tactic (bubble/pivot)");
    string solvingTactic = Console.ReadLine();

    if(solvingTactic == "pivot")
    {
        PING_problem_pivot(IArray);
        break;
    }
    else if(solvingTactic == "bubble")
    {
        PING_problem_bubble(IArray);
        break;
    }
    Console.WriteLine("Invalid name");
}







static void PING_problem_bubble(int[] IntegerArray)
{
    Console.WriteLine("Started!");
    int[] order;
    order = IntegerArray;

    int numberOfSteps = 0;
    int numbersAccepted = 0;
    int i = -1;
    int y = 0;

    while (true)
    {
        numberOfSteps++;
        numbersAccepted++;

        i++;
        y++;

        if (order[i] > order[y])
        {
            int orderTemp = order[i];
            order[i] = order[y];
            order[y] = orderTemp;

            numbersAccepted = 0;

            foreach (int x in order)
            {
                Console.WriteLine("Right now: " + x);
            }
        }

        Console.WriteLine("Iteneration completed");
        Console.WriteLine();

        bool done = false;
        if(numbersAccepted >= order.Length)
        {
            done = true;
        }

        if (done)
        {
            numberOfSteps -= numbersAccepted;

            Console.WriteLine("Process completed succesefully with " + numberOfSteps + " steps"); ;
            foreach (int x in order)
            {
                Console.WriteLine("Right now: " + x);
            }
            break;
        }


        if(i >= order.Length - 2 && y >= order.Length - 1)
        {
            i = -1;
            y = 0;
        }
    }

    
}

static void PING_problem_pivot(int[] IntArray)
{
    int pivotP;

    for (int i = 0; i < IntArray.Length; i++)
    {
        pivotP = IntArray[i];
        while(i > 0 && IntArray[i - 1] > pivotP)
        {
            IntArray[i] = IntArray[i - 1];
            i--;
        }
        IntArray[i] = pivotP;
        Console.WriteLine("Process completed");
        Console.WriteLine();
        foreach (int x in IntArray)
        {
            Console.WriteLine(x);
        }
    }

    
}


static void DisplayArray(int[] order, bool Pivot, int pivot)
{
    if (Pivot)
    {
        Console.WriteLine("Current pivot: " + pivot);
    }

    foreach (int x in order)
    {
        Console.WriteLine("Right now: " + x);
    }
}

static bool CheckIfFinished(int[] InArray, out bool Finished)
{
    bool need = false;
    for (int i = 0; i < InArray.Length - 1; i++)
    {
        if (InArray[i] < InArray[i + 1] || InArray[i] == InArray[i + 1])
        {
            need = true;
        }
        else
        {
            need = false;
            break;
        }
    }
    Finished = need;
    return Finished;
}

static int[] SelectRandom(int maxValue, int[] IntegerArray, out int[] IntArray)
{
    IntArray = IntegerArray;
    for (int i = 0; i < IntegerArray.Length; i++)
    {
        Random rValue = new Random();
        int randomValue = rValue.Next(maxValue);

        IntArray[i] = randomValue;
    }

    foreach (int x in IntArray)
    {
        Console.WriteLine("All values: " + x);
    }

    return IntArray;
}