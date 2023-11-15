using ConsoleApp1;
using ConsoleApp1.Interface;
using System.Collections;

bool playOrNo;
do
{
    List <string> userCardsSort;
    PersonalCards personalCards = new PersonalCards();
    personalCards.TestAllCard();
    userCardsSort = personalCards.SortCard();
    List<ICombination> collectionCombination = new List<ICombination>();
    FleshRoyal fleshRoyal = new FleshRoyal(userCardsSort) ;
    FullHouse fullHouse = new FullHouse(userCardsSort) ;
    HighHand highHand = new HighHand(userCardsSort) ;
    Kare kare = new Kare(userCardsSort) ;
    Pair pair = new Pair(userCardsSort);
    Set set = new Set(userCardsSort);
    Straight straight = new Straight(userCardsSort);
    TwoPair twoPair = new TwoPair(userCardsSort);
    collectionCombination.Add(fleshRoyal);
    collectionCombination.Add(fullHouse);
    collectionCombination.Add(kare);
    collectionCombination.Add(pair);
    collectionCombination.Add(set);
    collectionCombination.Add(straight);
    collectionCombination.Add(twoPair);
    collectionCombination.Add(highHand);
    foreach ( ICombination card in collectionCombination)
    {
        if (card.IsRight()==true) break;
    }  
    Console.WriteLine("Хотите продолжить?\nВыберите цифру:\n1)Да\n2)Нет");
    playOrNo = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
} 
while (playOrNo);
