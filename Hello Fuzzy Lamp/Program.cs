using System.Reflection.Metadata.Ecma335;
using System.Timers;

internal class Program
{
    static int maxIndex;
    static int timerCouldown;
    static int[,] mas;
    static int livedPoints;

    private static System.Timers.Timer aTimer;

    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        GameLifeInit();

        while (!AskRestartGame())
        {
            GameLifeInit();
        }
    }

    enum STATUS
    {
        LIVING,
        STABLE,
        DYING
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

    static void GameLifeInit()
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

        string input = string.Empty;
        do
        {
            Console.WriteLine("\nВведите S");
            input = Console.ReadLine();
        }
        while ("S" != input);

        GameLifeProcess();

        Console.ReadLine();
    }

    static void GameLifeProcess()
    {
        while (true)
        {
            var status = GameLifeCycle();
            if (status == STATUS.DYING)
            {
                Console.WriteLine("\nВсе клетки пусты. Игра окончена");
                break;
            }
            else if (status == STATUS.STABLE) 
            {
                Console.WriteLine("\nКолония не развивается. Игра окончена");
                break;
            }
            Thread.Sleep(timerCouldown);
        }
    }

    static STATUS GameLifeCycle()
    {
        DrawGrid();
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
        if (livedPoints == 0) return STATUS.DYING;
        if (ArraysEqual(masTemp)) return STATUS.STABLE;

        mas = masTemp;

        return STATUS.LIVING;

    }

    static bool ArraysEqual(int[,] masTemp)
    {
        for (int i = 0; i <= maxIndex; i++)
        {
            for (int j = 0; j <= maxIndex; j++)
            {
                if(mas[i, j] != masTemp[i, j])
                    return false;
            }
        }
        return true;
    }

    static void DrawGrid()
    {
        Console.Clear();
        //Рисование картины
        for (int i = 0; i <= maxIndex; i++)
        {
            Console.Write($"\n");
            for (int j = 0; j <= maxIndex; j++)
            {
                Console.Write(mas[i, j] > 0 ? "\u25CF" : "\u25CB");
            }
        }
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