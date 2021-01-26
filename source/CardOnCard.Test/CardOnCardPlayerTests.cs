using NUnit.Framework;
using System.Collections.Generic;

namespace CardOnCard.Test
{
    public class CardOnCardPlayerTests
    {
        /// <summary>
        /// On shuffle inputdeck should not be same as the outputdeck
        /// </summary>
        [Test]
        public void GivenDeckAssertShuffle()
        {
            //given          
            CardOnCardPlayer player = new CardOnCardPlayer(new System.Random(),PlayerType.user);
            var inputDeckCards = player.MyDeck.Cards;
            var inputDeckArray = inputDeckCards.ToArray();
            //when
            player.ShuffleMyDeck();
            Deck shuffledDeck = player.MyDeck;
            var outputShuffledDeckArray = shuffledDeck.Cards.ToArray();
            //then
            Assert.IsFalse(inputDeckArray == outputShuffledDeckArray);
        }
    }
}
