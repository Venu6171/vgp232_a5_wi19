﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Data
{
    public class Item
    {
        public string Name { get; set; }
        public int UnlockRequirement { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }

        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("UnlockRequirement: " + UnlockRequirement);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Effect: " + Effect);
            Console.WriteLine("\n");

        }
    }
}
