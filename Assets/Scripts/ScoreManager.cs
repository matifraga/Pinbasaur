using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance = null;
    private int score = 0;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        ResetScore();
    }

    public void AddPoints(int pointsToAdd) {
        score += pointsToAdd;
    }

    public void TakePoints(int pointsToTake) {
        if(score >= pointsToTake) {
            score -= pointsToTake;
        } else {
            score = 0;
        }
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
}
