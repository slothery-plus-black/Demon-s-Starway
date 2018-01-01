using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

	ReproductorSonidos sonidos;

	bool muerte = false;

	List<GameObject> chocando = new List<GameObject>();

	public Transform planeta;
	Rigidbody r;
	public float fuerzaMovimiento = 0.1f;
	public float fuerzaMovimientoEnAire = 0.1f;
	public float fuerzaSalto = 1.0f;
	Camera cam;

	Vector3 movH = Vector3.zero;
	Vector3 movV = Vector3.zero;
	Vector3 movS = Vector3.zero;

	bool enSuelo = false;
	int TimeOnJump = 0;

	float limiteMovil = 0.25f;

	public VirtualJoystick joystickMovimiento;

	Vector3 fuerzaTotal = Vector3.zero;

	void Awake () {
		r = GetComponent<Rigidbody> ();
		cam = Camera.main;

		r.maxAngularVelocity = 8;
		r.maxDepenetrationVelocity = 8;

		sonidos = GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>();

		if (planeta == null){
			planeta = GameObject.Find("planeta").transform;
		}
	}

	void Start (){
		sonidos.ReproducirSonidoSpawn();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!muerte){
			bool tecla = false;

			#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WEBGL
				float h = joystickMovimiento.Horizontal();
				float v = joystickMovimiento.Vertical();

				if (h > limiteMovil){
					AplicarFuerza(movH);

					tecla = true;
				}
				if (h < -limiteMovil){
					AplicarFuerza(-movH);

					tecla = true;
				}
				if (v > limiteMovil){
					AplicarFuerza(movV);

					tecla = true;
				}
				if (v < -limiteMovil){
					AplicarFuerza(-movV);

					tecla = true;
				}
			#endif

			if(!enSuelo){
				if(TimeOnJump<=2){
					transform.GetChild(0).gameObject.transform.localScale = new Vector3 (0.75f,1.5f,0.75f);
					TimeOnJump++;
				}else if(TimeOnJump==3){
					transform.GetChild(0).gameObject.transform.localScale = new Vector3 (0.85f,1.25f,0.85f);
					TimeOnJump++;
				}
				else{
					transform.GetChild(0).gameObject.transform.localScale = new Vector3 (1,1,1);
				}
			}else{
				transform.GetChild(0).gameObject.transform.localScale = new Vector3 (1,1,1);
				TimeOnJump=0;
			}

			if (Input.GetKey (KeyCode.A)) {
				AplicarFuerza(-movH);
				tecla = true;
			}

			if (Input.GetKey (KeyCode.D)) {
				AplicarFuerza(movH);
				tecla = true;
			}

			if (Input.GetKey (KeyCode.W)) {
				AplicarFuerza(movV);
				tecla = true;
			}

			if (Input.GetKey (KeyCode.S)) {
				AplicarFuerza(-movV);
				tecla = true;
			}

			if (enSuelo && Input.GetKey (KeyCode.Space)) {
				sonidos.ReproducirSonidoSalto();
				AplicarFuerzaSalto(movS, fuerzaSalto);
				enSuelo = false;
			}

			if (fuerzaTotal != Vector3.zero){
				float f = fuerzaMovimiento;
				if (!enSuelo)
					f = fuerzaMovimientoEnAire;
				AplicarFuerzaFinal(f);
			}

			if (enSuelo && !tecla){
				r.velocity /= 2;
			}
		}
	}

	void ComprobarSuelo(GameObject other){
		if (other.tag.Equals("suelo")){
			if (!chocando.Contains(other)){
				chocando.Add(other);
			}

			if (chocando.Count > 0)
				enSuelo = true;
		}
	}
	
	void ComprobarSueloSalida(GameObject other){
		if (other.tag.Equals("suelo")){
			if (chocando.Contains(other)){
				chocando.Remove(other);
			}

			if (chocando.Count == 0)
				enSuelo = false;
		}
	}

	void OnTriggerEnter(Collider other){
		ComprobarSuelo(other.gameObject);
	}
	void OnTriggerExit(Collider other){
		ComprobarSueloSalida(other.gameObject);
	}

	void OnCollisionEnter(Collision other){
		ComprobarSuelo(other.gameObject);
	}

	void OnCollisionExit(Collision other){
		ComprobarSueloSalida(other.gameObject);
	}

	void OnTriggerStay(Collider other){
		switch (other.gameObject.name){
			case "x":
				movH = (planeta.transform.forward);
				movV = (planeta.transform.up);
				movS = Vector3.right;
			break;
			case "-x":
				movH = (-planeta.transform.forward);
				movV = (planeta.transform.up);
				movS = -Vector3.right;
			break;

			case "y":
				movH = (cam.transform.right);
				Vector3 a = cam.transform.up + cam.transform.forward;
				movV = (a.normalized);
				movS = Vector3.up;
			break;
			case "-y":
				movH = (cam.transform.right);
				Vector3 a2 = -cam.transform.up + cam.transform.forward;
				movV = (-a2.normalized);
				movS = -Vector3.up;
			break;

			case "z":
				movH = (-planeta.transform.right);
				movV = (planeta.transform.up);
				movS = Vector3.forward;
			break;
			case "-z":
				movH = (planeta.transform.right);
				movV = (planeta.transform.up);
				movS = -Vector3.forward;
			break;
		}
	}

	void AplicarFuerza (Vector3 mov){
		fuerzaTotal += mov;
	}

	void AplicarFuerzaFinal (float f){
		r.AddForce (fuerzaTotal * f, ForceMode.Acceleration);
		fuerzaTotal = Vector3.zero;
	}

	void AplicarFuerzaSalto (Vector3 mov, float f){
		r.AddForce (mov * f, ForceMode.VelocityChange);
	}

	public void AplicarFuerzaSaltoMovil(){
		if (enSuelo){
			sonidos.ReproducirSonidoSalto();
			r.AddForce (movS * fuerzaSalto, ForceMode.VelocityChange);
			enSuelo = false;
		}
	}

	public void Muerte(){
		muerte = true;
	}
}
