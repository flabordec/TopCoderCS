using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BridgeSort
{
	class Card : IComparable<Card>
	{
		public static Dictionary<char, int> Suits = new Dictionary<char, int>() {
			{'C', 0}, {'D', 1}, {'H', 2}, {'S', 3}
		};
		public static Dictionary<char, int> Values = new Dictionary<char, int>() {
			{'2', 0}, {'3', 1}, {'4', 2}, {'5', 3},
			{'6', 4}, {'7', 5}, {'8', 6}, {'9', 7},
			{'T', 8}, {'J', 9}, {'Q', 10}, {'K', 11}, 
			{'A', 12}
		};

		public string CardString { get; set; }
		public char Suit { get; set; }
		public char Value { get; set; }

		public Card(string card)
		{
			this.CardString = card;
			this.Suit = card[0];
			this.Value = card[1];
		}

		public int CompareTo(Card other)
		{
			try
			{
				if (Suits[this.Suit] == Suits[other.Suit])
				{
					return Values[this.Value] - Values[other.Value];
				}
				else
				{
					return Suits[this.Suit] - Suits[other.Suit];
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return 0;
			}
		}
	}

	public string sortedHand(string hand)
	{
		List<Card> cards = new List<Card>();
		for (int i = 0; i < hand.Length; i += 2)
		{
			Card card = new Card(hand.Substring(i, 2));
			cards.Add(card);
		}

		var cardsOrdered = from card in cards
						   orderby card
						   select card;
		StringBuilder builder = new StringBuilder();
		foreach (var card in cardsOrdered)
		{
			builder.Append(card.CardString);
		}
		return builder.ToString();
	}
}
