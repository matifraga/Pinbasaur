using UnityEngine;

public class BallController : MonoBehaviour {

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
            }
            transform.position = new Vector3(2.9f, 0f, 0.5f);
            rb.velocity = Vector3.zero;
        }
    }
}
