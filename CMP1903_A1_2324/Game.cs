using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        //properties

        private List<Die> _dice = new List<Die>();
        public List<Die> Dice { get { return _dice; } } //read only to allow for testing.
        //Methods

        public void RollDice(int rollCount, bool silent = false)
        {
            ///create dice objects and roll them, optional parameter to be silent (for tests)
            for (int rolls = 0; rolls < rollCount; rolls++)
            {
                _dice.Insert(rolls, new Die());
                _dice[rolls].Roll();
                if (!silent) {
                    Console.WriteLine($"Rolled a dice with a value of: {_dice[rolls].DiceValue}");
                }
            }

        }

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

        public double MeanDice()
        {
            double sum = SumDice();
            double mean =  sum / _dice.Count();
            return mean; 
        }
            
    }       

}
