using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5.Data;

namespace PokemonTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Pokemon pokemon = new Pokemon
            {
                Index = 1,
                Name = "Bulbasaur",
                Type1 = "Grass",
                Type2 = "Poison",
                HP = 128,
                Attack = 118,
                Defense = 111,
                MaxCP = 1115
            };

            Assert.AreEqual(pokemon.Index, 1);

        }

        [TestMethod]
        public void TestMethod2()
        {
            Pokemon pokemon = new Pokemon
            {
                Index = 6,
                Name = "Charizard",
                Type1 = "Fire",
                Type2 = "Flying",
                HP = 186,
                Attack = 223,
                Defense = 173,
                MaxCP = 2889
            };

            Assert.AreEqual(pokemon.Type1, "Fire");

        }

        [TestMethod]
        public void TestMethod3()
        {
            Pokemon pokemon = new Pokemon
            {
                Index = 151,
                Name = "Mew",
                Type1 = "Psychic",
                HP = 225,
                Attack = 210,
                Defense = 210,
                MaxCP = 3265
            };

            Assert.AreEqual(pokemon.HP, 225);

        }

        [TestMethod]
        public void TestMethod4()
        {
            Pokemon pokemon = new Pokemon
            {
                Index = 149,
                Name = "Dragonite",
                Type1 = "Dragon",
                Type2 = "Flying",
                HP = 209,
                Attack = 263,
                Defense = 198,
                MaxCP = 3792
            };

            Assert.AreEqual(pokemon.MaxCP, 3792);

        }

        [TestMethod]
        public void TestMethod5()
        {
            Pokedex poke = new Pokedex();
            PokemonReader pokemonReader = new PokemonReader();

            poke = pokemonReader.LoadPokedex("pokemon151.xml");
           
            Assert.IsNotNull(poke.GetPokemonsOfType("Fire"));
        }

        [TestMethod]
        public void TestMethod6()
        {
            Pokedex poke = new Pokedex();
            PokemonReader pokemonReader = new PokemonReader();

            poke = pokemonReader.LoadPokedex("pokemon151.xml");

            Assert.IsNotNull(poke.GetPokemonByName("Bulbasaur"));
        }

        [TestMethod]
        public void TestMethod7()
        {
            Pokedex poke = new Pokedex();
            PokemonReader pokemonReader = new PokemonReader();

            poke = pokemonReader.LoadPokedex("pokemon151.xml");

            Assert.IsNotNull(poke.GetPokemonByIndex(6));
        }

        [TestMethod]
        public void TestMethod8()
        {
            Pokedex poke = new Pokedex();
            PokemonReader pokemonReader = new PokemonReader();

            poke = pokemonReader.LoadPokedex("pokemon151.xml");

            Assert.AreEqual(4178, poke.GetHighestMaxCPPokemon().MaxCP);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Pokedex poke = new Pokedex();
            PokemonReader pokemonReader = new PokemonReader();

            poke = pokemonReader.LoadPokedex("pokemon151.xml");

            Assert.AreEqual(487, poke.GetHighestHPPokemon().HP);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Pokedex poke = new Pokedex();
            PokemonReader pokemonReader = new PokemonReader();

            poke = pokemonReader.LoadPokedex("pokemon151.xml");

            Assert.AreEqual(300, poke.GetHighestAttackPokemon().Attack);
        }

        [TestMethod]
        public void TestMethod11()
        {
            Pokedex poke = new Pokedex();
            PokemonReader pokemonReader = new PokemonReader();

            poke = pokemonReader.LoadPokedex("pokemon151.xml");

            Assert.AreEqual(256, poke.GetHighestDefensePokemon().Defense);
        }

    }


}
