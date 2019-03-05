using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5.Data
{
    public class Pokemon
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int MaxCP { get; set; }

        public void Write(ref StreamWriter streamWriter)
        {
            streamWriter.WriteLine(Name);
            streamWriter.WriteLine(Type1);
            if (!Type2.Equals(""))
            {
                streamWriter.WriteLine(Type2);
            }
            streamWriter.WriteLine(HP);
            streamWriter.WriteLine(Attack);
            streamWriter.WriteLine(Defense);
            streamWriter.WriteLine(MaxCP);
            streamWriter.WriteLine();
        }

        public void Print()
        {
            Console.WriteLine(string.Format("Name: {0}", Name));
            Console.WriteLine(string.Format("Type1: {0}", Type1));
            if (!Type2.Equals(""))
            {
                Console.WriteLine(string.Format("Type2: {0}", Type2));
            }
            Console.WriteLine(string.Format("HP: {0}", HP));
            Console.WriteLine(string.Format("Attack: {0}", Attack));
            Console.WriteLine(string.Format("Defense: {0}", Defense));
            Console.WriteLine(string.Format("MaxCP: {0}", MaxCP) + "\n");
        }
    }
}
