using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize new deck var
            var deck = new Deck();

            //print deck
            //deck.Discard();
            deck.PrintDeck();

            //shuffle deck
            deck.Shuffle();

            Console.WriteLine("\ndeck has been shuffled\n");

            //print deck again
            //deck.Discard();
            deck.PrintDeck();

            //create var to pick 5 cards
            var draw5 = deck.Deal(5);

            Console.ReadKey();            
        }
    }
    
    // When a new deck is created, you’ll create a card of each rank for each suit and add them to the deck of cards, 
    //      which in this case will be a List of Card objects.
    //
    // A deck can perform the following actions:
	//     void Shuffle() -- Merges the discarded pile with the deck and shuffles the cards
	//     List<card> Deal(int numberOfCards) - returns a number of cards from the top of the deck
	//     void Discard(Card card) / void Discard(List<Card> cards) - returns a card from a player to the 
	//         discard pile	
    // 
    // A deck knows the following information about itself:
	//     int CardsRemaining -- number of cards left in the deck
	//     List<Card> DeckOfCards -- card waiting to be dealt
    //     List<Card> DiscardedCards -- cards that have been played

    class Deck
    {
        //DEFINE PROPERTIES
        public List<Card> DeckOfCards { get; set; }
        public List<Card> DiscardedCards { get; set; }

        //SET CONSTRUCTOR
        public Deck ()
        {
            //initialize CardsRemaining
            //int CardsRemaining = 0;
            //initialize new lists of cards
            this.DeckOfCards = new List<Card>();
            this.DiscardedCards = new List<Card>();

            //count through suits
            for (int s = 0; s <= 3; s++)
            {
                //count through ranks
                for (int r = 0; r <= 12; r++)
                {
                    //add new card to card list
                    DeckOfCards.Add(new Card((Rank)r, (Suit)s));
                }
            }
        }

        //FUNCTIONS
        public void Shuffle()
        { 
            //add back in any dealt card to the deck
            this.DeckOfCards.AddRange(DiscardedCards);

            //clear DiscardedCards
            this.DiscardedCards.Clear();

            //initialize new list of shuffled cards
            List<Card> shuffled = new List<Card>();

            //RANDOM NUMBER GENERATOR
            Random rng = new Random();

            while (this.DeckOfCards.Count > 0)
            {
                //choose a random card from the unshuffled deck
                Card card = this.DeckOfCards[rng.Next(0, this.DeckOfCards.Count)];
                //add the card to the shuffled deck
                shuffled.Add(card);
                //remove the card from the unshuffled deck
                this.DeckOfCards.Remove(card);
            }
            //set the cards property equal to the shuffled deck
            this.DeckOfCards = shuffled;
        }

        public List<Card> Deal(int numberOfCards)
        {
            List<Card> cardsToDeal = new List<Card>();
            for (int i = 0; i < numberOfCards; i++)
            {
                Card drawn = this.DeckOfCards.Last();
                this.DiscardedCards.Add(drawn);
                this.DeckOfCards.Remove(drawn);
            }
            return cardsToDeal;
        }

        internal void Discard(List<Card> hand)
        {
            DiscardedCards.AddRange(hand);
        }

        public void PrintDeck()
        {
            Console.WriteLine(string.Join("\n", this.DeckOfCards.Select(x => x.GetCardString())));
        }
    }
    
    // What makes a card?
	//     A card is comprised of it’s suit and its rank.  Both of which are enumerations.
    //     These enumerations should be "Suit" and "Rank"

    public enum Suit
    {
        Spades,
        Clubs,
        Diamonds,
        Hearts
    }
    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    class Card
        {

        //DEFINE PROPERTIES
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        //SET CONSTRUCTOR
        public Card(Rank r, Suit s)
        {
            this.Rank = r;
            this.Suit = s;
        }

        //return output string
        public string GetCardString()
        {
            return this.Rank + " of " + this.Suit;
        }

    }
}