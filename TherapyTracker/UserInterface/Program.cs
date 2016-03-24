using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu userInterface = new MainMenu();
            userInterface.PopulateBuilding();
            userInterface.MakeMenuSelection();
        }
    }
}
