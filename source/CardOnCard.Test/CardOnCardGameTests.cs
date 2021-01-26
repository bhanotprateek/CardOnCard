using NUnit.Framework;

namespace CardOnCard.Test
{
    public class CardOnCardGameTests
    {
        /// <summary>
        /// if the last card on the stack is same as the input card then Assert true
        /// </summary>
        [Test]
        public void GivenCardAssertWinner()
        {
            CardOnCardGame game = new CardOnCardGame();
            //given
            Card inputCard = new Card(Suite.Clubs,"4");
            
            Card lastCardOnStack = new Card(Suite.Clubs, "4");
            game.Start();
            game.AddCardToGameStack(lastCardOnStack, PlayerType.user);
            //when
            bool isWinner=game.ComputeWinner(inputCard);

            //then
            Assert.IsTrue(isWinner);
        }
    }
}
