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

        public List<Pokemon> PokemonsToProcess
        {
            get
            {
                return pokemonsToProcess;
            }
            set
            {
                pokemonsToProcess = value;
            }
        }

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

        public void Print()
        {
            foreach (Pokemon pokemon in pokemonsToProcess)
            {
                pokemon.Print();
            }
        }
    }
}
