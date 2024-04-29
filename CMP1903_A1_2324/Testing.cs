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
            Game gameObj = new Game(true);
            gameObj.RollDice(_diceToRoll, true); // Expect list of size diceToRoll, pass in true as the second argument to silence output from RollDice.
            Debug.Assert(gameObj.Dice.Count() == _diceToRoll, $"Game.RollDice() was expected to produce a list of size {_diceToRoll} and instead produced a list of size {gameObj.Dice.Count()}");

            // Check if dice made by game instance have values in valid range, raise an exception otherwise.
            int sum = 0;
            foreach (Die item in gameObj.Dice){ // Iterate through each dice in the dice list of the gameObj.
                Debug.Assert(item.DiceValue <= _diceMax && item.DiceValue >= _diceMin, $"The following dice value {item.DiceValue} produced by at least one of the die created by Game.RollDice() is outside the expected range {_diceMin} and {_diceMax} inclusive.");
                sum += item.DiceValue; // Add it to running total.
            }

            // Check if sum given by SumDice matches expected output, raise an exception otherwise.
            Debug.Assert(sum == gameObj.SumDice(gameObj.Dice), $"The Game.SumDice() method did not output the expected sum. \n Expected: {sum} \n Got: {gameObj.SumDice(gameObj.Dice)}");
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

        public void SevensOutTest(){
            SevensOut sevensOut = new SevensOut(true);
            int sevensOutScore = sevensOut.Play();
            Debug.Assert(sevensOut.SumHistory.Last() == 7, $"A game of SevensOut ended with a sum that wasn't 7. Expected: 7 Got: {sevensOut.SumHistory.Last()}");
            for(int i = 0; i < (sevensOut.SumHistory.Count()); i+=2) //sum every pair in dice history and check if it matches sevensOut sumHistory.
            {
                int pairSum = sevensOut.Dice[i].DiceValue + sevensOut.Dice[i + 1].DiceValue;
                if (i < sevensOut.SumHistory.Count() - 2) //verify no pairs before the last pair summed to 7.
                {
                    Debug.Assert(pairSum != 7, "SevensOut got a sum of seven but continued to roll more dice.");
                }
                Debug.Assert(pairSum == sevensOut.SumHistory[i / 2], $"SevensOut did not correctly sum dice. Expected: {pairSum} Got: {sevensOut.SumHistory[i / 2]}");
            }

        }

        public void ThreeOrMoreTest() {
            ThreeOrMore threeOrMore = new ThreeOrMore(true);
            int threeOrMoreScoreOld = 0; //score before taking a turn
            int expectedScore;
            while (threeOrMoreScoreOld < 20) {
                int threeOrMoreScore = threeOrMore.TakeTurn(); //new score this turn
                var currentDiceScoring =
                from dice in threeOrMore.CurrentDice
                group dice by dice.DiceValue into grp
                where grp.Count() >= 3 //only scoring hands
                select new { diceValue = grp.Key, count = grp.Count() };
                Debug.Assert(threeOrMore.HasWon == (threeOrMoreScore >= 20), $"ThreeOrMore.HasWon did not accurately represent the state of the game. Expected: {threeOrMoreScore >= 20} Got: {threeOrMore.HasWon}"); //is threeOrMore hasWon true if score is at least 20 and false if score lower than 20?
                if (currentDiceScoring.Any()) //any scoring hand
                {
                    var bestCombo = currentDiceScoring.First().count; //currentDiceScoring will only return 1 or 0 values.
                    expectedScore = Convert.ToInt32((3 * Math.Pow(2, (bestCombo - 3))) + threeOrMoreScoreOld); //add value of hand to threeOrMoreScoreOld
                }
                else //no scoring hand
                {
                    expectedScore = threeOrMoreScoreOld;
                }
                Debug.Assert(threeOrMoreScore == expectedScore, $"ThreeOrMore did not return the expected score. Expected: {expectedScore} Got: {threeOrMoreScore}");

                threeOrMoreScoreOld = threeOrMoreScore;
                }



        }
    }
}
