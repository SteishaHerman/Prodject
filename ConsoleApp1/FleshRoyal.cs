using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interface;
using ConsoleApp1;

namespace ConsoleApp1
{
    internal class FleshRoyal : ICombination
    {
        public string Name { get; set; }
        List<string> userCardsSort = new List<string>();
        List<string> flesh = new List<string> { "A", "10", "J", "Q", "K" };
        public FleshRoyal(List<string> userCardsSort)
        {
            this.userCardsSort = userCardsSort;
        }
        public bool IsRight()
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
                return true;
            }
            return false;
        }
    }   
}
