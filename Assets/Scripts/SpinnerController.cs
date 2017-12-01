using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerController : MonoBehaviour {

	private static float ROTATION_TIME = 1f;

	private bool rotate = false;
	private float timeRotating = 0f;

	public int points = 30;

	void OnTriggerEnter(Collider other) {
		if (!rotate) {
			ScoreManager.instance.AddPoints (points);
			rotate = true;
		} else {
			timeRotating = 0f;
		}
	}

	void FixedUpdate() {
		if (rotate) {
			transform.Rotate (Vector3.right * 20);
			timeRotating += Time.deltaTime;

			if (timeRotating > ROTATION_TIME) {
				ResetRotation ();
			}
		}
	}

	private void ResetRotation() {
		rotate = false;
		timeRotating = 0f;
		Vector3 temp = transform.rotation.eulerAngles;
		temp.x = 0f;
		transform.rotation = Quaternion.Euler(temp);
	}
}
