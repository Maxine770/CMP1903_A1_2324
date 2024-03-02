using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        //Method

        public void Test()
        {
            Game GameObj = new Game();
            GameObj.RollDice(3); //expect list of size 3 with dice info.
            Debug.Assert(GameObj.Dice.Count() == 3);

            int sum = 0;
            foreach (Die item in GameObj.Dice) //the value of each dice is in range 1 to 6.
            {
                Debug.Assert(item.DiceValue <= 6 && item.DiceValue >=1);
                sum += item.DiceValue;
            }
            Debug.Assert(sum == GameObj.SumDice());

            //begin testing Die

            Die die = new Die();
            die.Roll();
            Debug.Assert(die.DiceValue <=6 &&  die.DiceValue >= 1); //the value of die is within range.
        }
    }
}
