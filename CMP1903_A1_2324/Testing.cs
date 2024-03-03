using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324{
    /// <summary>
    /// A class for testing various other methods and classes output via debug.assert()
    /// </summary>
    internal class Testing{
        //Properties
        private const int _diceToRoll = 3; //the amount of dice to ask GameObj to roll
        private const int _diceMax = 6; //the maximum expected value of dice inclusive
        private const int _diceMin = 1; //the minimum expected value of dice inclusive

        //Methods

        /// <summary>
        /// Method for testing the Game class and its methods to ensure their output matches expected output.
        /// </summary>
        public void GameTest(){
            //Create a new game object and make it roll dice equal to number of dice to roll.
            //Check if dice list created is the same size as the amount of dice we rolled, raise exception otherwise.
            Game GameObj = new Game();
            GameObj.RollDice(_diceToRoll, true); //expect list of size diceToRoll
            Debug.Assert(GameObj.Dice.Count() == _diceToRoll, $"Game.RollDice() was asked to produce a List of size {_diceToRoll} and failed to do so.");

            //Check if dice made by game object have values in valid range, raise exception otherwise.
            int sum = 0; //initalise sum to 0.
            foreach (Die item in GameObj.Dice){ //iterate through each dice in the dice list of the GameObj.
                Debug.Assert(item.DiceValue <= _diceMax && item.DiceValue >= _diceMin, $"At least one of the dice values created by Game.RollDice() exceed the range {_diceMin} to {_diceMax} inclusive.");
                sum += item.DiceValue; //add it to running total.
            }
            //Check if sum given by SumDice matches expected output, raise exception otherwise.
            Debug.Assert(sum == GameObj.SumDice(), "The Game.SumDice() method did not output the expected sum.");

            //Check if mean given by MeanDice matches expected output, raise exception otherwise.
            double floatSum = sum; //convert previous sum to a float to ensure float division is used and not integer divison.
            Debug.Assert(floatSum/GameObj.Dice.Count() == GameObj.MeanDice(), "The Game.MeanDice() method did not output the expected mean.");
        }

        /// <summary>
        /// Method for testing the Die class and its methods to ensure their output matches expected output.
        /// </summary>
        public void DieTest(){
            //Create a new die and roll it.
            Die die = new Die();
            die.Roll();
            //Check if the dice value is in valid range, raise exception otherwise.
            Debug.Assert(die.DiceValue <= _diceMax &&  die.DiceValue >= _diceMin, $"Die.Roll() produced a die with a value outside of {_diceMin} and {_diceMax} inclusive.");
        }
    }
}
