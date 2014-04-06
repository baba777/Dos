using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameMaster : MonoBehaviour
{
	public GameObject PlayerObject;

	public List<Card> deck
	{
		get; private set;
	}

	public List<Card> discarded
	{
		get; private set;
	}

	private bool _clockwise;

	public List<Player> players;

	// Use this for initialization
	void Start()
	{
		deck = new List<Card>();
		discarded = new List<Card>();

		AddPlayer();
		AddPlayer();

		fillDeck();
		shuffle();
		distribute();
	}

	/// <summary>
	/// Adds cards to the deck
	/// </summary>
	private void fillDeck()
	{
		// Colors Red, Green, Blue, and Yellow
		var colors = ((Card.UnoColor[]) Enum.GetValues(typeof(Card.UnoColor))).Take(4);
		// Numbers 1-9 and symbols
		var numbers = ((Card.UnoValue[]) Enum.GetValues(typeof(Card.UnoValue))).Skip(1).Take(12);
		
		// Create 0-9 and symbol cards for each color
		foreach (var color in colors)
		{
			deck.Add(new Card(color, Card.UnoValue.Zero));
			
			foreach (var number in numbers)
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

	private void distribute()
	{
		for(int i = 0; i < 7; i++)
		{
			foreach(var player in players)
			{
				player.addToHand(PopDeck());
			}
		}
	}

	public void AddPlayer()
	{
		var playerObject = (GameObject)GameObject.Instantiate(PlayerObject);
		var player = playerObject.GetComponent<Player>();

		players.Add(player);
	}

	public void PlayCard(Card card)
	{
		switch(card.value)
		{
		case Card.UnoValue.Skip:
			//GameMaster.skip = true;
			break;
		case Card.UnoValue.Reverse:
			//GameMaster.reverse = !GameMaster.reverse;
			break;
		case Card.UnoValue.DrawTwo:
			//GameMaster.drawTwo = true;
			break;
		case Card.UnoValue.DrawFour:
			//GameMaster.drawFour = true;
			break;
		}
	}
	
	public Card PopDeck()
	{
		var temp = deck.Last();
		deck.RemoveAt(deck.Count - 1);

		return temp;
	}

	public Card PeekDiscard()
	{
		return discarded.Last();
	}
}
