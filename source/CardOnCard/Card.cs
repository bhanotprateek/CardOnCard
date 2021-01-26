namespace CardOnCard
{
    /// <summary>
    /// Types of suites in a deck
    /// </summary>
    public enum Suite
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    /// <summary>
    /// Enity class of a Card
    /// </summary>
    public class Card
    {
        public Suite Suite { get; set; }
        public string Value { get; set; }
        public Card(Suite s, string v)
        {
            Suite = s;
            Value = v;
        }
    }
}
