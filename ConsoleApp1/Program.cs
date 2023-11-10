bool playOrNo;
do
{
    bool[] answerFunction = new bool[7];
    Poker poker = new Poker();
    poker.TestAllCards();
    poker.SortUserCards();
    answerFunction[0] = poker.StraightCombination();
    answerFunction[1] = poker.PairCombination();
    answerFunction[2] = poker.SetCombination();
    answerFunction[3] = poker.KareCombination();
    answerFunction[4] = poker.FullHouseCombination();
    answerFunction[5] = poker.TwoPairCombination();
    answerFunction[6] = poker.FleshRoyalCombination();
    poker.HightHandComination(answerFunction);
    Console.WriteLine("Хотите продолжить?\nВыберите цифру:\n1)Да\n2)Нет");
    playOrNo = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

} while (playOrNo);

class Poker
{
    string userCards;
    List<string> userCardsSort = new List<string>();
    List<string> sortCards = new List<string>(); 
    List<string> allCards = new List<string>() { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" }; //все возможные карты 
    List<int> cardsForStraight = new List<int>();
    List<string> flesh = new List<string> { "A","10", "J", "Q", "K"};
    int countNoCorrectlyCards = 0; // все карт
    int testStraight = 0;//стрит
    public List<string> TestAllCards()
    {
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
        return userCardsSort;
    } //проверка карт
    public List<string> SortUserCards()
    {
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
        for (int i = 0; i < cardsForStraight.Count; i++)
        {
            sortCards.Add(Convert.ToString(cardsForStraight[i]));
            if (sortCards[i] == "1") sortCards[i] = "A";
            if (sortCards[i] == "13") sortCards[i] = "K";
            if (sortCards[i] == "12") sortCards[i] = "Q";
            if (sortCards[i] == "11") sortCards[i] = "J";
        }
        return sortCards;

    } //сортировка
    public bool StraightCombination() //стрит
    {
        const int countOperation = 4;
        for (var i = 0; i < countOperation; i++)
        {
            if (cardsForStraight[i + 1] - cardsForStraight[i] == 1) testStraight++;
        }
        if (testStraight == countOperation)
        {
            Console.WriteLine("У вас стрит");
            return true;
        }
        else { return false; }
    }
    public bool PairCombination()
    {
        var countPair = 0;
        for (var i = 0; i < sortCards.Count; i++)
        {
            var countCardPair = 1;
            for (var j = i + 1; j < sortCards.Count; j++)
            {
                if (sortCards[i] == sortCards[j])
                    ++countCardPair;
            }
            if (countCardPair == 3 || countCardPair == 4)
                return false;
            if (countCardPair == 2)
                ++countPair;
        }
        if(countPair ==1) 
        {
            Console.WriteLine("У вас пара!");
            return true;
        }
        return false;
    } //одна пара
    public bool SetCombination()
    {
        var index = 0;
        var count = 1;
        for (int i = 0; i < sortCards.Count; i++)
        {
            for (int j = 1 + i; j < sortCards.Count; j++)
            {
                if (sortCards[i] == sortCards[j])
                {
                    index = j;
                    ++count;
                }
            }
            if (count == 3 && index == 2)
            {
                if (sortCards[index + 1] != sortCards[index + 2])
                {
                    Console.WriteLine("У вас сет!");
                    return true;
                }
                else return false;
            }
            if (count == 3 && index > 2)
            {
                Console.WriteLine("У вас сет!");
                return true;
            }
            if (count == 2)
                return false;
        }
        return false;
    } //сет
    public bool KareCombination() //Каре
    {
        for (var i = 0; i < sortCards.Count; i++)
        {
            var countKare = 1;
            for (var j = 1 + i; j < sortCards.Count; j++)
            {
                if (sortCards[i] == sortCards[j])
                    ++countKare;
            }
            if (countKare == 4)
            {
                Console.WriteLine("У вас Каре");
                return true;
            }
        }
        return false;
    }
    public bool FullHouseCombination()
    {
        var countCardTwo = 0;
        var index = 0;
        for (int i = 0; i < sortCards.Count;)
        {
            var countCardOne = 1;
            for (int j = 1 + i; j < sortCards.Count; j++)
            {
                if (sortCards[i] == sortCards[j])
                { ++countCardOne; 
                    index=j;
                } 
            }
            i++;
            if (countCardOne == 2 || countCardOne == 3)
            {
                if (countCardTwo != 0 && countCardTwo != countCardOne)
                {
                    Console.WriteLine("У вас фулл-хаус ");
                    return true;
                }
                if (countCardTwo == 0)
                {
                    i = index+1;
                    countCardTwo = countCardOne;
                }
               
            }
            ;
        }
        return false;
    }// фулл-хаус
    public bool TwoPairCombination()
    {
        var secondPair = 0;
        for (var i=0;i<sortCards.Count;i++)
        {
            var firstPair = 1;
            for (var j =i   +1;j<sortCards.Count;j++)
            {
                if (sortCards[i] == sortCards[j])
                  ++firstPair;
            }
            if(firstPair == 2)
            {
                if (secondPair != 0 && firstPair == 2)
                {
                    Console.WriteLine("У вас две пары!");
                    return true;
                }
                if (secondPair == 0)
                    secondPair = firstPair;

            }
            if (firstPair == 3 || firstPair == 4)
                return false;
        }
        return false;
    } //две пары
    public bool FleshRoyalCombination()
    {
       var countFleshRoyal= 0;
       for(var i=0;i<sortCards.Count;i++)
        {
            if (sortCards[i] == flesh[i])
                ++countFleshRoyal;
        }
        if (countFleshRoyal == sortCards.Count)
        {
            Console.WriteLine("У вас Флеш Рояль");
            return true;
        }
        return false;
    }//Флеш Рояль
    public bool HightHandComination(bool[] answerFunction)
    {
        var value = false;
        var count = 0;
        for(int i=0;i< answerFunction.Length;i++)
        {
            value = answerFunction[i];
            if (value == false)
                count++;
            if (value == true)
                return false;
        }
        if (count==7)
        {
            Console.WriteLine("У вас старшая карта");
            return true;
        }

        return false;
    } //старшая карта
}

