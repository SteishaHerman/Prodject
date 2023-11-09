bool playOrNo;
do
{
    string userCards;
    List<string> userCardsSort = new List<string>();
    List<string> allCards = new List<string>() { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" }; //все возможные карты 
    var countNoCorrectlyCards = 0; // все карт
    var testKarePairSet = 1; //каре, пара,сет
    var testHighHand = 0; //старшая карты 
    List<string> firstPairOrSet = new List<string> { " " }; // для записи одинаковой карты во время проверки пары, сета.
    do
    {
        Console.Write("Введите ваши карты (через пробел): ");
        userCards = Convert.ToString(Console.ReadLine());
        userCardsSort = userCards.Split(" ").ToList();
        foreach (var i in userCardsSort)
        {
            foreach (var item in allCards)
            {
                if (i != item) countNoCorrectlyCards++;
            }
            if (countNoCorrectlyCards == 13)
            {
                Console.WriteLine("Номинал " + i + " не соответствует!");
                break;
            }
            countNoCorrectlyCards = 0;
            if (countNoCorrectlyCards > 0) Console.WriteLine("Введите карты ещё раз! ");
        }
    } while (countNoCorrectlyCards > 0);

    testHighHand += StraightCombination(userCardsSort, testHighHand);
    testHighHand += PairAndKareCombination(userCardsSort, testKarePairSet, firstPairOrSet, testHighHand);
    testKarePairSet = testHighHand;
    testHighHand += FullHouse(userCardsSort, testKarePairSet, firstPairOrSet, testHighHand);
    testHighHand += FleshRoyalCombination(userCardsSort, testKarePairSet, testHighHand);

    if (testHighHand == 0) Console.WriteLine("У вас старшая карта"); //старшая карта
    Console.WriteLine("Хотите продолжить?\nВыберите цифру:\n1)Да\n2)Нет");
    playOrNo = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

} while (playOrNo);

int StraightCombination(List<string> userCardsSort, int testHighHand) //стрит
{
    const int countOperation = 4;
    int testStraight = 0;//стрит
    List<int> cardsForStraight = new List<int>();
    foreach (string item in userCardsSort)
    {
        switch (item)
        {
            case "A":
                cardsForStraight.Add(1);
                break;
            case "J":
                cardsForStraight.Add(11);
                break;
            case "Q":
                cardsForStraight.Add(12);
                break;
            case "K":
                cardsForStraight.Add(13);
                break;
            default:
                cardsForStraight.Add(Convert.ToInt32(item));
                break;
        }
    }

    cardsForStraight.Sort();
    for (var i = 0; i < countOperation; i++)
    {
        if (cardsForStraight[i + 1] - cardsForStraight[i] == 1) testStraight++;
    }
    if (testStraight == 4)
    {
        Console.WriteLine("У вас стрит");
        testHighHand += 1;
        return testHighHand;
    }
    else { return 0; }
}

int PairAndKareCombination(List<string> userCardsSort, int testKarePairSet, List<string> firstPairOrSet, int testHighHand) //пара,две пары, каре
{
    for (var i = 0; i < userCardsSort.Count; i++) //пара 
    {
        string b = userCardsSort[i];
        for (var j = 0; j < userCardsSort.Count; j++)
        {
            string d = userCardsSort[j];
            if (i == j) continue;
            if (b == d)
            {
                testKarePairSet += 1;
                firstPairOrSet[0] = userCardsSort[j];
            }
        }
        if (testKarePairSet == 2 || testKarePairSet == 3)
        {
            return testKarePairSet;
        }
        if (testKarePairSet == 4)
        {
            Console.WriteLine("У вас каре");
            return ++testHighHand;
        }
    }
    return 0;
}

int FullHouse(List<string> userCardsSort, int testKarePairSet, List<string> firstPairOrSet, int testHighHand) //фул-хаус,две пары, сет
{
    int testTwoPair = 0; //две пары
    switch (testKarePairSet)  // фул-хаус и две пары
    {
        case 2:
            for (var i = 0; i < userCardsSort.Count; i++)
            {
                if (firstPairOrSet[0] == userCardsSort[i]) continue;
                else
                {
                    for (var j = 0; j < userCardsSort.Count; j++)
                    {
                        if (i == j) continue;
                        if (userCardsSort[i] == userCardsSort[j])
                        {
                            testTwoPair += 1;
                        }
                    }
                    if (testTwoPair == 2)
                    {
                        Console.WriteLine("У вас фул-хаус");
                        return ++testHighHand;
                    }
                    if (testTwoPair == 1)
                    {
                        Console.WriteLine("У вас две пары");
                        return ++testHighHand;
                    }
                }
            }
            if (testTwoPair == 0)
            {
                Console.WriteLine("У вас пара");
                return testHighHand++;
            }
            break;
        case 3:
            for (var i = 0; i < userCardsSort.Count; i++)
            {
                if (firstPairOrSet[0] == userCardsSort[i]) continue;
                else
                {
                    for (int j = 0; j < userCardsSort.Count; j++)
                    {
                        if (userCardsSort[i] == userCardsSort[j] && i != j)
                        {
                            testTwoPair += 1;
                            break;
                        }
                    }
                }
                if (testTwoPair == 1) break;
            }
            Console.WriteLine(testTwoPair == 1 ? "У вас фул-хаус" : "У вас сет");
            return testHighHand++;
    }
    return 0;
}

int FleshRoyalCombination(List<string> userCardsSort, int testKarePairSet, int testHighHand)//флеш рояль
{
    List<string> flesh = new List<string> { "10", "J", "Q", "K", "A" };
    int countCardFlesh = 0; //флеш-роял
        foreach (var item in userCardsSort)
        {
            if (testKarePairSet > 1) break;

            foreach (var j in flesh)
            {
                if (item == j)
                {
                    countCardFlesh += 1;
                    break;
                }
            }
            if (countCardFlesh == 5)
            {
                Console.WriteLine("У вас флеш-роял");
                return ++testHighHand;
            }
        }
    return 0;
}
