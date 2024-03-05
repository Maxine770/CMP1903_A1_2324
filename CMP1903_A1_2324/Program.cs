using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324{
    internal class Program{
        // Methods

        /// <summary>
        /// The entry point for the program.
        /// </summary>
        /// <param name="args"> Command line arguments. </param>
        public static void Main(string[] args){
            // Run tests.
            Testing testing = new Testing();
            testing.GameTest();
            testing.DieTest();

            Game gameObj = new Game();
            int diceToRoll;

            // While running
            while (true){
                // Take user input.
                Console.WriteLine("Please input an integer number of dice to roll that is more than 0. Input a non-valid integer or a number less than 1 to exit.");
                string userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out diceToRoll)){ // If user input is valid continue and set diceToRoll to the integer of user input, terminate otherwise.
                    break; // Terminate.
                }
                if(diceToRoll <= 0){
                    break; // Terminate.
                }

                gameObj.RollDice(diceToRoll);

                // Run statistics and output to console.
                int diceSum = gameObj.SumDice();
                double diceMean = gameObj.MeanDice();
                Console.WriteLine($"The sum of all the dice rolled so far is: {diceSum}");
                Console.WriteLine($"The mean of all the dice rolled so far is: {diceMean}");
            }
        }
    }
}
