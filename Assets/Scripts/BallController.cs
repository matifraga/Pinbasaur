using UnityEngine;

public class BallController : MonoBehaviour {

    private ScoreManager manager;
    private Rigidbody rb;
    private int lives;
    public int score;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    void Start() {
        rb = GetComponent<Rigidbody>();
        lives = 3;
        score = 0;
        manager = ScoreManager.instance;
    }

    void FixedUpdate() {
        if (transform.position.z < -13) {
            lives--;
            switch (lives) {
                case 2:
                    life3.SetActive(false);
                    break;
                case 1:
                    life2.SetActive(false);
                    break;
                case 0:
                    life1.SetActive(false);
                    break;
                default:
                    manager.DeadPlayer();
                    break;
            }
            transform.position = new Vector3(2.9f, 0f, 0.5f);
            rb.velocity = Vector3.zero;
        }
    }
}
