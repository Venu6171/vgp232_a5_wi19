using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Assignment5.Data
{
    public class PokemonUtil : IDisposable
    {
        private StreamWriter streamWriter = null;
        private List<Pokemon> pokemonsToProcess = null;

        private string xmlPath = null;

        public PokemonUtil(string fileName)
        {
            if (!fileName.Contains(".txt"))
            {
                streamWriter = new StreamWriter(fileName + ".txt");
            }

            xmlPath = fileName + ".xml";
        }

        public void Init()
        {
            Clear();
            pokemonsToProcess = new List<Pokemon>();
        }

        public void Clear()
        {
            if (pokemonsToProcess != null)
            {
                pokemonsToProcess.Clear();
            }
        }

        public void Dispose()
        {
            streamWriter.Close();
        }

        public void AddPokemonsToProcess(ref PokemonBag pokemonBag, ref Pokedex pokedex)
        {
            for (int i = 0; i < pokemonBag.Pokemons.Count; ++i)
            {
                for (int j = 0; j < pokedex.Pokemons.Count; ++j)
                {
                    if (pokemonBag.Pokemons[i] == pokedex.Pokemons[j].Index)
                    {
                        pokemonsToProcess.Add(pokedex.Pokemons[j]);
                        break;
                    }
                }
            }
        }

        public void Write()
        {
            foreach (Pokemon pokemon in pokemonsToProcess)
            {
                pokemon.Write(ref streamWriter);
            }
        }

        public void WriteXml()
        {
            XmlWriter xmlWriter = XmlWriter.Create(xmlPath);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteWhitespace("\n");
            xmlWriter.WriteStartElement("Pokedex");
            xmlWriter.WriteWhitespace("\n");
            xmlWriter.WriteStartElement("Pokemons");
            xmlWriter.WriteWhitespace("\n");

            foreach (Pokemon pokemon in pokemonsToProcess)
            {
                xmlWriter.WriteStartElement("Pokemon");
                xmlWriter.WriteWhitespace("\n");
                xmlWriter.WriteStartElement(nameof(pokemon.Index));
                xmlWriter.WriteValue(pokemon.Index);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteWhitespace("\n");
                xmlWriter.WriteStartElement(nameof(pokemon.Name));
                xmlWriter.WriteString(pokemon.Name);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteWhitespace("\n");
                xmlWriter.WriteStartElement(nameof(pokemon.Type1));
                xmlWriter.WriteString(pokemon.Type1);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteWhitespace("\n");
                xmlWriter.WriteStartElement(nameof(pokemon.Type2));
                xmlWriter.WriteString(pokemon.Type2);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteWhitespace("\n");
                xmlWriter.WriteStartElement(nameof(pokemon.HP));
                xmlWriter.WriteValue(pokemon.HP);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteWhitespace("\n");
                xmlWriter.WriteStartElement(nameof(pokemon.Attack));
                xmlWriter.WriteValue(pokemon.Attack);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteWhitespace("\n");
                xmlWriter.WriteStartElement(nameof(pokemon.Defense));
                xmlWriter.WriteValue(pokemon.Defense);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteWhitespace("\n");
                xmlWriter.WriteStartElement(nameof(pokemon.MaxCP));
                xmlWriter.WriteValue(pokemon.MaxCP);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteWhitespace("\n");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteWhitespace("\n");
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteWhitespace("\n");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteWhitespace("\n");
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        public void Print()
        {
            foreach (Pokemon pokemon in pokemonsToProcess)
            {
                pokemon.Print();
            }
        }
    }
}
