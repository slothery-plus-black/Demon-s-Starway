using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulletePos : MonoBehaviour {
	private float OldAngle = 0f;
	private float NewAngleUp = 0f;
	private float NewAngleDown = 0f;
	private bool Up = false;
	private bool Down = false;
	Rigidbody2D roulleteRb;
	GameObject Bicho;
	Quaternion FirstPosBicho;

	// Use this for initialization
	void Start () {
		roulleteRb = gameObject.GetComponent<Rigidbody2D> ();
		Bicho = GameObject.Find("Bicho");
		FirstPosBicho = Bicho.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void FixedUpdate(){
		if (OldAngle == 0) {
			NewAngleUp = 30;
			NewAngleDown = 330;
		} else if (OldAngle == 330) {
			NewAngleUp = 0;
			NewAngleDown = 300;
		} else {
			NewAngleUp = OldAngle+30;
			NewAngleDown = OldAngle-30;
		}

		if (Up) {
			gameObject.transform.Rotate (0, 0, 2);
			Bicho.transform.Rotate(2f,0,0);
		}

		if (Down) {
			gameObject.transform.Rotate (0, 0, -2);
			Bicho.transform.Rotate(-2f,0,0);
		}
		if (isAproximatly(gameObject.transform.rotation.eulerAngles.z, NewAngleUp, 0.5f)) {
			Up = false;
			OldAngle = NewAngleUp;
			roulleteRb.MoveRotation (OldAngle);
			Bicho.transform.rotation = FirstPosBicho;
		} else if (isAproximatly(gameObject.transform.rotation.eulerAngles.z, NewAngleDown, 0.5f)) {
			Down = false;
			OldAngle = NewAngleDown;
			roulleteRb.MoveRotation (OldAngle);
			Bicho.transform.rotation = FirstPosBicho;
		}
			
	}
		
	private bool isAproximatly (float a, float b, float tolerance){
		if (a > b - tolerance && a < b + tolerance) {
			return true;
		} else {
			return false;
		}
	}

	public void SetBoolUp(){
		if(!Down)
		Up = true;
	}
	public void SetBoolDown(){
		if (!Up)
		Down = true;
	}

	public float GetAnlge(){
		return OldAngle;
	}
}
