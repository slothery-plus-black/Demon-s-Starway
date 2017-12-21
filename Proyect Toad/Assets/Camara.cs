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

    bool pulsado = false;

    Vector3 posPulsado = Vector3.zero;

    void Update () {
        

        if (Input.touchCount > 0){
            HandleTouch(Input.touches[0].phase);
        }else{
            if (Input.GetMouseButtonDown(0)){
                HandleTouch(TouchPhase.Began);
            }

            if (Input.GetMouseButtonUp(0)){
                HandleTouch(TouchPhase.Ended);
            }

            if (Input.GetMouseButton(0)){
                HandleTouch(TouchPhase.Moved);
            }
        }

        /*if (Input.touchCount > 0){
            switch (Input.touches[0].phase){
                case TouchPhase.Moved:
                    yaw = speedH * Input.touches[0].deltaPosition.x;
                    pitch = -(speedV * Input.touches[0].deltaPosition.y);

                    transform.eulerAngles = new Vector3(transform.eulerAngles.x+pitch, transform.eulerAngles.y+yaw, 0);
                    break;

            }
        }else{
            /*yaw = speedH * Input.GetAxis("Mouse X");
            pitch = -(speedV * Input.GetAxis("Mouse Y"));

            transform.eulerAngles = new Vector3(transform.eulerAngles.x+pitch, transform.eulerAngles.y+yaw, transform.eulerAngles.z);*/

            Transform c = transform;
            c.Rotate(0, Input.GetAxis("Mouse X")* speedH, 0);
            c.Rotate(-Input.GetAxis("Mouse Y")* speedV, 0, 0);
            //c.Rotate(0, 0, -Input.GetAxis("QandE")*90 * Time.deltaTime);
            /*if (Input.GetMouseButtonDown(0))
                Cursor.lockState = CursorLockMode.Locked;*/
        }
    //}
    void HandleTouch(TouchPhase phase){
        switch (phase){
            case TouchPhase.Began:
                //posPulsado = 
            break;

            case TouchPhase.Ended:
            case TouchPhase.Canceled:

            break;

            case TouchPhase.Moved:
            case TouchPhase.Stationary:

            break;
        }
    }
}
