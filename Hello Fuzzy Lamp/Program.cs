using Hello_Fuzzy_Lamp;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Timers;


internal class Program
{
    public static Pet myPet = new Pet();
    static int petPoints = 0;

    private static void Main(string[] args)
    {
        Console.WriteLine("С питомцем можно взаимодействовать посредством ввода в консоль числа от 0 до 3");
        Console.WriteLine($"\n");
        Console.WriteLine("0 - выйти из игры");
        Console.WriteLine($"1 - узнать настроение питомца.\nУровень настроения = голод + скука.\nЕсли настроение > 15 - питомец в ярости, >10 - грустит, >5 - более-менее, если 5 или меньше, то он счастлив");
        Console.WriteLine("2 - покормить питомца: голод падает на 4 ед");
        Console.WriteLine("3 - поиграть с питомцем - скука падает на 4 ед");
        Console.WriteLine($"\n");
        Console.WriteLine("Выбор: ");

        while (ReadLineInt() != 0 || petPoints < 10)
        {
            ChoseAction();
        }
        Console.WriteLine($"Всего ходов: {MovesManager.totalMoves}");

        while (!AskRestartGame())
        {
            //GameLifeInit();
        }
    }

    static void ChoseAction()
    {
        switch (ReadLineInt()) {
            case 1:
                Console.WriteLine("Узнать настроение");
                Console.WriteLine($"Статус: {petPoints} \n{myPet.hungry} \n{myPet.boredom}");
                break;
            case 2:
                Console.WriteLine("Подкормка");
                myPet.hungry -= 4;
                break;
            case 3:
                Console.WriteLine("Поиграть");
                myPet.boredom -= 4;
                break;
            default:
                Console.WriteLine("Пропуск");
                break;
        }
        AddPionts();
        petPoints = myPet.hungry + myPet.boredom;
    }

    static void AddPionts()
    {
        myPet.hungry++;
        myPet.boredom++;
        MovesManager.totalMoves++;
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