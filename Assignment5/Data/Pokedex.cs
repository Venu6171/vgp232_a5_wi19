using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    [XmlRoot("Pokedex")]
    public class Pokedex
    {
        [XmlArray("Pokemons")]
        [XmlArrayItem("Pokemon")]
        public List<Pokemon> Pokemons { get; set; }

        public Pokedex()
        {
            Pokemons = new List<Pokemon>();
        }

        public Pokemon GetPokemonByIndex(int index)
        {
            return Pokemons.ElementAt(index);
        }

        public Pokemon GetPokemonByName(string name)
        {
            return Pokemons.Find(Poke => Poke.Name == name);
        }

        public List<Pokemon> GetPokemonsOfType(string type)
        {
            return Pokemons.FindAll(Poke => (Poke.Type1 == type) || (Poke.Type2 == type));
        }

        public Pokemon GetHighestHPPokemon()
        {
            Pokemon returnPokemon = new Pokemon();
            returnPokemon.HP = int.MinValue;
            foreach (Pokemon pokemon in Pokemons)
            {
                if (pokemon.HP > returnPokemon.HP)
                {
                    returnPokemon = pokemon;
                }
            }
            return returnPokemon;
        }

        public Pokemon GetHighestAttackPokemon()
        {
            Pokemon returnPokemon = new Pokemon();
            returnPokemon.Attack = int.MinValue;
            foreach (Pokemon pokemon in Pokemons)
            {
                if (pokemon.Attack > returnPokemon.Attack)
                {
                    returnPokemon = pokemon;
                }
            }
            return returnPokemon;
        }

        public Pokemon GetHighestDefensePokemon()
        {
            Pokemon returnPokemon = new Pokemon();
            returnPokemon.Defense = int.MinValue;
            foreach (Pokemon pokemon in Pokemons)
            {
                if (pokemon.Defense > returnPokemon.Defense)
                {
                    returnPokemon = pokemon;
                }
            }
            return returnPokemon;
        }

        public Pokemon GetHighestMaxCPPokemon()
        {
            Pokemon returnPokemon = new Pokemon();
            returnPokemon.MaxCP = int.MinValue;
            foreach (Pokemon pokemon in Pokemons)
            {
                if (pokemon.MaxCP > returnPokemon.MaxCP)
                {
                    returnPokemon = pokemon;
                }
            }
            return returnPokemon;
        }

    }
}
