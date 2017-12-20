using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

	void Start () {

	}
	
	public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update () {
        if (Input.touchCount > 0){
            switch (Input.touches[0].phase){
                case TouchPhase.Moved:
                    yaw = speedH * Input.touches[0].deltaPosition.x;
                    pitch = -(speedV * Input.touches[0].deltaPosition.y);

                    transform.eulerAngles = new Vector3(transform.eulerAngles.x+pitch, transform.eulerAngles.y+yaw, 0);
                    break;

            }
        }else{
            yaw = speedH * Input.GetAxis("Mouse X");
            pitch = -(speedV * Input.GetAxis("Mouse Y"));

            transform.eulerAngles = new Vector3(transform.eulerAngles.x+pitch, transform.eulerAngles.y+yaw, transform.eulerAngles.z);
        }
    }
}
