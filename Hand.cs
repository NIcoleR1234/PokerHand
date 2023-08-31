/*
C# Poker Hands Project by Nicole Ramanathan
*/

using System;

namespace PokerHands
{
    internal class Hand
    {
        // Encapsulation
        private Card[] _card5 = new Card[5];

        // readonly data is closed to modification outside of the constructor
        public readonly HandValue handValue;


        public Hand(string rs1, string rs2, string rs3, string rs4, string rs5)
        {



            _card5[0] = new Card(rs1[0], rs1[1]);
            _card5[1] = new Card(rs2[0], rs2[1]);
            _card5[2] = new Card(rs3[0], rs3[1]);
            _card5[3] = new Card(rs4[0], rs4[1]);
            _card5[4] = new Card(rs5[0], rs5[1]);

            handValue = typeClassify();


        }
        //Getters and Setters for Hand
        public int getCardRankNum(int num)
        {
            return _card5[num].getRankNum();
        }
        public char getCardRankChar(int num)
        {
            return _card5[num].getRankChar();
        }

        public int getCardSuitNum(int num)
        {
            return _card5[num].getSuitNum();
        }
        public char getCardSuitChar(int num)
        {
            return _card5[num].getSuitChar();
        }

        // Array of the ranks of the different cards
        int[] rank_stat()
        {
            int[] amount = new int[13];

            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 13; j++)
                {
                    if (j == (_card5[i].getRankNum() - 2))
                    {
                        amount[j]++;

                    }
                }
            }

            return amount;
        }

        // Array of the suits of the different cards
        int[] suit_stat()
        {
            int[] amount = new int[4];
            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 4; j++)
                {

                    if (j == (_card5[i].getSuitNum() - 1))
                    {
                        amount[j]++;
                    }
                }
            }
            return amount;
        }

        private HandValue typeClassify()
        {
            int[] rankAmount = rank_stat(), sortedRankAmount = rank_stat();

            // Array determining the suits of  all the cards
            int[] sortedSuitAmount = suit_stat();
            Array.Sort(sortedRankAmount); Array.Sort(sortedSuitAmount);
            bool consec = false;

            //Loop determining if the card ranks in the hand have consecutive values
            if (sortedRankAmount[12] == 1)
            {
                int[] rankStore = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    rankStore[i] = _card5[i].getRankNum();
                }
                Array.Sort(rankStore);
                if (rankStore[4] == rankStore[0] + 4)
                    consec = true;
            }

            //HandValue Classes called below:
            if (sortedSuitAmount[3] == 5 && consec == true)
            {
                HandValue straightFlush = new StraightFlush(rankAmount);
                return straightFlush;
            }

            else if (sortedRankAmount[12] == 4)
            {
                HandValue fourOfAKind = new FourOfAKind(rankAmount);
                return fourOfAKind;
            }

            else if (sortedRankAmount[12] == 3 && sortedRankAmount[11] == 2)
            {
                HandValue fullHouse = new FullHouse(rankAmount);
                return fullHouse;
            }

            else if (sortedSuitAmount[3] == 5)
            {
                HandValue flush = new Flush(rankAmount);
                return flush;
            }


            else if (consec == true)
            {
                HandValue straight = new Straight(rankAmount);
                return straight;

            }

            else if (sortedRankAmount[12] == 3)
            {
                HandValue threeOfAKind = new ThreeOfAKind(rankAmount);
                return threeOfAKind;

            }

            else if (sortedRankAmount[12] == 2 && sortedRankAmount[11] == 2)
            {
                HandValue twoPairs = new TwoPairs(rankAmount);
                return twoPairs;
            }

            else if (sortedRankAmount[12] == 2)
            {
                HandValue pair = new OnePair(rankAmount);
                return pair;
            }

            else
            {
                HandValue highCard = new HighCard(rankAmount);
                return highCard;
            }


        }

    }


}
