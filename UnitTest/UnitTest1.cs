using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5.Data;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoadXmlTest()
        {
            XElement pokemon151XML = XElement.Load(@"pokemon151.xml");

            Assert.IsNotNull(pokemon151XML);
        }

        [TestMethod]
        public void ItemTest()
        {
            Item item = new Item();
            item.Name = "abc";
            item.UnlockRequirement = 1;
            item.Description = "aaa";
            item.Effect = "";

            Assert.AreEqual(item.Name, "abc");
        }

        [TestMethod]
        public void ItemsDataTestUnlock()
        {
            ItemsData itemsData = new ItemsData();
            List<Item> itemlist = new List<Item>();

            itemlist = itemsData.UnlockedItemsAtLevel(10);

            Assert.AreEqual(itemlist.Capacity, 8);

            Item item = new Item();
            item = itemsData.FindItem("Potion");

            Assert.AreEqual(item.Name, "Potion");

        }

        [TestMethod]
        public void ItemsDataTestFind()
        {
            ItemsData itemsData = new ItemsData();
            List<Item> itemlist = new List<Item>();
            itemlist = itemsData.UnlockedItemsAtLevel(10);
            Item item = new Item();

            item = itemsData.FindItem("Potion");

            Assert.AreEqual(item.Name, "Potion");
        }
    }
}
