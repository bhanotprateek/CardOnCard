using System;
using System.Collections.Generic;

namespace CardOnCard
{
    /// <summary>
    /// To know the player type
    /// </summary>
    public enum PlayerType
    {
        user=0,
        comp=1
    }

    /// <summary>
    /// Defination of the player
    /// </summary>
    public class CardOnCardPlayer
    {
        public Deck MyDeck { get; set; }
        private Random _random;
        private bool isStarted = false;
        private Stack<Card> _cardsPlayed;
        private Stack<Card> _shuffledDeck;
        private PlayerType _playerType { get; set; }
        public CardOnCardPlayer(Random random, PlayerType type)
        {
            MyDeck = new Deck();
            _random = random;
            _playerType = type;
            Initiate();
        }
        
        public void ShuffleMyDeck()
        {
            if (isStarted)
            {
                _shuffledDeck = new Stack<Card>();
                for (var i = 0; i < MyDeck.Cards.Count; i++)
                {
                    var temp = MyDeck.Cards[i];
                    var index = _random.Next(0, MyDeck.Cards.Count);
                    MyDeck.Cards[i] = MyDeck.Cards[index];
                    MyDeck.Cards[index] = temp;
                    _shuffledDeck.Push(temp);
                }
            }
        }

        private void Initiate()
        {
            isStarted = true;
            _cardsPlayed = new Stack<Card>();
            ShuffleMyDeck();
        }

        public void Reset()
        {
            MyDeck = new Deck();
            Initiate();
        }

        /// <summary>
        /// gets the top entry in the stack
        /// </summary>
        /// <returns></returns>
        public Card GetLastCardPlayed()
        {
            Card lastCardPlayed = null;
            if (_cardsPlayed.Count>0)
            {
                lastCardPlayed = _cardsPlayed.Peek();
            }
            return lastCardPlayed;
        }

        public int GetCardsInHandCount()
        {
            return MyDeck.Cards.Count;
        }

        public PlayerType GetPlayerType()
        {
            return _playerType;
        }

        /// <summary>
        /// Removes card from the shuffled deck and original deck
        /// Adds card to the played stack
        /// </summary>
        /// <returns></returns>
        public Card PlayACard()
        {
            Card myCard = _shuffledDeck.Pop();
            _cardsPlayed.Push(myCard);
            MyDeck.Cards.Remove(myCard);
            return myCard;
        }
    }
}
