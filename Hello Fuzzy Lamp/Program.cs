using System.Reflection.Metadata.Ecma335;
using System.Timers;

internal class Program
{

    private static System.Timers.Timer aTimer;

    private static void Main(string[] args)
    {
        //GameLifeInit();

        while (!AskRestartGame())
        {
            //GameLifeInit();
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