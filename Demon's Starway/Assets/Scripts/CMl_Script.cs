using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMl_Script : MonoBehaviour {
	private float OldAngle = -45f;
	private bool Mov = false;
	GameObject Bicho;

	// Use this for initialization
	void Start () {
		Bicho = GameObject.Find("Bicho");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){

		if (Mov) {
			if(OldAngle==-45){
			gameObject.transform.Rotate (0, 0, 1.5f);
			Bicho.transform.Translate(0,0,0.5f);
			}
			if(OldAngle==0){
			gameObject.transform.Rotate (0, 0, -1.5f);
			Bicho.transform.Translate(0,0,-0.5f);
			}
		}
		if(OldAngle==-45){
			if (isAproximatly(gameObject.transform.rotation.eulerAngles.z, 0, 0.5f)) {
				Mov = false;
				OldAngle = 0;
			}
		}else if (OldAngle==0){
			if (isAproximatly(gameObject.transform.rotation.eulerAngles.z, 315, 0.5f)) {
				Mov = false;
				OldAngle = -45;
			}
		}
	
			
	}
		
	private bool isAproximatly (float a, float b, float tolerance){
		if (a > b - tolerance && a < b + tolerance) {
			return true;
		} else {
			return false;
		}
	}

	public void SetBoolMov(){
		Mov = true;
	}

	public bool GetLevel(){
		if(OldAngle==-45){
			return false;
		}else{
			return true;
		}
	}
}