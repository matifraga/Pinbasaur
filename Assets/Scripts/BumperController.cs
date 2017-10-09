using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour {

    public float bumperForce;
    public int points;

    private void OnCollisionEnter(Collision collision) {
        ScoreManager.instance.AddPoints(points);
        foreach (ContactPoint cp in collision.contacts) {
            cp.otherCollider.GetComponent<Rigidbody>().AddForce(-1 * cp.normal * bumperForce, ForceMode.Impulse);
        }
    }
}
