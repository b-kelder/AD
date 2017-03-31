using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADLibrary.Collections;

namespace TestApp
{
    class FishermanGenerator
    {
        //List of names to be used in random generation.
        List<string> firstNames = new List<string>()
        {
            "Sergio","Daniel","Carolina","David","Reina","Saul","Bernard",
            "Danny","Dimas","Yuri","Ivan","Laura", "Thomas", "Wouter", "Piet",
            "Hans", "Henk", "Sjon", "Jan", "QWERTYUIOP", "Klaas", "Pieter",
            "Sam", "Frodo", "Gandalf"
        };

        //List of names to be used in random generation.
        List<string> lastNames = new List<string>()
        {
            "Tapia","Gutierrez","Rueda","Galviz","Yuli","Rivera","Mamami",
            "Saucedo","Dominguez","Escobar","Martin","Crespo","Johnson",
            "Williams","Jones","Brown","David","Miller","Wilson","Anderson",
            "Thomas","Jackson","White","Robinson", "Stoevelaar", "Brookuis",
            "Piraat", "Post", "Brandweerman", "Sinter"
        };

        //Random object to create random fishermans
        Random random;

        /// <summary>
        /// Constructor of the Fisherman class
        /// </summary>
        public FishermanGenerator()
        {
            //Initialize random object
            random = new Random();
        }

        /// <summary>
        /// Method to generate a random fisherman
        /// </summary>
        /// <returns>A fisherman object</returns>
        public Fisherman generateRandomFisherman()
        {
            //Create random variables.
            string firstName = firstNames[random.Next(firstNames.Count)];
            string lastName = lastNames[random.Next(lastNames.Count)];
            int age = random.Next(80);
            int lenghtLargestFishEverCaught = random.Next(333);
            //Randomly select true or false
            bool ownsFishingBoat;
            if (random.Next(1) == 1)
            {
                ownsFishingBoat = true;
            }
            else
            {
                ownsFishingBoat = false;
            }

            //If name equals Thomas Stoevelaar, give him predefined stats.
            if (firstName.Equals("Thomas") && lastName.Equals("Stoevelaar"))
            {
                age = 19;
                lenghtLargestFishEverCaught = 9999999;
                ownsFishingBoat = false;
            }
            //Make sure Gandalf is just Gandalf
            else if (firstName.Equals("Gandalf"))
            {
                lastName = "";
            }
            //Make sure the first and last name are not in the wrong order
            else if (firstName.Equals("Klaas") && lastName.Equals("Sinter"))
            {
                firstName = "Sinterklaas";
            }

            //Return a new fisherman with de stats devined above
            return new Fisherman(firstName, lastName, age, lenghtLargestFishEverCaught, ownsFishingBoat);
        }
    }
}
