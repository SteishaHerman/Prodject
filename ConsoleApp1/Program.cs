using System;
bool q;
do
{   string card1; 
    string[] card = { };
    int[] card2 = { 0, 0, 0, 0, 0 };
    string[] arr = { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" }; //все возможные карты 
    string[] flesh = { "10", "J", "Q", "K", "A" }; // флеш рояль
    int n = 0; //флеш-роял
    int n1 = 0; // все карт
    int n2 = 1; //каре, пара,се
    int n3 = 0; //две пары
    int n4 = 0;//стрит
    int n5 = 0; //старшая карты 
    int n6 = 0;
    string[] str = { " " }; // для записи одинаковой карты во время проверки пары, сета.
    do
    {
        Console.Write("Введите ваши карты (через пробел): ");

         card1 = Convert.ToString(Console.ReadLine());
        card = card1.Split(" ");
        n6 = 0;
        for (int i = 0; i < 5; i++) //проверка номинала
        {
            n1 = 0;
            string a = card[i];
            if (a == " ") continue;
            for (int j = 0; j < 13; j++)
            {
                if (a != arr[j])
                {
                    n1++;

                }

            }
            if (n1 == 13)
            {
                Console.WriteLine("номинал " + a + " не соответствует!");
                n6++;
            }
        }
        if (n6 > 0) Console.WriteLine("Введите карты ещё раз! ");

    } while (n6 > 0);

    for (int i = 0; i < 5; i++) //пара 
    {
        string b = card[i];

        for (int j = 0; j < 5; j++)
        {
            string d = card[j];
            if (i == j) continue;
            if (b == d)
            {
                n2 = n2 + 1;
                str[0] = card[j];
            }
        }
        if (n2 == 2 || n2 == 3) break;
        if (n2 == 4)
        {
            Console.WriteLine("У вас каре");
            n5++;

        }
    }

    for (int i = 0; i < 5; i++)  // флеш-роял
    {
        if (n2 > 1) break;
        string b = card[i];
        for (int j = 0; j < 5; j++)
        {
            if (b == flesh[j])
            {
                n = n + 1;
                break;
            }
        }
        if (i == 4 && n == 5)
        {
            Console.WriteLine("У вас флеш-роял");
            n5++;
        }
    }

    switch (n2)  // фул-хаус и две пары
    {
        case 2:
            for (int i = 0; i < 5; i++)
            {

                if (str[0] == card[i]) continue;
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (i == j) continue;
                        if (card[i].ToString() == card[j])
                        {
                            n3 = n3 + 1;
                            n5++;

                        }
                    }

                    if (n3 == 2)
                    {
                        Console.WriteLine("У вас фул-хаус");
                        n5++;
                        break;
                    }
                    if (n3 == 1)
                    {
                        Console.WriteLine("У вас две пары");
                        n5++;
                        break;
                    }

                }
                if (n3 == 1 || n3 == 2) break;
            }
            if (n3 == 0)
            {
                Console.WriteLine("У вас пара");
                n5++;
            }
            break;
        case 3:
            for (int i = 0; i < 5; i++)
            {
                if (str[0] == card[i]) continue;
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (card[i] == card[j] && i != j)
                        {
                            n3 = n3 + 1;
                            break;
                        }

                    }
                }
                if (n3 == 1) break;
            }
            Console.WriteLine(n3 == 1 ? "У вас фул-хаус" : "У вас сет");
            n5++;
            break;
    }

    for (int i = 0; i < 5; i++) //стрит
    {
        switch (card[i])
        {
            case "A":
                card2[i] = 1;
                break;
            case "J":
                card2[i] = 11;
                break;
            case "Q":
                card2[i] = 12;
                break;
            case "K":
                card2[i] = 13;
                break;
            default:
                card2[i] = Convert.ToInt32(card[i]);
                break;
        }
    }

    Array.Sort(card2);

    for (int i = 0; i < 4; i++)
    {
        if (card2[i + 1] - card2[i] == 1) n4++;
    }
    if (n4 == 4)
    {
        Console.WriteLine("У вас стрит");
        n5++;
    }

    if (n5 == 0) Console.WriteLine("У вас старшая карта"); //старшая карта

    Console.WriteLine("Хотите продолжить?\nВыберите цифру:\n1)Да\n2)Нет");
    q = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;


} while (q);
