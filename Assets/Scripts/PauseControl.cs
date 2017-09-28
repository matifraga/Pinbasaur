using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour {
    [SerializeField] private GameObject pausePanel;

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (!pausePanel.activeInHierarchy) {
                PauseGame();
            } else {
                ContinueGame();
            }
        }
    }
    private void PauseGame() {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    private void ContinueGame() {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}