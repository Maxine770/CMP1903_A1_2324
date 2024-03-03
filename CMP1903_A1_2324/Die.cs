using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324{
    /// <summary>
    /// A class for handling and rolling a singular dice, tracking its current dice value.
    /// Dices are made without a value until first rolled.
    /// </summary>
    internal class Die{
        //Properties
        private static readonly  Random _rnd = new Random(); //random object used for randomising each dice roll
        private const int _diceMax = 6; //the maximum value of dice inclusive
        private const int _diceMin = 1; //the minimum value of dice inclusive
        private int _diceValue; //the current value of this die

        public int DiceValue {get{return _diceValue;}} //read only

        //Methods

        /// <summary>
        /// Roll the dice with a value between 1 and 6 inclusive and updating the dice's value.
        /// </summary>
        /// <returns> The dice value the rolled dice was changed to </returns>
        public int Roll(){
            _diceValue = _rnd.Next(_diceMin, _diceMax+1); //randomise dice value to a value in range diceMin to diceMax inclusive.
            return _diceValue; //return the new dice value
        }
    }
}
