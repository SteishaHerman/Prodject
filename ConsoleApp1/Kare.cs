using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interface;
namespace ConsoleApp1
{
    internal class Kare : ICombination
    {
        public string Name { get; set; } = "Каре";
        List<string> userCardsSort = new List<string>();
        public Kare(List<string> userCardsSort)
        {
            this.userCardsSort = userCardsSort;
        }
        public bool IsRight()
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
                    Console.WriteLine("У вас "+ Name);
                    return true;
                }
            }
            return false;
        }
    }
}
