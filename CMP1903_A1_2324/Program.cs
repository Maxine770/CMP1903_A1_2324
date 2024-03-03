using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * Create a Game object and call its methods.
             * Create a Testing object to verify the output and operation of the other classes.
             */
            private static const int diceToRoll = 3;
            private readonly Game _gameObj = new Game();
            _gameObj.RollDice(diceToRoll);
            private readonly int _diceSum = _gameObj.SumDice();
            private readonly double _diceMean = _gameObj.MeanDice();
            Console.WriteLine($"The sum of the dice is: {_diceSum}");
            Console.WriteLine($"The mean of the dice is: {_diceMean}");

            Testing testing = new Testing();
            testing.Test();

            Console.ReadLine();
        }
}
}
