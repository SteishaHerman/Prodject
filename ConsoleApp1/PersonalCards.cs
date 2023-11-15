using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace ConsoleApp1
{
    internal class PersonalCards : IPersonalCards
    {
        string userCards;
        List<string> sortCards = new List<string>();
        List<string> userCardsSort = new List<string>();
        List<int> cardsForStraight = new List<int>();
        Dictionary<int, string> сards = new Dictionary<int, string>()
        {
            { 1,"A" },
            { 2, "2"},
            { 3, "3"},
            { 4,"4" },
            { 5,"5" },
            { 6,"6" },
            { 7,"7" },
            { 8,"8" },
            { 9,"9" },
            {10,"10"},
            { 11,"J"},
            { 12,"Q"},
            { 13,"K"}
        };
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
                    if (сards.ContainsValue(i)==false)
                    {
                        Console.WriteLine("Номинал " + i + " не соответствует!\nВведите карты ещё раз! ");
                        countNoCorrectlyCards++;
                        break;
                    }
                    countNoCorrectlyCards = 0;
                }
            } while (countNoCorrectlyCards > 0);
        }
        public List<string> SortCard()
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
                if (userCardsSort[i] == "1") userCardsSort[i] = "A";
                if (userCardsSort[i] == "13") userCardsSort[i] = "K";
                if (userCardsSort[i] == "12") userCardsSort[i] = "Q";
                if (userCardsSort[i] == "11") userCardsSort[i] = "J";
            }
            return userCardsSort;
        }
    }
}



/*    enum Card
        {
            A = 14,
            K = 13,
            Q = 12,
            J = 11,
            ten = 10,
            nine = 9,
            eight = 8,
            seven = 7,
            six = 6,
            five = 5,
            four = 4,
            three = 3,
            two = 2
        };*/
