using UnityEngine;
using System.Collections;

public class CardObject : MonoBehaviour 
{
	public Card card;

	// Use this for initialization
	void Start()
	{
		this.rigidbody.Sleep();
	}

	// Update is called once per frame
	void Update()
	{
	}

	public void ChangeCard(Card newCard)
	{
		switch (newCard.color)
		{
		case Card.UnoColor.Red:
			renderer.material.color = Color.red;
			break;
		case Card.UnoColor.Green:
			renderer.material.color = Color.green;
			break;
		case Card.UnoColor.Blue:
			renderer.material.color = Color.blue;
			break;
		case Card.UnoColor.Yellow:
			renderer.material.color = Color.yellow;
			break;
		}
	}

	public void Flick(Vector3 direction, Vector3 point, int power)
	{
		this.rigidbody.WakeUp();
		this.rigidbody.AddForceAtPosition(direction * power, point);
	}
}
