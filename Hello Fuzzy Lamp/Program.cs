using Hello_Fuzzy_Lamp;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Timers;


internal class Program
{
    public static Pet myPet = new Pet();
    static int petMood = 0;
    static bool canPlay = true;

    private static void Main(string[] args)
    {
        Game();

        while (AskRestartGame())
        {
            canPlay = true;
            myPet.Hungry = 0;
            myPet.Boredom = 0;
            petMood = 0;

            Game();
        }
    }

    static void Game()
    {
        Console.WriteLine("С питомцем можно взаимодействовать посредством ввода в консоль числа от 0 до 3");

        while (canPlay)
        {
            ChoseAction();
        }

        Console.WriteLine($"Питомец умер");
        Console.WriteLine($"\nВсего ходов: {MovesManager.totalMoves}");
    }

    static void ChoseAction()
    {
        #region WriteText
        Console.WriteLine($"\n");
        Console.WriteLine("0 - Выйти из игры");
        Console.WriteLine("1 - Узнать настроение питомца.");
        Console.WriteLine("2 - Покормить питомца");
        Console.WriteLine("3 - Поиграть с питомцем");
        Console.WriteLine($"\n");
        Console.WriteLine("Выбор: ");
        #endregion

        switch (ReadLineInt()) {
            case 0:
                canPlay = false;
                Console.WriteLine("Выход");
                break;
            case 1:
                Console.WriteLine("Узнать настроение");
                Console.WriteLine(CheckMood());
                //Добавить ещё значения
                break;
            case 2:
                Console.WriteLine("Кормление");
                myPet.Hungry -= 4;
                break;
            case 3:
                Console.WriteLine("Поиграть");
                myPet.Boredom -= 4;
                break;
            default:
                Console.WriteLine("Пропуск");
                break;
        }
        AddPionts();

        if (myPet.Hungry >= 10 || myPet.Boredom >= 10) canPlay = false;
    }

    static string CheckMood()
    {
        petMood = myPet.Hungry + myPet.Boredom;
        if (petMood > 15) return "Я в ярости!";
        else if (petMood > 10) return "Мне грустно :(";
        else if (petMood > 5) return "Мне неплохо :|";
        else return "Я счастлив!";
    }

    static void AddPionts()
    {
        myPet.Hungry++;
        myPet.Boredom++;
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
            return true;
        }
        else
        {
            Console.WriteLine("Пока");
            return false;
        }
    }
}