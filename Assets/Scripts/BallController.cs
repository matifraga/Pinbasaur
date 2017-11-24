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
        if (transform.position.z < -15) {
			LostLife ();
            transform.position = new Vector3(4.5f, 0f, 0f);
            rb.velocity = Vector3.zero;
        }
    }

	private void LostLife() {

		lives--;
		ScoreManager.instance.ResetMultiplier ();
		CardsManager.Instance.ResetCards ();

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
			
	}
}
