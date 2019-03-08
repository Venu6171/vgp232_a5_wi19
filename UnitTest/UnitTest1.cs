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
            Item itemdata = new Item();
            List<Item> itemlist = new List<Item>();
            XmlTextReader readerItem = new XmlTextReader("itemData.xml");

            while (readerItem.Read())
            {
                if (readerItem.NodeType == XmlNodeType.Element && readerItem.Name == "Name")
                {
                    string name = readerItem.ReadElementContentAsString();
                    itemdata.Name = name;
                }

                if (readerItem.NodeType == XmlNodeType.Element && readerItem.Name == "UnlockRequirement")
                {
                    string UnlockRequirement = readerItem.ReadElementContentAsString();
                    itemdata.UnlockRequirement = Int32.Parse(UnlockRequirement);
                }

                if (readerItem.NodeType == XmlNodeType.Element && readerItem.Name == "Description")
                {
                    string Description = readerItem.ReadElementContentAsString();
                    itemdata.Description = Description;
                }

                if (readerItem.NodeType == XmlNodeType.Element && readerItem.Name == "Effect")
                {
                    string Effect = readerItem.ReadElementContentAsString();
                    itemdata.Effect = Effect;
                    itemlist.Add(itemdata);
                    itemdata = new Item();
                }
                
            }

            Assert.AreEqual(itemlist.Capacity, 16);
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

        [TestMethod]
        public void InventoryTest()
        {
            Inventory source = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 } }
            };

            Assert.AreEqual(source.Items.Capacity, 4);

        }

    }
}
