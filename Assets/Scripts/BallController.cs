using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody rb;
    private int lives;
    public int score;
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;

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
                    live3.SetActive(false);
                    break;
                case 1:
                    live2.SetActive(false);
                    break;
                case 0:
                    live1.SetActive(false);
                    break;
            }
            transform.position = new Vector3(2.9f, 0f, 0.5f);
            rb.velocity = Vector3.zero;
        }
    }
}
