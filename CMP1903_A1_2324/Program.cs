using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324{
    internal class Program{
        //Properties
        private const int _diceToRoll = 3;

        //Methods

        /// <summary>
        /// The entry point for the program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args){
            // Create a game object and roll dice equal to the constant diceToRoll
            // And output the sum and mean of the dice rolls to console
            Game GameObj = new Game();
            GameObj.RollDice(_diceToRoll);
            int diceSum = GameObj.SumDice();
            double diceMean = GameObj.MeanDice();
            Console.WriteLine($"The sum of the dice is: {diceSum}");
            Console.WriteLine($"The mean of the dice is: {diceMean}");

            //Run tests
            Testing testing = new Testing();
            testing.GameTest();
            testing.DieTest();

            //Wait for user input before closing console
            Console.ReadLine();
        }
    }
}
