using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance = null;
    private bool isAlive;
    private int score = 0;

    private void Awake() {
        isAlive = true;
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
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

    public void DeadPlayer() {
        isAlive = false;
    }

    public bool IsAlive() {
        return isAlive;
    }

}
