using System;
using System.Collections;
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
        const int diceToRoll = 3;
        const int diceMax = 6;
        const int diceMin = 1;
        public void Test()
        {
            Game GameObj = new Game();
            GameObj.RollDice(diceToRoll, true); //expect list of size 3 with dice info.
            Debug.Assert(GameObj.Dice.Count() == diceToRoll, "Game.RollDice() was asked to produce a List of size 3 and failed to do so.");

            int sum = 0;
            foreach (Die item in GameObj.Dice) //the value of each dice is in range 1 to 6.
            {
                Debug.Assert(item.DiceValue <= diceMax && item.DiceValue >= diceMin, "At least one of the dice values created by GameObj.RollDice() exceed the range 1 to 6 inclusive.");
                sum += item.DiceValue;
            }
            Debug.Assert(sum == GameObj.SumDice(), "The GameObj.SumDice() method did not output the expected sum.");
            double floatSum = sum;
            Debug.Assert(floatSum/GameObj.Dice.Count() == GameObj.MeanDice(), "The GameObj.MeanDice() method did not output the expected mean.");

            //begin testing Die

            Die die = new Die();
            die.Roll();
            Debug.Assert(die.DiceValue <= diceMax &&  die.DiceValue >= diceMin, "Die.Roll() produced a die with a value outside of 1 and 6 inclusive."); //the value of die is within range.
        }
    }
}
