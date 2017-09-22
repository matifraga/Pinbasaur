using UnityEngine;

public class FlipperController : MonoBehaviour {

    float restPosition;
    static float PRESSED_POSITION = 45f;
    static float HIT_POWER = 10000f;
    static float FLIPPER_DAMPER = 100f;
    HingeJoint hinge;
    JointSpring spring;

    void Start () {
        restPosition = 0f;
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
        spring = new JointSpring();
        spring.damper = FLIPPER_DAMPER;
        spring.spring = HIT_POWER;
        hinge.useLimits = true;

    }

    private void FixedUpdate() {


        if (Input.GetKey(KeyCode.LeftArrow)) {
            spring.targetPosition = -PRESSED_POSITION;
        } else {
            if (Input.GetKey(KeyCode.RightArrow)) {
                spring.targetPosition = PRESSED_POSITION;
            } else {
                spring.targetPosition = restPosition;
            }
        }

        hinge.spring = spring;
    }
}
