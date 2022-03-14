using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your name:");
            string realHumanName = Console.ReadLine();
            Player realHuman = new HumanPlayer();
            realHuman.Name = realHumanName;

            Player player1 = new Player();
            player1.Name = "Bob";
            
            realHuman.Play(player1);

            Console.WriteLine("-------------------");

            Player player2 = new Player();
            player2.Name = "Sue";

            player2.Play(player1);

            Console.WriteLine("-------------------");

            Player player3 = new Player();
            player3.Name = "Wilma";

            player3.Play(player2);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            player1.Play(large);

            Console.WriteLine("-------------------");

            Player smackTalkPlayer = new SmackTalkingPlayer(); 
            smackTalkPlayer.Name = "Rudy McRuderson";
            
            player2.Play(smackTalkPlayer);

            Console.WriteLine("-------------------");

            Player highPlayer = new OneHigherPlayer();
            highPlayer.Name = "William Winsagain";

            highPlayer.Play(player2);
        
            Console.WriteLine("-------------------");

            Player creativeSmack = new CreativeSmackTalkingPlayer();
            creativeSmack.Name = "Billy the Toughguy";
                


            creativeSmack.Play(player1);

            List<Player> players = new List<Player>() {
                player1, player2, player3, large, smackTalkPlayer, highPlayer, realHuman, creativeSmack
            };

            PlayMany(players);
        }


        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play one another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                player1.Play(player2);
            }
        }
    }
}