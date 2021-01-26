using System;
using System.Collections.Generic;

namespace CardOnCard
{
    /// <summary>
    /// Defination of a deck
    /// </summary>
    public class Deck
    {
        public List<Card> Cards { get; set; }

        /// <summary>
        /// Constructs a 52 cards deck
        /// with 13 cards of 4 suites
        /// with 9 numbered cards and 4 face cards
        /// </summary>
        public Deck()
        {
            Cards = new List<Card>();
            foreach (Suite suit in Enum.GetValues(typeof(Suite)))
            {
                for (int y = 2; y < 11; y++)
                {
                    Cards.Add(new Card(suit, y.ToString()));
                }
                Cards.Add(new Card(suit, "A"));
                Cards.Add(new Card(suit, "J"));
                Cards.Add(new Card(suit, "Q"));
                Cards.Add(new Card(suit, "K"));
            }
        }
    }
}
