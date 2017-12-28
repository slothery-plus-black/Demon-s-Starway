using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_Script : MonoBehaviour {
	private float OldAngle = 0f;
	private float NewAngle = 0f;
	private bool Mov = false;
	private int direction = 0;
	//Rigidbody Rigidbody;

	// Use this for initialization
	void Start () {
		//Rigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){

		if (Mov) {
			if(direction==1){
			gameObject.transform.Rotate (0, 1, 0);
			RenderSettings.skybox.SetFloat("_Rotation", RenderSettings.skybox.GetFloat("_Rotation")+1);
			}
			if(direction==-1){
			gameObject.transform.Rotate (0, -1, 0);
			RenderSettings.skybox.SetFloat("_Rotation", RenderSettings.skybox.GetFloat("_Rotation")-1);
			}
		}
		if (isAproximatly(gameObject.transform.rotation.eulerAngles.y, NewAngle, 0.5f)) {
			Mov = false;
			direction = 0;
			OldAngle = NewAngle;
			//Rigidbody.MoveRotation(new Quaternion (0,NewAngle,0,0));
		}
			
	}
		
	private bool isAproximatly (float a, float b, float tolerance){
		if (a > b - tolerance && a < b + tolerance) {
			return true;
		} else {
			return false;
		}
	}

	public void SetBoolMov(float Angle){
		NewAngle=Angle;
		Mov = true;
		CalDirection();
	}

	void CalDirection(){
		int x = (int)(OldAngle-NewAngle);
		if(x<0)x+=360;
		if(x>=180){
			direction=1;
		}else{
			direction =-1;
		}
	}
}
