/*
C# Poker Hands Project by Nicole Ramanathan
*/

namespace PokerHands
{

    //General Format of Project:A game has two hands. A hand has 5 cards. And based on the 5 cards it has, a hand has a value.

    internal class Card
    {
        // Encapsulation

        // readonly data is closed to modification outside of the constructor

        private readonly char rankChar; readonly char suitChar; readonly int rankNum; readonly int suitNum;

        public Card(char r, char s)
        {
            rankChar = r; suitChar = s;
            switch (r)
            {
                case '2':
                    rankNum = 2; break;
                case '3':
                    rankNum = 3; break;
                case '4':
                    rankNum = 4; break;
                case '5':
                    rankNum = 5; break;
                case '6':
                    rankNum = 6; break;
                case '7':
                    rankNum = 7; break;
                case '8':
                    rankNum = 8; break;
                case '9':
                    rankNum = 9; break;
                case 'T':
                    rankNum = 10; break;
                case 'J':
                    rankNum = 11; break;
                case 'Q':
                    rankNum = 12; break;
                case 'K':
                    rankNum = 13; break;
                case 'A':
                    rankNum = 14; break;
            }

            switch (s)
            {
                case 'H':
                    suitNum = 1; break;
                case 'C':
                    suitNum = 2; break;
                case 'D':
                    suitNum = 3; break;
                case 'S':
                    suitNum = 4; break;

            }

        }

        //Getters and Setters for Card

        public char getRankChar()
        {
            return rankChar;

        }

        public char getSuitChar()
        {
            return suitChar;

        }

        public int getSuitNum()
        {
            return suitNum;
        }
        public int getRankNum()
        {
            return rankNum;
        }

    }

}