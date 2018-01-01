using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {
    //public GameObject jugador;
    //public GameObject planeta;
	public float speedH = 2.0f;
    public float speedV = 2.0f;

    public VirtualJoystick joystick;

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
        if (Input.touchCount > 0){
            //Debug.Log("Touch");
            //HandleTouch(Input.touches[0].phase);

            MoverCamara(joystick.Horizontal(),joystick.Vertical());
            
        }else{
            if (Input.GetMouseButtonDown(0)){
                MoverCamara(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
            }

            if (Input.GetMouseButtonUp(0)){
                MoverCamara(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
            }

            if (Input.GetMouseButton(0)){
                MoverCamara(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
            }
        }
    }

    void FixedUpdate () {
		//gameObject.transform.LookAt (planeta.transform.position);
        
	}

    /*
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
        float rotX = 0;
        float rotY = 0;

        if (Input.touchCount > 0){
            rotX = Input.touches[0].deltaPosition.x * Input.touches[0].deltaTime * speedH;
            rotY = -Input.touches[0].deltaPosition.y * Input.touches[0].deltaTime * speedV;
        }else{
            rotX = Input.GetAxis("Mouse X") * speedH;
            rotY = -Input.GetAxis("Mouse Y") * speedV;
        }

        transform.Rotate(rotY, rotX, 0);

        //Vector3 q = transform.rotation.eulerAngles;
        //q.z = 0f;
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

        //transform.rotation.SetEulerAngles(q);
        //Debug.Log(transform.rotation.eulerAngles);
        //Debug.Log(q);
        //transform.rotation = q;
        //transform.rotation.eulerAngles.Set(q.x,q.y,q.z);
    }*/

    void MoverCamara(float rotX, float rotY){
        rotX *= speedH;
        rotY *= speedV;
        //float rotX = 0;
        //float rotY = 0;

        /*if (Input.touchCount > 0){
            rotX = Input.touches[0].deltaPosition.x * Input.touches[0].deltaTime * speedH;
            rotY = -Input.touches[0].deltaPosition.y * Input.touches[0].deltaTime * speedV;
        }else{
            rotX = Input.GetAxis("Mouse X") * speedH;
            rotY = -Input.GetAxis("Mouse Y") * speedV;
        }*/

        transform.Rotate(rotY, -rotX, 0);

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
