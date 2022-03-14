using System;
using System.Collections.Generic;
namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        public List<string> Taunts = new List<string>
        {
            "You roll dice like a grandma!",
            "I heard your nickname is tiny dice!",
            "You're going to lose!",
        };
            public override int Roll()
        {
            Console.WriteLine($"{Name} says, \"{Taunts[new Random().Next(Taunts.Count - 1)]}\"");
            return new Random().Next(DiceSize) + 1;
        }
    }
}