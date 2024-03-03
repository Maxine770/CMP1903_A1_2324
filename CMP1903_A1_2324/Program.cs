using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main(string[] args) {

            /*
             * Create a Game object and call its methods.
             * Create a Testing object to verify the output and operation of the other classes.
             */
            const int diceToRoll = 3;
            Game GameObj = new Game();
            GameObj.RollDice(diceToRoll);
            int diceSum = GameObj.SumDice();
            double diceMean = GameObj.MeanDice();
            Console.WriteLine($"The sum of the dice is: {diceSum}");
            Console.WriteLine($"The mean of the dice is: {diceMean}");

            Testing testing = new Testing();
            testing.Test();

            Console.ReadLine();
        }
    }
}
