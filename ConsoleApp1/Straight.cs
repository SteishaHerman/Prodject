using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interface;

namespace ConsoleApp1
{
    internal class Straight : ICombination  
    {
        public string Name { get; set; } = "стрит";
        List<string> userCardsSort = new List<string>();
        List<int> cardsForStraight = new List<int>();
        public Straight(List<string> userCardsSort)
        {
            this.userCardsSort = userCardsSort;
        }
        public bool IsRight()
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
            int testStraight = 0;
            const int countOperation = 4;
            for (var i = 0; i < countOperation; i++)
            {
                if (cardsForStraight[i + 1] - cardsForStraight[i] == 1) testStraight++;
            }
            if (testStraight == countOperation)
            {
                Console.WriteLine("У вас " + Name);
                return true;
            }
            return false;
        }
    }
}
