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
        public List<Die> Dice { get { return _dice; } } //read only
        //Methods

        public void RollDice(int rollCount) { //create dice objects and roll them
            for (int rolls = 0; rolls < rollCount; rolls++)
            {
                _dice.Insert(rolls, new Die());
                _dice[rolls].Roll();

            }

        }

        public int SumDice()
        {
            int sum = 0;
            foreach(Die d in _dice)
            {
                sum += d.DiceValue;
            }

            return sum;
        }
            
    }       

}
