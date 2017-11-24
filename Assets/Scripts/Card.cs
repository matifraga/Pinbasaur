using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	public enum CardState {Up, Down}; 

	private CardState state = CardState.Up;

	private void Awake() {
		CardsManager.Instance.RegisterCard (this);
	}

	private void OnCollisionEnter(Collision collision) {
		if (state == CardState.Up) {
			LowerCard ();
		}
	}

	public void ResetCard() {
		RaiseCard ();
	}

	private void LowerCard() {
		state = CardState.Down;
		Vector3 currentPosition = this.transform.position;
		currentPosition.y = -0.15f;
		this.transform.position = currentPosition;
		CardsManager.Instance.CardDidSwitchState (this, state);
	}

	private void RaiseCard() {
		state = CardState.Up;
		Vector3 currentPosition = this.transform.position;
		currentPosition.y = 0.25f;
		this.transform.position = currentPosition;
		CardsManager.Instance.CardDidSwitchState (this, state);
	}

	void OnDestroy() {
		CardsManager.Instance.DeRegisterCard (this);
	}
		
}
