using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour
{
	private List<Card> _deck;
	private List<Card> _discarded;
	public static bool reverse;
	public static bool skip;
	public static bool drawTwo;
	public static bool drawFour;

	// Use this for initialization
	void Start()
	{
		//_deck.
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	public Card getTopDiscard()
	{
		return _discarded.FindLast();
	}
}
