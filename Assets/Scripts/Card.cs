using UnityEngine;
using System.Collections;

public class Card
{
	public enum UnoColor {Red, Green, Blue, Yellow, Wild};
	public enum UnoValue {Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, DrawTwo, Reverse, Skip, DrawFour};
	public UnoColor CardColor;
	public UnoValue CardValue;

	public Card(UnoColor color, UnoValue value)
	{
		CardColor = color;
		CardValue = value;
	}

	public void Action()
	{
		// pass
	}

	public bool Playable()
	{
		return false;
	}
}
