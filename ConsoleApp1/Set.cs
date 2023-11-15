using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interface;

namespace ConsoleApp1
{
    internal class Set : ICombination   
    {
        public string Name { get; set; } = "сет";   
        List<string> userCardsSort = new List<string>();
        public Set(List<string> userCardsSort)
        {
            this.userCardsSort = userCardsSort;
        }         
        public bool IsRight() 
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
                Console.WriteLine("У вас " +Name);
                return true;
            }
            return false;
        }
    }
}
