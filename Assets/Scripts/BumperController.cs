using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour {

    public float bumperForce;
    public int points;
	public int multiplier = 1;

    private void OnCollisionEnter(Collision collision) {
		ScoreManager.instance.AddPoints(points * multiplier);
		if (bumperForce != 0) {
			foreach (ContactPoint cp in collision.contacts) {
				cp.otherCollider.GetComponent<Rigidbody> ().AddForce (-1 * cp.normal * bumperForce, ForceMode.Impulse);
			}
		}
    }
}
