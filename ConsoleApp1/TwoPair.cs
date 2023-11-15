using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interface;

namespace ConsoleApp1
{
    internal class TwoPair : ICombination
    {
        public string Name { get; set; } = "две пары";
        List<string> userCardsSort = new List<string>();
        public TwoPair(List<string> userCardsSort)
        {
            this.userCardsSort = userCardsSort;
        }
        public bool IsRight()
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
                if (firstPair == 2)
                {
                    if (secondPair != 0 && firstPair == 2)
                    {
                        Console.WriteLine("У вас " + Name);
                        return true;
                    }
                    secondPair = firstPair;
                }
            }
            return true;
        }
    }
}
