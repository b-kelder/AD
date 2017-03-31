using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public class Fisherman : IComparable<Fisherman>
    {
        string firstName;
        string lastName;
        int age;
        int lenghtLargestFishEverCaught;
        bool ownsFishingBoat;

        public Fisherman() { }

        public Fisherman(string firstName, string lastName, int age, int lenghtLargestFishEverCaught, bool ownsFishingBoat)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.lenghtLargestFishEverCaught = lenghtLargestFishEverCaught;
            this.ownsFishingBoat = ownsFishingBoat;
        }

        public int CompareTo(Fisherman other)
        {
            if (lenghtLargestFishEverCaught > other.lenghtLargestFishEverCaught)
            {
                return 1;
            }
            else if (lenghtLargestFishEverCaught < other.lenghtLargestFishEverCaught)
            {
                return -1;
            }
            else
            {
                if (ownsFishingBoat == false && other.ownsFishingBoat)
                {
                    return 1;
                }
                else if (ownsFishingBoat && other.ownsFishingBoat == false)
                {
                    return -1;
                }
                else
                {
                    if (age < other.age)
                    {
                        return 1;
                    }
                    else if (age > other.age)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
