bool playOrNo;
do
{
    PersonalCards personalCards = new PersonalCards();
    personalCards.TestAllCard();
    personalCards.SortCard();
    personalCards.CallCombination();
    Console.WriteLine("Хотите продолжить?\nВыберите цифру:\n1)Да\n2)Нет");
    playOrNo = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
}
while (playOrNo);
interface IPersonalCards
{
    void TestAllCard() { }
    void SortCard() { }
}
class PersonalCards : IPersonalCards
{
    string userCards;
    List<string> sortCards = new List<string>();
    List<string> userCardsSort = new List<string>();
    List<string> allCards = new List<string>() { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" }; //все возможные карты 
    List<int> cardsForStraight = new List<int>();
    public void TestAllCard()
    {
        int countNoCorrectlyCards = 0; // все карт
        do
        {
            Console.Write("Введите ваши карты (через пробел): ");
            userCards = Convert.ToString(Console.ReadLine());
            sortCards = userCards.Split(" ").ToList();
            foreach (var i in sortCards)
            {
                foreach (var item in allCards)
                {
                    if (i != item) countNoCorrectlyCards++;
                }
                if (countNoCorrectlyCards == 13)
                {
                    Console.WriteLine("Номинал " + i + " не соответствует!\nВведите карты ещё раз! ");
                    break;
                }
                countNoCorrectlyCards = 0;
            }
        } while (countNoCorrectlyCards > 0);
    }
    public void SortCard()
    {
        {
            foreach (string item in sortCards)
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
                userCardsSort.Add(Convert.ToString(cardsForStraight[i]));
                if (sortCards[i] == "1") sortCards[i] = "A";
                if (sortCards[i] == "13") sortCards[i] = "K";
                if (sortCards[i] == "12") sortCards[i] = "Q";
                if (sortCards[i] == "11") sortCards[i] = "J";
            }
        }
    }
    public void CallCombination()
    {
        Combination combination = new Combination(userCardsSort);
        combination.StraightCombination(cardsForStraight);
        combination.PairCombination();
        combination.SetCombination();
        combination.KareCombination();
        combination.FullHouseCombination();
        combination.TwoPairCombination();
        combination.FleshRoyalCombination();
        combination.HightHandComination();
    }
}
interface ICombination
{
    void StraightCombination(List<int> cardsForStraight);
    void PairCombination();
    void SetCombination();
    void KareCombination();
    void FullHouseCombination();
    void TwoPairCombination();
    void FleshRoyalCombination();
    void HightHandComination();
}

class Combination : ICombination
{
    List<string> userCardsSort = new List<string>();
    List<string> flesh = new List<string> { "A", "10", "J", "Q", "K" };
    bool testHightHand = false;
    public Combination(List<string> userCardsSort)
    {
        this.userCardsSort = userCardsSort;
    }
    public void StraightCombination(List<int> cardsForStraight) //стрит
    {
        int testStraight = 0;
        const int countOperation = 4;
        for (var i = 0; i < countOperation; i++)
        {
            if (cardsForStraight[i + 1] - cardsForStraight[i] == 1) testStraight++;
        }
        if (testStraight == countOperation)
        {
            Console.WriteLine("У вас стрит!");
        }
    }
    public void PairCombination()//одна пара 
    {
        var countPair = 0;
        for (var i = 0; i < userCardsSort.Count; i++)
        {
            var countCardPair = 1;
            for (var j = i + 1; j < userCardsSort.Count; j++)
            {
                if (userCardsSort[i] == userCardsSort[j])
                    ++countCardPair;
            }
            if (countCardPair ==2 )
               ++countPair ;
        }
        if (countPair == 1)
        {
            Console.WriteLine("У вас пара!");
            testHightHand = true;
        }
    } 
    public void SetCombination()//сет
    {
        var countCard = 1;
        for (int i = 0; i < userCardsSort.Count; i++)
        {
            countCard = 1;
            for (int j = 1 + i; j < userCardsSort.Count; j++)
            {
                if (userCardsSort[i] == userCardsSort[j])
                    ++countCard;
            }
            if (countCard == 2)
                break;
        }
        if (countCard == 3)
        {
            testHightHand =true;
            Console.WriteLine("У вас сет!");
        }
    } 
    public void KareCombination() //Каре
    {
        for (var i = 0; i < userCardsSort.Count; i++)
        {
            var countKare = 1;
            for (var j = 1 + i; j < userCardsSort.Count; j++)
            {
                if (userCardsSort[i] == userCardsSort[j])
                    ++countKare;
            }
            if (countKare == 4)
            {
                Console.WriteLine("У вас Каре!");
                testHightHand = true;
            }
        }
    }
    public void FullHouseCombination() //фул хаус
    {
        var countCardTwo = 0;
        var index = 0;
        for (int i = 0; i < userCardsSort.Count;)
        {
            var countCardOne = 1;
            for (int j = 1 + i; j < userCardsSort.Count; j++)
            {
                if (userCardsSort[i] == userCardsSort[j])
                {
                    ++countCardOne;
                    index = j;
                }
            }
            i++;
            if (countCardOne == 2 || countCardOne == 3)
            {
                if (countCardTwo != 0 && countCardTwo != countCardOne)
                {
                    Console.WriteLine("У вас фулл-хаус!");
                    testHightHand = true;
                }
                i = index + 1;
                countCardTwo = countCardOne;
            }
        }
    }
    public void TwoPairCombination()// две пары
    {
        var secondPair = 0;
        for (var i = 0; i < userCardsSort.Count; i++)
        {
            var firstPair = 1;
            for (var j = i + 1; j < userCardsSort.Count; j++)
            {
                if (userCardsSort[i] == userCardsSort[j])
                    ++firstPair;
            }
            if (firstPair == 3)
                break;
            if(firstPair == 2)
            {
                if (secondPair != 0 && firstPair == 2)
                {
                    Console.WriteLine("У вас две пары!");
                    testHightHand = true;
                    break;
                }
                secondPair = firstPair;
            }
        }
    } 
    public void FleshRoyalCombination() //флеш рояль
    {
        var countFleshRoyal = 0;
        for (var i = 0; i < userCardsSort.Count; i++)
        {
            if (userCardsSort[i] == flesh[i])
                ++countFleshRoyal;
        }
        if (countFleshRoyal == userCardsSort.Count)
        {
            Console.WriteLine("У вас Флеш Рояль!");
            testHightHand = true;
        }
    }
    public void HightHandComination() //старшая карта
    {
        if (testHightHand == false)
            Console.WriteLine("Старшая карта! ");
    } 
}
