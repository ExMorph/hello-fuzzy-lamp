using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Введите свое имя: ");
        var name = Console.ReadLine();
        Console.WriteLine($"Привет {name}");
        LiteralsCheck();
        CheckOperand();
        LostData();
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

        byte c = checked((byte)(a + b));
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
}