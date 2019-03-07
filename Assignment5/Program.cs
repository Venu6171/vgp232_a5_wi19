using Assignment5.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");

            PokemonReader reader = new PokemonReader();
            Pokedex pokedex = reader.LoadPokedex("pokemon151.xml");

            // List out all the pokemons loaded
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                //Console.WriteLine(pokemon.Name);
            }

            // TODO: Add a pokemon bag with 2 bulbsaur, 1 charizard, 1 mew and 1 dragonite
            // and save it out and load it back and list it out.

            PokemonBag pokemonbag = new PokemonBag();
            pokemonbag.Pokemons.Add(1);
            pokemonbag.Pokemons.Add(1);
            pokemonbag.Pokemons.Add(6);
            pokemonbag.Pokemons.Add(151);
            pokemonbag.Pokemons.Add(149);

            using (PokemonUtil pokemonUtil = new PokemonUtil("PokemonBag.xml"))
            {
                pokemonUtil.Init();
                pokemonUtil.AddPokemonsToProcess(ref pokemonbag, ref pokedex);
                pokemonUtil.Write();
                pokemonUtil.Print();
                pokemonUtil.Clear();
            }

            Console.ReadKey();
        }
    }
}
