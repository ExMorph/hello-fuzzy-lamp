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
        Console.WriteLine("Строка? \n Ещё одна!");
    }

    static void CheckOperand()
    {
        int a, b = 2, c;
        //a = b = c;  ERROR - буква C пустая ЁПТА
        a = b = c = 34;
        Console.WriteLine(a + " " + b + " " + c);
    }

    static void LostData()
    {
        int a = 33;
        int b = 255;
        byte c = (byte)(a + b);
        Console.WriteLine(c);
    }
}