
﻿/*
 C# Poker Hands Project by Nicole Ramanathan
 */

using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    internal class Game
    {
        // Encapsulation
        Hand black;
        Hand white;

        public Game(Hand b, Hand w)
        {
            black = b;
            white = w;
            Compare();

        }

        private int HighestCard(List<int> win, List<int> lose)
        {
            bool equiv = true; int x = 0;
            for (int i = win.Count - 1; i >= 0 && equiv == true; i--)
            {

                if (win[i] != lose[i])
                { equiv = false; x = i; }
            }
            return win[x];
        }

        private string PushNumInDescript(int num)
        {

            switch (num)
            {
                case 0:
                    return "2";
                case 1:
                    return "3";
                case 2:
                    return "4";
                case 3:
                    return "5";
                case 4:
                    return "6";
                case 5:
                    return "7";
                case 6:
                    return "8";
                case 7:
                    return "9";
                case 8:
                    return "10";
                case 9:
                    return "Jack";
                case 10:
                    return "Queen";
                case 11:
                    return "King";
                case 12:
                    return "Ace";
            }
            return "0";
        }

        private string WinnersPrint(Hand win, Hand lose)
        {
            string description = win.handValue.GetName();
            //  got  the different description types from "https://en.wikipedia.org/wiki/List_of_poker_hands"
            if (win.handValue.GetHandBasedValue() != 7 && win.handValue.GetHandBasedValue() != 3)
            {
                if (win.handValue.GetHandBasedValue() > lose.handValue.GetHandBasedValue())
                {
                    description += PushNumInDescript(win.handValue.GetCardValueList().Last());
                }
                else
                {
                    description += PushNumInDescript(HighestCard(win.handValue.GetCardValueList(), lose.handValue.GetCardValueList()));
                }
            }
            else if (win.handValue.GetHandBasedValue() == 7)
            {

                description += PushNumInDescript(win.handValue.GetCardValueList().Last()) + " over " + PushNumInDescript(win.handValue.GetCardValueList().First());
            }
            else
            {
                if (win.handValue.GetCardValueList().Last() == lose.handValue.GetCardValueList().Last() && win.handValue.GetCardValueList()[1] == lose.handValue.GetCardValueList()[1])
                {
                    description += PushNumInDescript(HighestCard(win.handValue.GetCardValueList(), lose.handValue.GetCardValueList()));
                }
                else
                {
                    description += PushNumInDescript(win.handValue.GetCardValueList().Last()) + " over " + PushNumInDescript(win.handValue.GetCardValueList()[1]);
                }
            }
            return description;
        }
        public string Compare()
        {
            string description = "";
            if (black.handValue.GetHandBasedValue() > white.handValue.GetHandBasedValue() || (black.handValue.GetCardValueNum() > white.handValue.GetCardValueNum() && black.handValue.GetHandBasedValue() == white.handValue.GetHandBasedValue()))
            {
                description += "Black wins. - with ";
                description += WinnersPrint(black, white);
            }

            else if (black.handValue.GetHandBasedValue() < white.handValue.GetHandBasedValue() || (black.handValue.GetCardValueNum() < white.handValue.GetCardValueNum() && black.handValue.GetHandBasedValue() == white.handValue.GetHandBasedValue()))
            {
                description += "White wins. - with ";
                description += WinnersPrint(white, black);
            }

            else
            {
                description += "Tie.";
            }
            description += "\n";
            return description;
        }

    }
}