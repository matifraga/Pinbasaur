using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance = null;

    private bool isAlive;
	private int score = 0;
	private int multiplier = 1;

	private Multiplier x2;
	private Multiplier x3;
	private Multiplier x4;

    private void Awake() {
        isAlive = true;
        
		if (instance == null) {
			instance = this;
		}

		FindMultipliers ();
        ResetScore ();
    }

    public void AddPoints(int pointsToAdd) {
		score += (pointsToAdd * multiplier);
    }

    public int GetScore() {
        return score;
    }

    public void SetScore(int newScore) {
        score = newScore;
    }

    public void ResetScore() {
        score = 0;
    }

    public void DeadPlayer() {
        isAlive = false;
    }

    public bool IsAlive() {
        return isAlive;
    }

	public void IncrementMultiplier() {
		multiplier += 1;
		HandleMultiplierLights ();
	}

	public void ResetMultiplier() {
		multiplier = 1;
		HandleMultiplierLights ();
	}

	private void FindMultipliers() {
		x2 = GameObject.Find("2X").GetComponent<Multiplier>();
		x3 = GameObject.Find("3X").GetComponent<Multiplier>();
		x4 = GameObject.Find("4X").GetComponent<Multiplier>();
	}

	private void HandleMultiplierLights() {
		switch (multiplier) {
		case 1: 
			{
				x2.turnOff ();
				x3.turnOff ();
				x4.turnOff ();
				break;
			}
		case 2: 
			{
				x2.turnOn ();
				x3.turnOff ();
				x4.turnOff ();
				break;
			}
		case 3:
			{
				x2.turnOff ();
				x3.turnOn ();
				x4.turnOff ();
				break;	
			}
		case 4:
			{
				x2.turnOff ();
				x3.turnOff ();
				x4.turnOn ();
				break;
			}
		default: 
			{
				x2.turnOn ();
				x3.turnOn ();
				x4.turnOn ();
				break;
			}

		}
	}
}
