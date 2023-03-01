using System.Reflection.Metadata.Ecma335;

internal class Program
{
    static int maxIndex;
    static float timer;

    private static void Main(string[] args)
    {
        GameLife();
        //while (AskRestartGame())
        //    GameLife();
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

    static void GameLife()
    {
        Console.WriteLine("Введите размер сетки");
        int massSize = ReadLineInt();

        int[,] mas = new int[massSize, massSize];
        maxIndex = massSize - 1;

        //Рандомизация значений
        for (int i = 0; i <= maxIndex; i++)
        {
            for (int j = 0; j <= maxIndex; j++)
            {
                mas[i, j] = new Random().Next(0,2);
            }
            
        }

        
        while ("S" != Console.ReadLine())
        {
            Console.WriteLine("\nВведите S");
            GameLifeCycle(ref mas);
        }
            
    }

    static void GameLifeCycle(ref int[,] mas)
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
        Console.Write('\n');
        int[,] masTemp = new int[maxIndex + 1, maxIndex + 1];

        for (int _x = 0; _x <= maxIndex; _x++)
        {
            Console.Write('\n');
            for (int _y = 0; _y <= maxIndex; _y++)
            {
                int livingHeighbor = CalcHeighbors(mas, _x, _y);

                //Check неживая
                if (mas[_x, _y] == 0 && livingHeighbor >= 3)
                {
                    masTemp[_x, _y] = 1;
                }
                //Check живая
                else if (mas[_x, _y] > 0)
                {
                    if (livingHeighbor == 2 || livingHeighbor == 2)
                        masTemp[_x, _y] = 1;
                    else masTemp[_x, _y] = 0;
                }

                //Console.Write(livingHeighbor);
            }

        }

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

    static void RenderLife(int[,] mas)
    {

    }

    static bool AskRestartGame()
    {
        Console.WriteLine("\nПерезапустить игру?\nY/N");
        if (Console.ReadLine() == "Y")
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