/*
 C# Poker Hands Project by Nicole Ramanathan
 */

using System;
using System.Collections.Generic;

namespace PokerHands
{
    internal abstract class HandValue
    {
        // Encapsulation

        // Single Responsibility Principle: HandValue's only reason to change is the value of the cards.

        // handBasedValue is the number that indentifies the hand type (aka Straight Flush, Four of a Kind, Full House etc.)
        protected int handBasedValue;

        //List of the rank value of each card in the hand from least important to most
        protected List<int> cardValueList;

        //Integer compounding all the rank list values into one. Will be used if handBasedValue is the same for black and white
        protected int cardValueNum;

        // hand type name
        protected string name;


        public int GetHandBasedValue() { return handBasedValue; }

        // Abstraction necessitates creating a subclass to create an object using the parent class's methods.

        // If this class was entirely abstract then it would fit into the Dependency Inversion Design Pattern.

        protected abstract List<int> SetCardValueList(int[] rAm);

        public List<int> GetCardValueList() { return cardValueList; }

        public int GetCardValueNum() { return cardValueNum; }

        public string GetName() { return name; }

        protected int SetCardValueNum(List<int> ttList)
        {
            int c = 1, num = 0;
            foreach (int i in ttList)
            {
                num += i * c;

                // c must be multiplied by a number 13 or above in order not to hit the same number with a different rank.

                if (i < 13) c *= 14;
            }
            return num;
        }

        public HandValue(int[] rAm)
        {
            cardValueList = SetCardValueList(rAm);
            cardValueNum = SetCardValueNum(cardValueList);
        }

    }

    /*Here are all the subclasses of HandValue (Inheritance):
    
    *Here are the superclasses for the value types that use the same method. 
    
    *The HandValue super/sub class design follows Liskovs principle. 

    *"Functions that use pointers or references to base classes must be able to use objects of derived classes without knowing it."
    
     */

    internal class StraightFlushAndStraight : HandValue
    {
        protected StraightFlushAndStraight(int[] rAm) : base(rAm) { }

        protected override List<int> SetCardValueList(int[] rAm)
        {
            List<int> order = new List<int>();
            for (int iterRank = 0; iterRank < 13; iterRank++)
            {
                if (rAm[iterRank] == 1)
                { order.Add(iterRank); }
            }
            return order;
        }

    }

    internal class FlushandHighCard : HandValue
    {
        protected FlushandHighCard(int[] rAm) : base(rAm) { }

        protected override List<int> SetCardValueList(int[] rAm)
        {
            int iterCard = 0; List<int> order = new List<int>();

            for (int iterRank = 0; iterRank < 13 && iterCard < 5; iterRank++)
            {
                if (rAm[iterRank] == 1)
                {

                    order.Add(iterRank); iterCard++;

                }
            }
            return order;
        }
    }

    //Here are individual hand value types:
    internal class StraightFlush : StraightFlushAndStraight
    {
        public StraightFlush(int[] rAm) : base(rAm)
        {
            this.handBasedValue = 9;
            this.name = " straight flush: " + this.name;

        }

    }
    internal class FourOfAKind : HandValue
    {
        public FourOfAKind(int[] rAm) : base(rAm)
        {
            this.handBasedValue = 8;
            this.name = " four of a kind: ";

        }


        protected override List<int> SetCardValueList(int[] rAm)
        {
            List<int> order = new List<int>();
            for (int iterRank = 0; iterRank < 13; iterRank++)
            {
                if (rAm[iterRank] == 4)
                { order.Add(iterRank); }
            }
            return order;
        }

    }
    internal class FullHouse : HandValue
    {

        public FullHouse(int[] rAm) : base(rAm)
        {
            this.handBasedValue = 7;
            this.name = " full house: ";
        }

        protected override List<int> SetCardValueList(int[] rAm)
        {
            List<int> order = new List<int>();
            for (int iterRank = 0; iterRank < 13; iterRank++)
            {
                if (rAm[iterRank] == 3 || rAm[iterRank] == 2)
                { order.Add(iterRank); }
            }

            return order;
        }

    }

    internal class Flush : FlushandHighCard
    {

        public Flush(int[] rAm) : base(rAm)
        {
            this.handBasedValue = 6;
            this.name = " flush: ";
        }

    }

    internal class Straight : StraightFlushAndStraight
    {

        public Straight(int[] rAm) : base(rAm)
        {
            this.handBasedValue = 5;
            this.name = " straight: ";
        }


    }

    internal class ThreeOfAKind : HandValue
    {

        public ThreeOfAKind(int[] rAm) : base(rAm)
        {
            this.handBasedValue = 4;
            this.name = " three of a kind: ";
        }

        protected override List<int> SetCardValueList(int[] rAm)
        {
            int x = 0, iterCard = 0; List<int> order = new List<int>();
            for (int iterRank = 0; iterRank < 13; iterRank++)
            {
                if (rAm[iterRank] == 3)
                { x = iterRank; }
                else if (rAm[iterRank] == 1)
                {
                    if (iterCard == 0 || iterCard == 1)
                    { order.Add(iterRank); iterCard++; }


                }
            }
            order.Add(x);

            return order;
        }


    }

    internal class TwoPairs : HandValue
    {
        public TwoPairs(int[] rAm) : base(rAm)
        {
            this.handBasedValue = 3;
            this.name = " two pairs: ";
        }


        protected override List<int> SetCardValueList(int[] rAm)
        {
            int iterCard = 0, lowPair = 0, highPair = 0; List<int> order = new List<int>();
            for (int iterRank = 0; iterRank < 13; iterRank++)
            {
                if (rAm[iterRank] == 2)
                {
                    if (iterCard == 0)
                    { lowPair = iterRank; iterCard++; }
                    else if (iterCard == 1)
                    { highPair = iterRank; iterCard++; }
                }
                if (rAm[iterRank] == 1)
                    order.Add(iterRank);
            }
            order.Add(lowPair);
            order.Add(highPair);
            return order;
        }

    }

    internal class OnePair : HandValue
    {

        public OnePair(int[] rAm) : base(rAm)
        {
            this.handBasedValue = 2;
            this.name = " one pair: ";
        }

        protected override List<int> SetCardValueList(int[] rAm)
        {
            int pair = 0; List<int> order = new List<int>();
            for (int iterRank = 0; iterRank < 13; iterRank++)
            {
                if (rAm[iterRank] == 2)
                { pair = iterRank; }
                else if (rAm[iterRank] == 1)
                {
                    order.Add(iterRank);

                }
            }
            order.Add(pair);
            return order;
        }

    }

    internal class HighCard : FlushandHighCard
    {

        public HighCard(int[] rAm) : base(rAm)
        {
            this.handBasedValue = 1;
            this.name = " high card: ";
        }



    }

}