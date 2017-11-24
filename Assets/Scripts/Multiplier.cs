using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour {

	public Sprite offSprite;
	public Sprite onSprite;

	public void turnOn() {
		GetComponent<SpriteRenderer> ().sprite = onSprite;	
	}

	public void turnOff() {
		GetComponent<SpriteRenderer> ().sprite = offSprite;	
	}
}
