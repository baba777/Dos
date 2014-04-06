using UnityEngine;
using System;
using System.Collections;

public class Card
{
	public enum UnoColor {Red, Green, Blue, Yellow, Wild};
	public enum UnoValue {Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, DrawTwo, Reverse, Skip, Wild, DrawFour};
	public UnoColor color;
	public UnoValue value;

	public Card(UnoColor color, UnoValue value)
	{
		this.color = color;
		this.value = value;
	}

	public string GetName()
	{
		return Enum.GetName(typeof(Card.UnoColor), color) + " " +
			   Enum.GetName(typeof(Card.UnoValue), value);
	}
	
	public bool Playable()
	{
		var gameMaster = GameObject.Find("Deck").GetComponent<GameMaster>();
		Card topDiscard = gameMaster.PeekDiscard();

		return this.color == topDiscard.color ||
			   this.value == topDiscard.value ||
			   this.color == UnoColor.Wild;
	}
}
