using UnityEngine;

public class PanelController : MonoBehaviour {
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject deadPanel;
    private ScoreManager manager;

    private void Awake() {
        manager = ScoreManager.instance;
    }

    void Update() {
        if (manager.IsAlive()) {
            if (Input.GetKeyDown(KeyCode.P)) {
                if (!pausePanel.activeInHierarchy) {
                    PauseGame();
                }
                else {
                    ContinueGame();
                }
            }
        } else {
            Time.timeScale = 0;
            deadPanel.SetActive(true);
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