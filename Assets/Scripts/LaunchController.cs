using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour {

	static float LAUNCH_WAIT_TIME = 2.0f;
	static float BLOCK_TIME = 0.5f;

	private float timePassed = 0;
	private bool waitForLaunch = false;

	private bool blocked = false;
	private float timeBlocked = 0;

	public int awardedPoints = 1000;

	public Rigidbody ball;

	private void OnCollisionEnter(Collision collision) {
		waitForLaunch = true;
	}

	private void Update() {
		if (waitForLaunch && !blocked) {
			timePassed += Time.deltaTime;

			if (timePassed > LAUNCH_WAIT_TIME) {
				blocked = true;
				Launch ();
			}
		}

		if (blocked) {
			timeBlocked += Time.deltaTime;
			if (timeBlocked > BLOCK_TIME) {
				Reset ();
			}
		}
	}

	public void Launch() {
		ScoreManager.instance.AddPoints (awardedPoints);
		float location = Random.Range (3.5f, 4.5f);
		ball.AddForce (location, 0, location, ForceMode.Impulse);
	}

	public void Reset() {
		timePassed = 0;
		timeBlocked = 0;
		waitForLaunch = false;
		blocked = false;
	}

}
