using UnityEngine;
using UnityEngine.UI;

public class PlungerController : MonoBehaviour {

    public float power;
    static int DELTA_POWER = 50;
    static float MIN_POWER = 0f;
    static float MAX_POWER = 100f;
    public Slider powerSlider;
    Rigidbody ball;
    bool ballReady;

    void Start() {
        powerSlider.minValue = MIN_POWER;
        powerSlider.maxValue = MAX_POWER;
        ballReady = false;
    }

    void Update() {
        powerSlider.gameObject.SetActive(ballReady);
        powerSlider.value = power;
        if (ballReady) {
            if (Input.GetKey(KeyCode.Space)) {
                if (power < MAX_POWER) {
                    power += DELTA_POWER * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space)) {
                ball.AddForce(power * Vector3.forward);
            }
        }
        else {
            power = MIN_POWER;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            ball = other.gameObject.GetComponent<Rigidbody>();
            ballReady = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            ball = null;
            ballReady = false;
            power = MIN_POWER;
        }
    }
}
