using System.Reflection.Metadata.Ecma335;
using System.Timers;

internal class Program
{
    static int maxIndex;
    static float timerCouldown;
    static int[,] mas;
    static int livedPoints;

    private static System.Timers.Timer aTimer;

    private static void Main(string[] args)
    {
        GameLifeStart();
    }

    public static int ReadLineInt()
    {
        int checkedNum = 0;
        for (bool thisIsInt = false; thisIsInt == false; )
        {
            thisIsInt = int.TryParse(Console.ReadLine(), out checkedNum);
            switch (thisIsInt)
            {
                case true:
                    break;
                case false:
                    Console.WriteLine("Цифру пожалуйста, БЕЗ букв и БЕЗ значений после запятой");
                    break;   
            }
        }
        return checkedNum;
    }

    static void GameLifeStart()
    {
        Console.WriteLine("Введите размер сетки");
        int massSize = ReadLineInt();

        mas = new int[massSize, massSize];
        maxIndex = massSize - 1;

        //Рандомизация значений
        for (int i = 0; i <= maxIndex; i++)
        {
            for (int j = 0; j <= maxIndex; j++)
            {
                mas[i, j] = new Random().Next(0,2);
            }
            
        }

        Console.WriteLine("Введите время для обновления данных (сек)");
        timerCouldown = ReadLineInt()*1000;

        Console.WriteLine("\nВведите S");
        while ("S" != Console.ReadLine())
        {
            Console.WriteLine("\nВведите S");
            GameLifeCycle();
        }

        SetTimer();
        
        Console.ReadLine();
        aTimer.Stop();
        aTimer.Dispose();
    }

    static void GameLifeCycle()
    {
        //Рисование картины
        for (int i = 0; i <= maxIndex; i++)
        {
            Console.Write($"\n");
            for (int j = 0; j <= maxIndex; j++)
            {
                Console.Write(mas[i, j]);
            }
        }

        //Подсчет соседей
        //Console.Write('\n');
        int[,] masTemp = new int[maxIndex + 1, maxIndex + 1];

        for (int _x = 0; _x <= maxIndex; _x++)
        {
            //Console.Write('\n');
            for (int _y = 0; _y <= maxIndex; _y++)
            {
                int livingHeighbor = CalcHeighbors(mas, _x, _y);

                //Check неживая
                if (mas[_x, _y] == 0 && livingHeighbor == 3)
                {
                    masTemp[_x, _y] = 1;
                }
                //Check живая
                else if (mas[_x, _y] > 0)
                {
                    if (livingHeighbor == 2 || livingHeighbor == 3)
                        masTemp[_x, _y] = 1;
                    else masTemp[_x, _y] = 0;
                }
                //Console.Write(livingHeighbor);
            }
        }

        //Подсчет живых клеток
        livedPoints = 0;
        foreach (int i in mas)
        {
            if (i == 1) livedPoints++;
        }
        if (livedPoints == 0) Console.WriteLine("Все клетки пусты. Игра окончена");

        mas = masTemp;
    }

    static int CalcHeighbors(int[,] mas, int _x, int _y)
    {
        int livingHeighbor = 0;

        //1st line
        if (_x > 0)
        {
            if (_y > 0)
                if (mas[_x - 1, _y - 1] > 0)
                    livingHeighbor++;

            if (mas[_x - 1, _y] > 0)
                livingHeighbor++;

            if (_y < maxIndex)
                if (mas[_x - 1, _y + 1] > 0)
                    livingHeighbor++;
        }

        //2nd line
        if (_y > 0)
            if (mas[_x, _y - 1] > 0)
                livingHeighbor++;

        if (_y < maxIndex)
            if (mas[_x, _y + 1] > 0)
                livingHeighbor++;

        //3rd line
        if (_x < maxIndex)
        {
            if (_y > 0)
                if (mas[_x + 1, _y - 1] > 0)
                    livingHeighbor++;

            if (mas[_x + 1, _y] > 0)
                livingHeighbor++;

            if (_y < maxIndex)
                if (mas[_x + 1, _y + 1] > 0)
                    livingHeighbor++;
        }

        return livingHeighbor;
    }

    private static void SetTimer()
    {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(timerCouldown);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                          e.SignalTime);
    }

    static bool AskRestartGame()
    {
        Console.WriteLine("\nПерезапустить игру?\nY/N");
        if (Console.ReadLine() == "Y" || Console.ReadLine() == "y")
        {
            //Game(); //useless
            return true;
        }
        else
        {
            Console.WriteLine("Пока");
            return false;
        }
    }
}