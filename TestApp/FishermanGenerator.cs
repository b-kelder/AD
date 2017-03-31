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
        List<string> firstNames = new List<string>()
        {
            "Sergio","Daniel","Carolina","David","Reina","Saul","Bernard",
            "Danny","Dimas","Yuri","Ivan","Laura", "Thomas", "Wouter", "Piet",
            "Hans", "Henk", "Sjon", "Jan", "QWERTYUIOP", "Klaas", "Pieter",
            "Sam", "Frodo", "Gandalf"
        };

        List<string> lastNames = new List<string>()
        {
            "Tapia","Gutierrez","Rueda","Galviz","Yuli","Rivera","Mamami",
            "Saucedo","Dominguez","Escobar","Martin","Crespo","Johnson",
            "Williams","Jones","Brown","David","Miller","Wilson","Anderson",
            "Thomas","Jackson","White","Robinson", "Stoevelaar", "Brookuis",
            "Piraat", "Post", "Brandweerman", "Sinter"
        };

        Random random;

        public FishermanGenerator()
        {
            random = new Random();
        }

        public Fisherman generateRandomFisherman()
        {
            string firstName = firstNames[random.Next(firstNames.Count)];
            string lastName = lastNames[random.Next(lastNames.Count)];
            int age = random.Next(80);
            int lenghtLargestFishEverCaught = random.Next(333);

            bool ownsFishingBoat;
            if (random.Next(1) == 1)
            {
                ownsFishingBoat = true;
            }
            else
            {
                ownsFishingBoat = false;
            }

            if (firstName.Equals("Thomas") && lastName.Equals("Stoevelaar"))
            {
                age = 19;
                lenghtLargestFishEverCaught = 9999999;
                ownsFishingBoat = false;
            }
            else if (firstName.Equals("Gandalf"))
            {
                lastName = "";
            }
            else if (firstName.Equals("Klaas") && lastName.Equals("Sinter"))
            {
                firstName = "Sinterklaas";
                ownsFishingBoat = true;
                age = 1266;
            }

            return new Fisherman(firstName, lastName, age, lenghtLargestFishEverCaught, ownsFishingBoat);
        }
    }
}
