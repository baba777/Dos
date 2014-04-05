using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class GameMaster : MonoBehaviour
{
	public static bool reverse;
	public static bool skip;
	public static bool drawTwo;
	public static bool drawFour;

	public List<Card> deck
	{
		get; private set;
	}

	public List<Card> discarded
	{
		get; private set;
	}

	// Use this for initialization
	void Start()
	{
		deck = new List<Card>();
		discarded = new List<Card>();

		fillDeck();
		shuffle();

		// See if it's working
		foreach (var card in deck)
		{
			var name = Enum.GetName(typeof(Card.UnoColor), card.color) + " " +
					   Enum.GetName(typeof(Card.UnoValue), card.value);
			print(name);
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	/// <summary>
	/// Adds cards to the deck
	/// </summary>
	private void fillDeck()
	{
		var colors = ((Card.UnoColor[]) Enum.GetValues(typeof(Card.UnoColor))).Take(4);
		var numbers = (Card.UnoValue[]) Enum.GetValues(typeof(Card.UnoValue));
		
		var doubledCardNumbers = numbers.Skip(1).Take(12);
		
		// Create 0-9 and symbol cards for each color
		foreach (var color in colors)
		{
			deck.Add(new Card(color, Card.UnoValue.Zero));
			
			foreach (var number in doubledCardNumbers)
			{
				deck.Add(new Card(color, number));
				deck.Add(new Card(color, number));
			}
		}
		
		// Create Wild cards
		for (var i = 0; i < 4; i++)
		{
			deck.Add(new Card(Card.UnoColor.Wild, Card.UnoValue.Wild));
			deck.Add(new Card(Card.UnoColor.Wild, Card.UnoValue.DrawFour));
		}
	}

	/// <summary>
	/// Does the Fisher-Yates shuffle on the deck
	/// </summary>
	private void shuffle()
	{
		for (var i = 0; i < deck.Count; i++)
		{
			int j = UnityEngine.Random.Range(i, deck.Count);

			// Swap i and j
			Card temp = deck[i];
			deck[i] = deck[j];
			deck[j] = temp;
		}
	}

	public Card getTopDiscard()
	{
		return discarded.Last();
	}
}
