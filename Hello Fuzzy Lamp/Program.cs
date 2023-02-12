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

    static void Game()
    {
        Console.WriteLine("Добро пожаловать в Утраченный клад! \n\nПожалуйста, введите следующие данные для настройки приключения");
        Console.WriteLine("Введите целое число:");
        try
        {
            int num1;
            num1 = checked(Convert.ToInt32(Console.ReadLine()));
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Введите ЦЕЛОЕ число, БЕЗ букв и БЕЗ значений после запято");
        }
        
    }
}