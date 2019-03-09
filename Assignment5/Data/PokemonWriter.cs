using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
   public class PokemonWriter
    {
        XmlSerializer serializer;

        public PokemonWriter()
        {
            serializer = new XmlSerializer(typeof(Pokedex));
        }

        public void SavePokemons(string filepath, ref Pokedex pokedex)
        {
            using (TextWriter file = new StreamWriter(filepath))
            {
                try
                {
                    serializer.Serialize(file, pokedex);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to serialize the {0} due to following: {1}",
                        filepath, ex.Message));
                }
            }
        }
    }
}
