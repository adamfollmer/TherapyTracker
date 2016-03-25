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
        MainMenu test = new MainMenu();
        public void ShouldOnlyTakeNumbers()
        {
            //Arrange
            bool b;
            //Act
            try
            {
                test.MakeMenuSelection();
                b = true;
            }
            catch
            {
                b = false;
            }
            //Assert
            Assert.IsTrue(b);
        }
    }
}
