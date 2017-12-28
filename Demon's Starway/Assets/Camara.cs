using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {
    //public GameObject jugador;
    //public GameObject planeta;
	public float speedH = 2.0f;
    public float speedV = 2.0f;

    /*public float fuerza = 0.1f;
    float fuerzaTiempo = 0.1f;
    Rigidbody r;
    Camera cam;*/

    //private float yaw = 0.0f;
    //private float pitch = 0.0f;

    //bool pulsado = false;

    //Vector3 posPulsado = Vector3.zero;

    void Start () {
        //r = jugador.GetComponent<Rigidbody> ();
		//cam = Camera.main;
	}

    void Update () {
        /*transform.position = jugador.transform.position;
        fuerzaTiempo = fuerza * Time.deltaTime;*/
        

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
            
            //c.Rotate(0, 0, -Input.GetAxis("QandE")*90 * Time.deltaTime);
            /*if (Input.GetMouseButtonDown(0))
                Cursor.lockState = CursorLockMode.Locked;*/

                //transform.LookAt(-jugador.transform.position);
    }

    void FixedUpdate () {
		//gameObject.transform.LookAt (planeta.transform.position);

        if (Input.touchCount > 0){
            /*if (Input.touchCount > 1){
                HandleTouch(Input.touches[0].phase);
            }else{
                float der = Input.touches[0].deltaPosition.x;
                float arr = Input.touches[0].deltaPosition.y;
                //Vector3 f = new Vector3(Input.touches[0].deltaPosition.x,0,Input.touches[0].deltaPosition.y);
                Vector3 f1 = cam.transform.forward * arr;
                Vector3 f2 = cam.transform.right * der;
                Vector3 f3 = f1 +f2;
                //Vector3 r = new Vector3(Input.touches[0].deltaPosition.x,0,0);
                //f = f*cam.transform.forward;
                //Vector3.Dot(f,cam.transform.forward);
                r.AddForce (f3.normalized * fuerzaTiempo, ForceMode.Impulse);
            }*/
            
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

        //transform.LookAt(-jugador.transform.position);
		/*if (Input.GetKey (KeyCode.A)) {
			r.AddForce (-cam.transform.right.normalized * fuerzaTiempo, ForceMode.Impulse);
		}

		if (Input.GetKey (KeyCode.D)) {
			r.AddForce (cam.transform.right.normalized * fuerzaTiempo, ForceMode.Impulse);
		}

		if (Input.GetKey (KeyCode.W)) {
			r.AddForce (cam.transform.forward.normalized * fuerzaTiempo, ForceMode.Impulse);
		}

		if (Input.GetKey (KeyCode.S)) {
			r.AddForce (-cam.transform.forward.normalized * fuerzaTiempo, ForceMode.Impulse);
		}*/
	}
    
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
                //Debug.Log(Input.GetAxis("Mouse X"));
                //transform.Rotate(Vector3.up,Input.GetAxis("Mouse X"));
                //transform.Rotate(Vector3.right,Input.GetAxis("Mouse Y"));
                
                MoverCamara();
                //transform.Rotate(0, Input.GetAxis("Mouse X") * speedH, 0);
                //transform.Rotate(-Input.GetAxis("Mouse Y") * speedV, 0, 0);
                //transform.rotation = new Quaternion(0,0,transform.rotation.z,transform.rotation.w);
            break;
        }
    }

    void MoverCamara(){
        float rotX = Input.GetAxis("Mouse X") * speedH;
        float rotY = -Input.GetAxis("Mouse Y") * speedV;
        transform.Rotate(rotY, rotX,0);

        /*Vector3 q = transform.rotation.eulerAngles;
        q.z = 0f;*/
        //Debug.Log(transform.eulerAngles);

        Vector3 tmp = transform.eulerAngles;
        tmp.z = 0;

        if (tmp.x > 80 && tmp.x < 90){
            tmp.x = 80;
        }
        if (tmp.x < 280 && tmp.x > 270){
            tmp.x = 280;
        }
        transform.eulerAngles = tmp;

        /*transform.rotation.SetEulerAngles(q);
        Debug.Log(transform.rotation.eulerAngles);
        Debug.Log(q);*/
        //transform.rotation = q;
        //transform.rotation.eulerAngles.Set(q.x,q.y,q.z);
    }
}
