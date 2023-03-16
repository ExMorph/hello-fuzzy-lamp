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
            myPet.hungry = 0;
            myPet.boredom = 0;
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

        if (myPet.hungry >= 10 || myPet.boredom >= 10) canPlay = false;
    }

    static string CheckMood()
    {
        petMood = myPet.hungry + myPet.boredom;
        if (petMood > 15) return "Я в ярости!";
        else if (petMood > 10) return "Мне грустно :(";
        else if (petMood > 5) return "Мне неплохо :|";
        else return "Я счастлив!";
    }

    static void CorrectRange(ref int checkValue)
    {
        //Уверен что можно написать одной строчкой
        checkValue = Math.Min(10, checkValue);
        checkValue = Math.Max(0, checkValue);
    }

    static void AddPionts()
    {
        myPet.hungry++;
        myPet.boredom++;
        MovesManager.totalMoves++;

        CorrectRange(ref myPet.hungry);
        CorrectRange(ref myPet.boredom);
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