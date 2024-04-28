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
            string userInput;
            int option = 0;
            bool running = true;
            bool player2IsComputer;

            Console.WriteLine("Welcome. Note in all instances player 1 goes first, player 2 can be either a computer or human player.");

            while (running)
            {
                bool valid = false;
                while (!valid) {
                    Console.WriteLine("Please select from the following options via inputting the associated number:" +
                        "\n 1. Play Sevens Out" +
                        "\n 2. Play Three Or More" +
                        "\n 3. View statistics this session" +
                        "\n 4. Run tests" +
                        "\n 5. Quit");
                    userInput = Console.ReadLine();

                    if (!int.TryParse(userInput, out option)){ //not valid int
                        Console.WriteLine("Input is not a valid integer");
                        continue; //reprompt
                    }

                    if(option < 1 || option > 5) //outside of valid range
                    {
                        Console.WriteLine("Input is not a valid option");
                        continue; //reprompt
                    }

                    valid = true;
                }

                switch(option)
                {
                    case 1: // sevens out
                        Statistics.SevensOutIncrementPlayCount();
                        player2IsComputer = Game.UserInputPlayer2IsComputer();
                        Console.WriteLine("\n==Player 1==");
                        int player1Score = (new SevensOut(false)).Play();
                        Console.WriteLine("\n==Player 2==");
                        int player2Score = (new SevensOut(player2IsComputer)).Play();

                        Console.WriteLine($"Final scores were:" +
                            $"\n Player 1: {player1Score}" +
                            $"\n Player 2: {player2Score}");

                        if(player1Score > player2Score)
                        {
                            Console.WriteLine("Player 1 has won!");
                        } else if (player2Score > player1Score){
                            Console.WriteLine("Player 2 has won!");
                            
                        } else if ( player1Score == player2Score)
                        {
                            Console.WriteLine("Game ended in a draw.");
                        }
                        break;
                    case 2: // three or more
                        Statistics.ThreeOrMoreIncrementPlayCount();
                        player2IsComputer = Game.UserInputPlayer2IsComputer();
                        ThreeOrMore player1Game = new ThreeOrMore(false);
                        ThreeOrMore player2Game = new ThreeOrMore(player2IsComputer);
                        while (true) //playing
                        {
                            Console.WriteLine("\n==Player 1==");
                            player1Game.TakeTurn();
                            if (player1Game.HasWon)
                            {
                                Console.WriteLine("Player 1 has won!");
                                break; //end game
                            }
                            Console.WriteLine("\n==Player 2==");
                            player2Game.TakeTurn();
                            if (player2Game.HasWon)
                            {
                                Console.WriteLine("Player 2 has won!");
                                break; //end game
                            }
                        }
                        break;
                    case 3: // statistics
                        Statistics.DisplayStatistics();
                        break;
                    case 4: // testing
                        Testing.GameTest();
                        Testing.DieTest();
                        Testing.SevensOutTest();
                        Testing.ThreeOrMoreTest();
                        Console.WriteLine("Testing concluded.");
                        break;
                    case 5: // quit
                        running = false;
                        break;
                }

            }
        }
    }
}
