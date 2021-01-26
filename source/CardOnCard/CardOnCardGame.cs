using System;
using System.Collections.Generic;
using System.Linq;

namespace CardOnCard
{
    /// <summary>
    /// Game defination class
    /// </summary>
    public class CardOnCardGame
    {
        CardOnCardPlayer _user;
        CardOnCardPlayer _comp;
        Stack<GameStackDetail> _gameCardsPlayed;

        /// <summary>
        /// To start and intantiate different players and random functionality
        /// </summary>
        public void Start()
        {
            Random random = new Random();
            _user = new CardOnCardPlayer(random,PlayerType.user);
            _comp = new CardOnCardPlayer(random,PlayerType.comp);
            _gameCardsPlayed = new Stack<GameStackDetail>();
        }

        public CardOnCardPlayer GetPlayerUser()
        {
            return _user;
        }

        public void Restart()
        {
            _user.Reset();
            _comp.Reset();
            Start();
        }

        public void ShuffleCompDeck()
        {
            _comp.ShuffleMyDeck();
        }

        public Card PlayCompCard()
        {
            return _comp.PlayACard();
        }

        public Card GetCompLastCard()
        {
            return _comp.GetLastCardPlayed();
        }

        public List<GameStackDetail> GetCardsPlayedSoFar()
        {
            List<GameStackDetail> gameCardsPlayed = _gameCardsPlayed.ToList();
            gameCardsPlayed.Reverse();
            return gameCardsPlayed;
        }

        public int GetCompCardsInHandCount()
        {
            return _comp.GetCardsInHandCount();
        }

        /// <summary>
        /// Purpose is to compare the played card with the last card on the game stack
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool ComputeWinner(Card card)
        {
            bool isWinner = false;
            if (_gameCardsPlayed.Count > 0)
            {
                GameStackDetail lastGameStackDetail = _gameCardsPlayed.Peek();
                Card lastCardOnGameStack = lastGameStackDetail.Card;
                if (lastCardOnGameStack.Suite == card.Suite && lastCardOnGameStack.Value == card.Value)
                    isWinner = true;
            }
            return isWinner;
        }

        public Card GetGameLastCard()
        {
            return _gameCardsPlayed.Peek().Card;
        }

        /// <summary>
        /// Card is added with the player details to the game stack
        /// </summary>
        /// <param name="card"></param>
        /// <param name="player"></param>
        public void AddCardToGameStack(Card card,PlayerType player)
        {
            GameStackDetail gameStackDetail = new GameStackDetail
            {
                Card=card,
                Player=player
            };
            _gameCardsPlayed.Push(gameStackDetail);
        }
    }
}
