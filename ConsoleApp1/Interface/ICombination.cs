using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interface
{
    internal interface ICombination
    {
        string Name { get; set; }
       public bool IsRight();
    }
}
