using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchManager {

	private static LightSwitchManager _instance;

	private List<LightSwitch> switches;

	private int onSwitches = 0;

	private int bumperMultiplier = 1;

	public static LightSwitchManager Instance { 
		get { 
			if (_instance == null) {
				_instance = new LightSwitchManager();
				_instance.switches = new List<LightSwitch> ();
				_instance.onSwitches = 0;
			}
			return _instance;
		} 
	}

	public void RegisterSwitch(LightSwitch toggle) {
		switches.Add (toggle);
	}

	public void DeRegisterSwitch(LightSwitch toggle) {
		switches.Remove (toggle);
		onSwitches = 0;
	}

	public void SwitchDidSwitchState(LightSwitch toggle, LightSwitch.SwitchState state) {
		if (state == LightSwitch.SwitchState.On && switches.Contains (toggle)) {
			onSwitches += 1;
			if (onSwitches == switches.Count) {
				IncrementBumperMultiplier ();
				ResetSwitches ();
				onSwitches = 0;
			}
		}
	}

	public void ResetSwitches() {
		onSwitches = 0;
		foreach (LightSwitch t in switches) {
			t.ResetSwitch ();
		}
	}

	public void IncrementBumperMultiplier() {
		bumperMultiplier += 1;
		setToadsMultiplier (bumperMultiplier);
		Material toadMaterial = Resources.Load("Materials/ToadMaterial", typeof(Material)) as Material;
		toadMaterial.SetColor("_Color", colorForMultiplier(bumperMultiplier));
		ResetSwitches ();
	}

	public void ResetBumperMultiplier() {
		bumperMultiplier = 1;
		setToadsMultiplier (bumperMultiplier);
		Material toadMaterial = Resources.Load("Materials/ToadMaterial", typeof(Material)) as Material;
		toadMaterial.SetColor("_Color", colorForMultiplier(bumperMultiplier));
		ResetSwitches ();
	}

	private void setToadsMultiplier(int multiplier) {
		GameObject[] gm = GameObject.FindGameObjectsWithTag("Toad");
		foreach(GameObject g in gm) {
			g.GetComponent<BumperController>().multiplier = multiplier;
		}
	}

	private Color colorForMultiplier(int multiplier) {
		switch (multiplier) {
		case 1:
			{
				return Color.red;
			}
		case 2: 
			{
				return Color.blue;
			}
		case 3:
			{
				return Color.green;
			}
		default:
			{
				return Color.yellow;
			}
		}
	}
}

