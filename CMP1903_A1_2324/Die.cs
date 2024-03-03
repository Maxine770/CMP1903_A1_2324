using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */

        //Property
        private static const  Random rnd = new Random();

        private int _diceValue = -1;
        public int DiceValue { get { return _diceValue; }} //read only

        //Method

        public int Roll()
        {
            _diceValue = rnd.Next(1, 7);
            return _diceValue;
        }

    }
}
