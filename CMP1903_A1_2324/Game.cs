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
        protected List<Die> _dice = new List<Die>();
        protected List<Die> _currentBatch = new List<Die>(); // list containing dice rolled this specific batch rather than over the lifespan of this game object.
        protected int _score = 0;
        protected bool _isComputer; // true if this game object is a computer player, false if human player

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
                Die currentDie = new Die();
                currentDie.Roll();
                _currentBatch.Add(currentDie);
                _dice.Add(currentDie);
                if (!silent){
                    Console.WriteLine($"Rolled a dice with a value of: {currentDie.DiceValue}");
                }
            }

            return _currentBatch; //returns list of dice rolled this batch
        }

        /// <summary>
        /// Returns the sum of all the dice values in the passed list or dice list if no list provided.
        /// </summary>
        /// <param name="diceToSum"> List of dice to sum, if none provided defaults to dice list </param>
        /// <returns> The sum of all the dice values in the passed list or dice list if no list provided. </returns>
        public int SumDice(List<Die> diceToSum){
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
                    Console.WriteLine("Press enter to roll dice");
                    Console.ReadLine();
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
                if (rolledDice[0].DiceValue == rolledDice[1].DiceValue) {
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

       public void TakeTurn() //TODO change void to int and return score
        {
            if (!_isComputer)
            {
                Console.WriteLine("Press enter to roll dice");
                Console.ReadLine();
            }
            List<Die> rolledDice = RollDice(5); // current dice in play
            int diceValueToKeep = 0; //If rerolling dice, reroll all dice that aren't this value. By default will reroll all dice.
            bool rerollDice = false;
            string userInput;
            int bestCombo = 0;
            // rolled dice that are two of a kind or better. Dice values that are one of a kind are useless, as any rerolls will eliminate them and they serve no purpose otherwise.
            //Dice value is the value of the dice and instances is the number of dice with that value.
            var rolledDiceScoring =
                from dice in rolledDice
                group dice by dice.DiceValue into grp //group same dice values into same group
                where grp.Count() >=2
                select new { diceValue = grp.Key, count = grp.Count() };

            if (!rolledDiceScoring.Any())
            {
                Console.WriteLine("All dice are unique, nothing has been scored.");
                return _score;
            }
            //Reroll edge case handling.
            if (rolledDiceScoring.Count() == 2) //two pair or full house
            {
                rerollDice = true;
                bool isFullHouse = false;
                foreach ( var combo in rolledDiceScoring) //check if least one of the two is a three of a kind
                {
                    if (combo.count == 3) // 
                    {
                        isFullHouse = true;
                        diceValueToKeep = combo.diceValue; //spare the three of a kind from rerolling
                    }
                }

                if(isFullHouse)
                {
                    if (!_isComputer) {
                        Console.WriteLine("You have rolled a three of a kind and a two of a kind, press enter to reroll the two of a kind.");
                        Console.ReadLine();
                    } else
                    {
                        Console.WriteLine("The computer has rolled a three of a kind and a two of a kind and will now reroll the two of a kind.");
                    }
                } else // two pair
                {
                    if (!_isComputer)
                    {
                        Console.WriteLine("You have rolled two seperate two of a kinds, input the dice value belonging to the dice in one of the two of the kinds you wish to reroll. Input anything else or a dice value that is not part of a two of a kind to reroll ALL dice.");
                        string userInput = Console.ReadLine();

                        if (int.TryParse(userInput, out int temp))
                        { 
                            foreach(var combo in rolledDiceScoring)
                            {
                                if (combo.diceValue == temp) //if dice value chosen is one of the two dice values belonging to the two seperate two of a kinds, then keep said dice value and reroll all else. Otherwise reroll all.
                                {
                                    diceValueToKeep = temp;
                                }
                            }
                        }
                    } else
                    {
                        Console.WriteLine("The computer has rolled two seperate two of a kinds and has chosen to reroll all dice.")
                    }
                }
            } else //only have 1 combo from now on.
            {
                foreach( var combo in rolledDiceScoring)
                {
                    if (combo.count == 2)
                    {
                        rerollDice = true;
                        if (_isComputer)
                        {
                            Console.WriteLine("The computer has rolled a two of a kind and has chosen to reroll all dice except the two of a kind");
                            diceValueToKeep = combo.diceValue;
                        } else
                        {
                            Console.WriteLine("You have rolled a two of a kind and will now reroll dice, input Y or y if you wish to keep the two of a kind, input anything else to reroll ALL dice.");
                            userInput = Console.ReadLine();
                            if (userInput.ToLower() == "y")
                            {
                                diceValueToKeep = combo.diceValue;
                            }
                        }
                    }
                }    
            }
            //End of deciding which dice to reroll

            //Execute rerolls, if any.
            if (rerollDice) {
                foreach (Die currentDie in rolledDice)
                {
                    if (currentDie != diceValueToKeep) //if not keeping this die, reroll it.
                    {
                        currentDie.Roll();
                    }
                }
            }

            //Find best combo, ensures full house will always return the three of a kind as best combo.
            foreach( var combo in rolledDiceScoring)
            {
                if (combo.diceValue > bestCombo)
                {
                    bestCombo = combo.count;
                }
            }

            if (bestCombo >=3) //3 of a kind scores 3, 4 of a kind scores 6, 5 of a kind scores 12.
            {
                Console.WriteLine($"Scored {3 * Math.Pow(2,(bestCombo - 3))} points.");
                _score += 3 * Math.Pow(2,(bestCombo - 3));
            } else
            {
                Console.WriteLine("Scored no points.")
            }

            return _score;
        }
    }
}
