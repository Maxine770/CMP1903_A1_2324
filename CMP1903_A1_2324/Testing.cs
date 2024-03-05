using System;
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
        // Properties
        private const int _diceToRoll = 3; // The amount of dice to ask GameObj to roll.
        // _diceMax and _diceMin define the range of dice rolls inclusive.
        private const int _diceMax = 6;
        private const int _diceMin = 1;

        // Methods

        /// <summary>
        /// Method for testing the Game class and its methods to ensure their output matches expected output.
        /// </summary>
        public void GameTest(){
            // Create a new game instance and make it roll dice equal to number of dice to roll.
            // Check if dice list created is the same size as the amount of dice we rolled, raise an exception otherwise.
            Game gameObj = new Game();
            gameObj.RollDice(_diceToRoll, true); // Expect list of size diceToRoll, pass in true as the second argument to silence output from RollDice.
            Debug.Assert(gameObj.Dice.Count() == _diceToRoll, $"Game.RollDice() was expected to produce a list of size {_diceToRoll} and instead produced a list of size {gameObj.Dice.Count()}");

            // Check if dice made by game instance have values in valid range, raise an exception otherwise.
            int sum = 0;
            foreach (Die item in gameObj.Dice){ // Iterate through each dice in the dice list of the gameObj.
                Debug.Assert(item.DiceValue <= _diceMax && item.DiceValue >= _diceMin, $"The following dice value {item.DiceValue} produced by at least one of the die created by Game.RollDice() is outside the expected range {_diceMin} and {_diceMax} inclusive.");
                sum += item.DiceValue; // Add it to running total.
            }

            // Check if sum given by SumDice matches expected output, raise an exception otherwise.
            Debug.Assert(sum == gameObj.SumDice(), $"The Game.SumDice() method did not output the expected sum. \n Expected: {sum} \n Got: {gameObj.SumDice()}");

            // Check if mean given by MeanDice matches expected output, raise an exception otherwise.
            double floatSum = sum; // Convert previous sum to a float to ensure float division is used and not integer division.
            Debug.Assert(floatSum/gameObj.Dice.Count() == gameObj.MeanDice(), $"The Game.MeanDice() method did not output the expected mean. \n Expected: {floatSum/gameObj.Dice.Count()} \n Got: {gameObj.MeanDice()}");
        }

        /// <summary>
        /// Method for testing the Die class and its methods to ensure their output matches expected output.
        /// </summary>
        public void DieTest(){
            // Create a new die and roll it.
            Die die = new Die();
            die.Roll();

            // Check if the dice value is in valid range, raise an exception otherwise.
            Debug.Assert(die.DiceValue <= _diceMax &&  die.DiceValue >= _diceMin, $"Die.Roll() produced a die with a value of {die.DiceValue} which is outside of the expected range {_diceMin} and {_diceMax} inclusive.");
        }
    }
}
