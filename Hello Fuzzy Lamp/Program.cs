using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        Game();
    }

    static void HelloBoy()
    {
        Console.Write("Введите свое имя: ");
        var name = Console.ReadLine();
        Console.WriteLine($"Привет {name}");
    }
    static void LiteralsCheck()
    {
        Console.WriteLine("Любишь какать?"+'\n'+ "Люби и ж" + '\x48' + "пу подмывать!");
        Console.Write('\n');
        Console.WriteLine("Строка? \nЕщё одна!");
    }

    static void CheckOperand()
    {

        Console.WriteLine("\nПроверка операнда");
        int a, b = 2, c;
        //a = b = c;  ERROR - буква C пустая ЁПТА
        a = b = c = 34;
        Console.WriteLine(a + " " + b + " " + c);
    }

    static void LostData()
    {
        Console.WriteLine("\nПроверка потери битовых данных");

        int a = 33;
        int b = 600;
        Console.WriteLine($"Было в int {a} + {b} = {a+b}");

        a = (byte)a;
        b = (byte)b;
        Console.WriteLine($"Стало в byte {a} + {b} = {a + b}");

        byte c = (byte)(a + b);
        Console.WriteLine(c);

        try
        {
            Console.Write("Введите 1ю цифру для проверки потери битовых данных: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите 2ю цифру для проверки потери битовых данных: ");
            b = Convert.ToInt32(Console.ReadLine());
            c = checked((byte)(a + b));
            Console.WriteLine(c);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
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

    static void Game()
    {
        Console.WriteLine("Добро пожаловать в Утраченный клад!\n");
        Console.WriteLine("Пожалуйста, введите следующие данные для настройки приключения");
        Console.WriteLine("Введите целое число:");
        int num1 = ReadLineInt();
        Console.WriteLine("Ведите число, меньше предыдущего:");
        //int num2 = ReadLineInt();
        #region Check num1 > num2
        for (int num2 = 0; num1 < num2; num2 = ReadLineInt())
        {
            switch (num1 < num2)
            {
                case true:
                    Console.WriteLine($"{num1} + {num2}");
                    break;
                case false:
                    Console.WriteLine("Значение должно быть меньше предыдущего!");
                    break;
            }
        }
        #endregion
        //

        #region Restart Game
        Console.WriteLine("Перезапустить игру?\nY/N");
        if (Console.ReadLine() == "Y")
        {
            Game();
        }
        else
        {
            Console.WriteLine("Пока");
        }
        #endregion
    }
}