using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        Game();
        while (AskRestartGame())
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
        const int goldFinded = 900;
        int alivePiligrimms;
        Console.WriteLine("Добро пожаловать в Утраченный клад!\n");
        Console.WriteLine("Пожалуйста, введите следующие данные для настройки приключения");

        Console.WriteLine("Введите целое число:");
        int num1 = ReadLineInt();
        alivePiligrimms = num1;

        Console.WriteLine("Введите число меньше предыдущего:");
        #region Check num1 > num2
        int num2 = ReadLineInt();
        while (num1 <= num2)
        {
            Console.WriteLine("Значение должно быть меньше предыдущего!");
            Console.WriteLine("Введите число меньше предыдущего:");
            num2 = ReadLineInt();
        }
        #endregion

        Console.WriteLine("Введите свое имя:");
        string playerName = Console.ReadLine();

        #region Check Quantity not sub zero

        if (alivePiligrimms <= 1)
        {
            Console.WriteLine("Что-то не так!");
            switch (alivePiligrimms)
            {
                case 1:
                    Console.WriteLine($"Никто не пришел на фан встречу и {playerName} никуда не отправился");
                    return;
                case 0:
                    Console.WriteLine($"Никто, включая {playerName}, ни в какое путешествие не отправился");
                    return;
                case -1:
                    Console.WriteLine($"Из-за брата {playerName}, который всех споил, в ещё не начавшейся экспедиции погибло больше людей, чем готовилось к отправке\n Печально :( ");
                    return;
                default:
                    Console.WriteLine($"Группа из мертвых душ, среди которых не было и {playerName},  отправилась в поход за сокровищами Древних Дворфов. \n" +
                        $" Как можно было догадаться, никто не вернулся ");
                    return;

            }
        }
        #endregion

        Console.WriteLine($"Группа из {num1} храбрых приключенцев отправилась в поход за сокровищами Древних Дворфов. " +
            $"Их возглавлял легендарный рейнджер, {playerName}.\n");

        Console.WriteLine($"По пути на путешественников напала толпа злобных огров!" +
            $" Нашим героям удалось отбиться, но ценой жизни {num2} товарищей." +
            $" Всего в живых осталось {alivePiligrimms -= num2} приключенцев.");


        if (goldFinded % (num1 - num2) > 0)
        {
            Console.WriteLine($"Они уже почти отчаялись найти сокровища, как вдруг им улыбнулась Фортуна." +
            $" Они нашли сундук, в котором было {goldFinded} монет." +
            $" {playerName} разделил золото поровну между всеми, а оставшиеся {goldFinded % (num1 - num2)} монеты оставил себе.");
        }
        else if (goldFinded % (num1 - num2) == 0)
        {
            Console.WriteLine($"Они уже почти отчаялись найти сокровища, как вдруг им улыбнулась Фортуна." +
            $" Они нашли сундук, в котором было {goldFinded} монет." +
            $" {playerName} разделил золото поровну между всеми.");
        }
        else if (goldFinded % (num1 - num2) >= goldFinded)
        {
            Console.WriteLine($"Они уже почти отчаялись найти сокровища, как вдруг им улыбнулась Фортуна." +
            $" Они нашли сундук, в котором было {goldFinded} монет." +
            $" {playerName} разделил золото поровну между всеми, а оставшиеся {goldFinded % (num1 - num2)} монет оставил себе.\n Жадный пидорюга!");
        }


        Console.WriteLine($"Однако золото было проклято!");

        while (alivePiligrimms >= 1) 
        {
            if (alivePiligrimms > 2)
            {
                Console.WriteLine($"1 приключенец  умер от проклятия и осталось {--alivePiligrimms}.");
            }
            else if (alivePiligrimms == 2)
            {
                Console.WriteLine($"1 приключенец умер от проклятия и остался только {playerName}.");
                break;
            }
            else if (alivePiligrimms == 1)
            {
                Console.WriteLine($"Но с {playerName} ничего не случилось, и он отправился домой.");
                break;
            }
            else 
            {
                Console.WriteLine($"Что-то пошло не так, но мы уверены, что {playerName} остался жив.");
            }
        }

        Console.WriteLine("Конец!");
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