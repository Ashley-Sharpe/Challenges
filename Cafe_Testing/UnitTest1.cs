using Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cafe_Testing
{
    [TestClass]
    public class CafeUnitTest
    {
        [TestMethod]
        public void SetMealName_ShouldSetCorrectString()
        {
            MenuItems menu = new MenuItems();

            menu.MealName = "hamburger";
        }
    }
}
