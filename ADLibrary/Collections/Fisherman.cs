using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public class Fisherman : IComparable<Fisherman>
    {
        //Store the data that defines the fisherman
        string firstName;
        string lastName;
        int age;
        int lenghtLargestFishEverCaught;
        bool ownsFishingBoat;

        /// <summary>
        /// Default constructor of the fisherman class
        /// </summary>
        public Fisherman() { }

        /// <summary>
        /// Secondary constructor of the fisherman class
        /// Used to instantly set all data on creation
        /// </summary>
        /// <param name="firstName">The fishermans first name</param>
        /// <param name="lastName">The fishermans last name</param>
        /// <param name="age">The fishermans age</param>
        /// <param name="lenghtLargestFishEverCaught">The size of the largest fish the fisherman has ever caught</param>
        /// <param name="ownsFishingBoat">If the fishermans owns a fishing boat</param>
        public Fisherman(string firstName, string lastName, int age, int lenghtLargestFishEverCaught, bool ownsFishingBoat)
        {
            //Set all the local vars to the enterd parameters
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.lenghtLargestFishEverCaught = lenghtLargestFishEverCaught;
            this.ownsFishingBoat = ownsFishingBoat;
        }

        /// <summary>
        /// Method used to compare the skill of two fisherman and determan who is beter
        /// </summary>
        /// <param name="other">The fisherman to compare against</param>
        /// <returns> 
        /// 1 if this fisherman is better
        /// -1 if this fisherman is worse
        /// 0 if the fisherman are equal in skill
        /// </returns>
        public int CompareTo(Fisherman other)
        {
            //Check to see who caught the larger fish, and thus is a better fishingman
            if (lenghtLargestFishEverCaught > other.lenghtLargestFishEverCaught)
            {
                return 1;
            }
            else if (lenghtLargestFishEverCaught < other.lenghtLargestFishEverCaught)
            {
                return -1;
            }
            //If the fish size is equal we need to determine who is better in a different way
            else
            {
                //Check to see who owns a fishingboat. 
                //Obviously the person without a fishingboat is more skilled because he can't sail out to sea to catch the bigger fish
                if (ownsFishingBoat == false && other.ownsFishingBoat)
                {
                    return 1;
                }
                else if (ownsFishingBoat && other.ownsFishingBoat == false)
                {
                    return -1;
                }
                //If they both have of don't have a fishingboat we need to measure skill based on experience
                //If a fisherman with less years of experience catches a fish of the same size he surely must be more skilled
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
                        //If after all this they are still equal, we can consider them equally skilled fisherman
                        return 0;
                    }
                }
            }
        }
    }
}
