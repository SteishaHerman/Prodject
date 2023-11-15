using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interface;

namespace ConsoleApp1
{
    internal class HighHand : ICombination
    {
        public string Name { get; set; } = "старшая карта!";   
        List<string> userCardsSort = new List<string>();
        public HighHand(List<string> userCardsSort)
        {
            this.userCardsSort = userCardsSort;
        }
        public bool IsRight()
        {
            Console.WriteLine("У вас "+Name);
            return true;
        }

    }

}
