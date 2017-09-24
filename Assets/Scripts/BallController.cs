using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (transform.position.z < -13) { 
            transform.position = new Vector3(2.9f, 0f, 0.5f);
            rb.velocity = Vector3.zero;
        }
    }
}
