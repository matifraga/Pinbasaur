using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

	public enum SwitchState {Off, On}; 

	public FloorLight indicator; 

	private SwitchState state = SwitchState.Off;

	private void Awake() {
		LightSwitchManager.Instance.RegisterSwitch (this);
	}

	private void OnTriggerEnter(Collider other) {
		if (state == SwitchState.Off) {
			TurnOnSwitch ();
			LightSwitchManager.Instance.SwitchDidSwitchState (this, state);
		}
	}

	public void ResetSwitch() {
		TurnOffSwitch ();
	}

	private void TurnOnSwitch() {
		state = SwitchState.On;
		indicator.turnOn ();
	}

	private void TurnOffSwitch() {
		state = SwitchState.Off;
		indicator.turnOff ();
	}

	void OnDestroy() {
		LightSwitchManager.Instance.DeRegisterSwitch (this);
	}
}
