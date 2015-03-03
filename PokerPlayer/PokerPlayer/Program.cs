using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
    class PokerPlayer
    {
        //define properties
        private HandType _playerHand;
        public HandType PlayerHand
        {
            get { return _playerHand; }
            set { _playerHand = value; }
        }

        public List<Card> Cards { get; set; }
        public void DrawHand(List<Card> cards)
        {
            this.Cards = cards;
        }
        // Enum of different hand types
        public enum HandType
        {
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }
        // Rank of hand that player holds
        public HandType HandRank
        {
            get
            {
                if (this.HasRoyalFlush()) { return HandType.RoyalFlush; }
                if (this.HasFourOfAKind()) { return HandType.FourOfAKind; }
                if (this.HasStraightFlush()) { return HandType.StraightFlush; }
                if (this.HasFullHouse()) { return HandType.FullHouse; }
                if (this.HasFlush()) { return HandType.Flush; }
                if (this.HasStraight()) { return HandType.Straight; }
                if (this.HasThreeOfAKind()) { return HandType.ThreeOfAKind; }
                if (this.HasTwoPair()) { return HandType.TwoPair; }
                if (this.HasPair()) { return HandType.OnePair; }
                return HandType.HighCard;
            }
        }
        // Constructor that isn't used
        public PokerPlayer()
        {
        }

        public bool HasPair()
        {
            int CheckPair = this.Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count();
            if (CheckPair == 1)
            {
                return true;
            }
            return false;
        }
        public bool HasTwoPair()
        {
            int CheckPair = this.Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count();
            if (CheckPair == 2)
            {
                return true;
            }
            return false;
        }
        public bool HasThreeOfAKind()
        {
            int CheckThreeOfAKind = this.Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 3).Count();
            if (CheckThreeOfAKind == 1)
            {
                return true;
            }
            return false;
        }
        public bool HasStraight()
        {
            List<Card> StraightCheckerList = this.Cards.OrderBy(x => x.Rank).ToList();
            int cardCount = 0;
            for (int i = 0; i < StraightCheckerList.Count - 1; i++)
            {
                if (StraightCheckerList[i + 1].Rank - StraightCheckerList[i].Rank == 1)
                {
                    cardCount++;
                }
            }
            if (cardCount == this.Cards.Count - 1)
            {
                return true;
            }
            return false;
        }
        public bool HasFlush()
        {
            if (Cards.GroupBy(x => x.Suit).Count() == 1)
            {
                return true;
            }
            return false;
        }
        public bool HasFullHouse()
        {
            if ((Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 3).Count() == 1) && (Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 1))
            {
                return true;
            }
            return false;
        }
        public bool HasFourOfAKind()
        {
            return Cards.GroupBy(x => x.Rank).Any(x => x.Count() == 4) && Cards.GroupBy(x => x.Suit).Distinct().Count() >= 4;
        }
        public bool HasStraightFlush()
        {
            if (this.HasFlush() && this.HasStraight())
            {
                return true;
            }
            return false;
        }
        public bool HasRoyalFlush()
        {
            if (this.HasStraightFlush() && Cards.OrderBy(x => x.Rank).Last().Rank == Rank.Ace)
            {
                return true;
            }
            return false;
        }
    }
    //Guides to pasting your Deck and Card class

    //  *****Deck Class Start*****

    class Deck
    {
        //DEFINE PROPERTIES
        public List<Card> DeckOfCards { get; set; }
        public List<Card> DiscardedCards { get; set; }

        //SET CONSTRUCTOR
        public Deck()
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
                    DeckOfCards.Add(new Card(r, s));
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

        //print function 
        public void PrintDeck()
        {
            Console.WriteLine(string.Join("\n", this.DeckOfCards.Select(x => x.GetCardString())));
        }
    }

    //  *****Deck Class End*******

    //  *****Card Class Start*****

    class Card
    {

        //DEFINE PROPERTIES
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        //SET CONSTRUCTOR
        public Card(int r, int s)
        {
            this.Rank = (Rank)r;
            this.Suit = (Suit)s;
        }

        //return output string
        public string GetCardString()
        {
            return this.Rank + " of " + this.Suit;
        }

    }

    //  *****Card Class End*******

    // ****Enummerations Start*****

    public enum Suit
    {
        Spade,
        Club,
        Diamond,
        Heart
    }
    public enum Rank
    {
        Two = 2,
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
}