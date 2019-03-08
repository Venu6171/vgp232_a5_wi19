using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    public class ItemsData
    {
        [XmlArray]
        public List<Item> Items { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemsData()
        {
            Items = new List<Item>();
        }

        /// <summary>
        /// Gets all the items that are equal or less than level requirement
        /// </summary>
        /// <param name="level">The minimum required level</param>
        /// <returns>List of items that meet the requirement</returns>
        public List<Item> UnlockedItemsAtLevel(int level)
        {
            // TODO: implement function to get all items and add unit to confirm it works.
            int Additem = 0;
            Item itemdata = new Item();
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
                    if(itemdata.UnlockRequirement <= level)
                    {
                        Additem = 1;
                    }

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
                    
                }

                if (Additem == 1)
                {
                    Items.Add(itemdata);
                    itemdata = new Item();
                    Additem = 0;
                }
            }

            return Items;
            
        }

        /// <summary>
        /// Gets the item with the matching name
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <returns>The item with the name specified or null if not found</returns>
        public Item FindItem(string name)
        {



            // TODO: implement function to find the item with the name specified.
            return Items.Find(x => x.Name == name);
           
            
        }
    }
}
