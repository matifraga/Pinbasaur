using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager {

	private static CardsManager _instance;

	private List<Card> cards;

	private int loweredCards;

	public static CardsManager Instance { 
		get { 
			if (_instance == null) {
				_instance = new CardsManager();
				_instance.cards = new List<Card> ();
				_instance.loweredCards = 0;
			}
			return _instance;
		} 
	}

	public void RegisterCard(Card card) {
		cards.Add (card);
	}

	public void DeRegisterCard(Card card) {
		cards.Remove (card);
		loweredCards = 0;
	}

	public void CardDidSwitchState(Card card, Card.CardState state) {
		if (state == Card.CardState.Down && cards.Contains (card)) {
			loweredCards += 1;

			if (loweredCards == cards.Count) {
				ScoreManager.instance.IncrementMultiplier ();
				ResetCards ();
				loweredCards = 0;
			}
		}
	}

	public void ResetCards() {
		loweredCards = 0;
		foreach (Card c in cards) {
			c.ResetCard ();
		}
	}
}
