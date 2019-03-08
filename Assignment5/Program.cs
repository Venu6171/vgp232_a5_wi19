using Assignment5.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");

            // TODO: load the pokemon151 xml
            XElement pokemon151XML = XElement.Load(@"pokemon151.xml");
            // Console.WriteLine(pokemon151XML);

            // TODO: Add item reader and print out all the items
            Item itemdata = new Item();
            List<Item> itemlist = new List<Item>();
            XmlTextReader readerItem = new XmlTextReader("itemData.xml");

            while(readerItem.Read())
            {
                
                if (readerItem.NodeType == XmlNodeType.Element && readerItem.Name == "Name")
                {
                    string name = readerItem.ReadElementContentAsString();
                    itemdata.Name = name;
                   // Console.WriteLine("Name: " + itemdata.Name);
                }

                if (readerItem.NodeType == XmlNodeType.Element && readerItem.Name == "UnlockRequirement")
                {
                    string UnlockRequirement = readerItem.ReadElementContentAsString();
                    itemdata.UnlockRequirement = Int32.Parse(UnlockRequirement);
                   // Console.WriteLine("UnlockRequirement: " + itemdata.UnlockRequirement);
                }

                if (readerItem.NodeType == XmlNodeType.Element && readerItem.Name == "Description")
                {
                    string Description = readerItem.ReadElementContentAsString();
                    itemdata.Description = Description;
                   // Console.WriteLine("Description: " + itemdata.Description);
                }

                if (readerItem.NodeType == XmlNodeType.Element && readerItem.Name == "Effect")
                {
                    string Effect = readerItem.ReadElementContentAsString();
                    itemdata.Effect = Effect;
                    //Console.WriteLine("Effect: " + itemdata.Effect);

                    itemlist.Add(itemdata);
                    itemdata = new Item();
                }

                
            }

            foreach (Item i in itemlist)
            {
                i.Print();
            }

            // TODO: hook up item data to display with the inventory

            Inventory source = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 } }
            };


            // TODO: move this into a inventory with a serialize and deserialize function.

            source.Serialize(source, "inventory.xml");
            source.Deserialize("inventory.xml");





            Console.ReadKey();
        }
    }
}
