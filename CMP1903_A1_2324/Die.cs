using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// A class for handling a singular dice, tracking its current dice value.
    /// </summary>
    internal class Die
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */

        //Properties
        private static readonly  Random rnd = new Random();

        private int _diceValue = -1;
        public int DiceValue { get { return _diceValue; }} //read only

        //Methods

        /// <summary>
        /// Roll the dice with a value between 1 and 6 inclusive and updating the dice's value.
        /// </summary>
        /// <returns> The dice value the rolled dice was changed to </returns>
        public int Roll()
        {
            _diceValue = rnd.Next(1, 7);
            return _diceValue;
        }

    }
}
