using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324{
    /// <summary>
    /// Represents a dice game, rolled dice are continuous and added to a list unique per game instance.
    /// Methods allow for calculating various statistics of the dice values in the list.
    /// Note this is one instance of a dice game, played by one player. For multiplayer games create multiple instances.
    /// </summary>
    internal class Game{
        // Properties
        private List<Die> _dice = new List<Die>();
        private List<Die> _currentBatch = new List<Die>(); // list containing dice rolled this specific batch rather than over the lifespan of this game object.
        private int _score = 0;
        private bool _isComputer; // true if this game object is a computer player, false if human player

        public List<Die> Dice{get{return _dice;}} // Read only.
        public List<Die> currentBatch { get { return _currentBatch;}} // Read only

        public Game(bool IsComputer)
        {
            _isComputer = IsComputer;
        }

        // Methods

        /// <summary>
        /// Create and roll dice instances and add them to the end of the dice list.
        /// Outputs the value of rolled dice to console.
        /// </summary>
        /// <param name="rollCount"> The number of dice to roll. </param>
        /// <param name="silent"> (Optional) If true will not print to console. </param>
        /// <returns> A list of current batch of dice rolled </returns>
        public List<Die> RollDice(int rollCount, bool silent = false){
            _currentBatch.Clear();
            for (int rolls = 0; rolls < rollCount; rolls++){
                _currentBatch.Add(new Die());
                _currentBatch.Last().Roll();
                _dice.Add(new Die());
                _dice.Last().Roll();
                if (!silent){
                    Console.WriteLine($"Rolled a dice with a value of: {_dice.Last().DiceValue}");
                }
            }

            return _currentBatch; //returns list of dice rolled this batch
        }

        /// <summary>
        /// Returns the sum of all the dice values in the passed list or dice list if no list provided.
        /// </summary>
        /// <param name="diceToSum"> List of dice to sum, if none provided defaults to dice list </param>
        /// <returns> The sum of all the dice values in the passed list or dice list if no list provided. </returns>
        public int SumDice(List<Die> diceToSum = _dice ){
            int sum = 0;
            foreach(Die d in diceToSum){ // Iterate through list.
                sum += d.DiceValue; // Increment sum by current dice's value.
            }
            return sum;
        }


    }

    internal class SevensOut : Game
    {
        public SevensOut(bool _isComputer) : base(_isComputer) { } //inherit constructor

        public int Play()
        {
            while (true){ // keep going until seven rolled
                if (!_isComputer)
                {
                    Console.ReadLine("Press enter to roll dice");
                }
                List<Die> rolledDice = RollDice(2); // this batch of dice
                int sumOfRolledDice = SumDice(rolledDice);

                // check if sum is 7
                if (sumOfRolledDice == 7)
                {
                    Console.WriteLine($"Sum of dice is seven, final score is {_score}");
                    return _score;
                }

                // check if rolled doubles
                if (rolledDice[0] = rolledDice[1]) {
                    Console.WriteLine($"Rolled doubles! \n Sum: {sumOfRolledDice} \n Scored: {sumOfRolledDice * 2}");
                    _score += sumOfRolledDice * 2;
                } else
                {
                    Console.WriteLine($"Sum of dice is {sumOfRolledDice} and scored said sum");
                    _score += sumOfRolledDice;
                }
            }
        }
    }

    internal class ThreeOrMore : Game
    {
        public ThreeOrMore(bool _isComputer) : base(_isComputer) { } // inherit constructor

        public int TakeTurn()
        {
            if (!_isComputer)
            {
                Console.ReadLine("Press enter to roll dice")
            }
            List<Die> rolledDice = RollDice(5); // current dice in play
            //TODO code. And find out how to handle 2 seperate two of a kinds.

        }
    }
}
