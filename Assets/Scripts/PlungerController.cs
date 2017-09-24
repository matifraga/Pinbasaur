using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerController : MonoBehaviour {

    public float power;
    public int deltaPower = 50;
    public float minPower = 0f;
    public float maxPower = 100f;
    public Slider powerSlider;
    List<Rigidbody> ballList;
    bool ballReady;

	void Start () {
        powerSlider.minValue = minPower;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();
	}
	
	void Update () {
        powerSlider.gameObject.SetActive(ballReady);
        powerSlider.value = power;
        if (ballList.Count > 0) {
            ballReady = true;
            if (Input.GetKey(KeyCode.Space)) {
                if (power < maxPower) {
                    power += deltaPower * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space)) {
                foreach(Rigidbody rb in ballList) {
                    rb.AddForce(power * Vector3.forward);
                }
            }
        } else {
            ballReady = false;
            power = minPower;
        }
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = minPower;
        }
    }
}
