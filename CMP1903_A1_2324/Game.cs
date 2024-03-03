using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// Represents a dice game, rolled dice are continous and added to a list.
    /// Methods allow for calculating various statistics of the dice values in the list.
    /// </summary>
    internal class Game
    {
        //Properties

        private List<Die> _dice = new List<Die>();
        public List<Die> Dice { get { return _dice; } } //read only to allow for testing.
        
        //Methods

        /// <summary>
        /// Create and roll dice objects and add them to the Dice list.
        /// </summary>
        /// <param name="rollCount"> The number of dice to roll </param>
        /// <param name="silent"> (Optional) If true will not print to console. </param>
        public void RollDice(int rollCount, bool silent = false)
        {
            for (int rolls = 0; rolls < rollCount; rolls++) 
            {
                _dice.Add(new Die());
                _dice.Last().Roll();
                if (!silent) {
                    Console.WriteLine($"Rolled a dice with a value of: {_dice.Last().DiceValue}");
                }
            }

        }

        /// <summary>
        /// Returns the sum of all the dice values in the dice list
        /// </summary>
        /// <returns> The sum of all the dice values in the dice list </returns>
        public int SumDice()
        {
            ///Sum value of all dice objects
            int sum = 0;
            foreach(Die d in _dice)
            {
                sum += d.DiceValue;
            }

            return sum;
        }

        /// <summary>
        /// Returns the mean of all the dice values in the dice list
        /// </summary>
        /// <returns> The mean of all the dice values in the dice list </returns>
        public double MeanDice()
        {
            double sum = SumDice();
            double mean =  sum / _dice.Count();
            return mean; 
        }
            
    }       

}
