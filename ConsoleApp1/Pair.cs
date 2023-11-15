using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interface;

namespace ConsoleApp1
{
    internal class Pair : ICombination
    {
        public string Name { get; set; } = "Пара";
        List<string> userCardsSort = new List<string>();
        public Pair(List<string> userCardsSort)
        {
            this.userCardsSort = userCardsSort;
        }
        public bool IsRight()
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
                if (countCardPair == 2)
                    ++countPair;
            }
            if (countPair == 1)
            {
                Console.WriteLine("У вас "+ Name);
                return true;
            }
            return false;
        }
    }
}
