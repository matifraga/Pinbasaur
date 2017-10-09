using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {
    public GameObject scoreManager;

    private void Awake() {
        if(ScoreManager.instance == null) {
            Instantiate(scoreManager);
        }
    }
}
