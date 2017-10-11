﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour {
    private Text scoreText;

    void Start() {
        scoreText = GetComponent<Text>();
    }

    void Update () {
        scoreText.text = ScoreManager.instance.GetScore().ToString();
    }
}
