/*
C# Poker Hands Project by Nicole Ramanathan
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PokerHands
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //Both the input and output files are in PokersHand/bin/Debug
                string input = ("InputFile.txt"); string output = ("OutputFile.txt");
                File.WriteAllText(output, string.Empty);


                List<string> lines = new List<string>();

                lines = File.ReadAllLines(input).ToList();

                foreach (String line in lines)
                {
                    Console.WriteLine(line);
                    //Console should run correctly for input formatted as it is in coding dojo
                    var words1 = line.Split();
                    string[] playerOneCards = new string[5], playerTwoCards = new string[5]; ;
                    for (int i = 0; i < 5; i++)
                    {
                        playerOneCards[i] = words1[1 + i];
                        //Console.WriteLine(playerOneCards[i]);
                    }

                    Hand player1 = new Hand(playerOneCards[0], playerOneCards[1], playerOneCards[2], playerOneCards[3], playerOneCards[4]);


                    for (int i = 0; i < 5; i++)
                    {
                        playerTwoCards[i] = words1[8 + i];
                        //Console.WriteLine(playerTwoCards[i]);
                    }

                    Hand player2 = new Hand(playerTwoCards[0], playerTwoCards[1], playerTwoCards[2], playerTwoCards[3], playerTwoCards[4]);

                    Game game = new Game(player1, player2);

                    // Both the input and output can be seen in the console
                    Console.WriteLine(game.Compare());

                    //The output by itself is in the OutputFile.txt.
                    File.AppendAllText(output, game.Compare());
                }

            }

            catch (Exception ex)
                { throw ex; }






        }
    }
}