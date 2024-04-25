using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO Implement statistics class which tracks number of plays and highscores for EACH game type
//Just call function every time you play a game, prob from program. Track highscore by game instances instead and just dont send them if the CPU was responsible.
//Say in stats print out to console that it only considers human players.
//Must we do highscores for three or more if the game ends the instant you go over 20? Check.
//Statistics does *not* mean sumdice needs to be moved over so thats nice.
//TODO implement menu and testing and statistics class.
namespace CMP1903_A1_2324
{
    internal class Program{
        // Methods

        /// <summary>
        /// The entry point for the program.
        /// </summary>
        /// <param name="args"> Command line arguments. </param>
        public static void Main(string[] args){
            /*          
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

                            if (!int.TryParse(userInput, out diceToRoll)){ // If user input is valid integer continue and set diceToRoll to the integer of user input, terminate otherwise.
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

            */
            Game game = new Game(false);
            ThreeOrMore threeOrMore = new ThreeOrMore(false);
            threeOrMore.TakeTurn();
        }
    }
}
