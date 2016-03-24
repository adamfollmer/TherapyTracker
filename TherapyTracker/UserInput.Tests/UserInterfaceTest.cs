using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput.Tests
{
    [TestClass]
    public class UserInterfaceTest
    {
        public void ShouldOnlyTakeNumbers()
        {
            //Arrange
            MainMenu test = new MainMenu();
            //Act
            test.MakeMenuSelection();
            //Assert
        }
    }
}
