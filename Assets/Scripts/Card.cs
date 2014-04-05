using UnityEngine;
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

	public void Action()
	{
		switch(this.value)
		{
			case UnoValue.Skip:
				GameMaster.skip = true;
				break;
			case UnoValue.Reverse:
				GameMaster.reverse = !GameMaster.reverse;
				break;
			case UnoValue.DrawTwo:
				GameMaster.drawTwo = true;
				break;
			case UnoValue.DrawFour:
				GameMaster.drawFour = true;
				break;
		}
	}

	public bool Playable()
	{
		Card topDiscard = GameMaster.getTopDiscard();
		return this.color == topDiscard.color || this.value == topDiscard.value || this.color == UnoColor.Wild;
	}
}
