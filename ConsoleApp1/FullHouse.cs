using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interface;

namespace ConsoleApp1
{
    internal class FullHouse : ICombination
    {
        public string Name { get; set; }
        List<string> userCardsSort = new List<string>();
        public FullHouse(List<string> userCardsSort)
        {
            this.userCardsSort = userCardsSort;
        }
        public bool IsRight()
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
                        return true;
                    }
                    i = index + 1;
                    countCardTwo = countCardOne;
                }
            }
            return false;
        }
    }
}
