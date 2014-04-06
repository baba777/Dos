using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	public const int FORCE = 500;
	private List<Card> _hand;
	private GameMaster _gameMaster;

	// Use this for initialization
	void Start() 
	{
		Camera.main.transform.position = transform.position;
	}

	// Update is called once per frame
	void Update() 
	{
		if (Input.GetMouseButtonDown(0))
		{
			var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(mouseRay, out hit, 100))
			{
				var card = hit.transform.gameObject.GetComponent<CardObject>();

				if (card != null)
				{
					card.Flick(mouseRay.direction, hit.point, FORCE);
				}
			}
		}
	}

	public void addToHand(Card card)
	{
		if (_hand == null)
		{
			_hand = new List<Card>();
		}

		_hand.Add(card);
	}

	void OnGUI()
	{
		GUILayout.BeginHorizontal();

		if (_hand != null)
		{
			foreach (var card in _hand)
			{
				if (GUILayout.Button(card.GetName()))
				{

				}
			}
		}
	}
}
