using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

	List<GameObject> chocando = new List<GameObject>();

	//List<GameObject> chocandoGravedad = new List<GameObject>();
	//GameObject ultimaGravedad = null;
	//public float fuerzaGravitatoriaCircular = 10f;
	public Transform planeta;
	Rigidbody r;
	//public GameObject planeta;
	public float fuerzaMovimiento = 0.1f;
	public float fuerzaMovimientoEnAire = 0.1f;
	public float fuerzaSalto = 1.0f;
	Camera cam;

	Vector3 movH = Vector3.zero;
	Vector3 movV = Vector3.zero;
	Vector3 movS = Vector3.zero;
	//Vector3 movHorizontal = Vector3.zero;
	//Vector3 movVertical = Vector3.zero;

	bool enSuelo = false;
	//Lista de cuadrados para ver a donde mira

	//int triggers = 0;

	void Awake () {
		r = GetComponent<Rigidbody> ();
		cam = Camera.main;

		r.maxAngularVelocity = 8;
		r.maxDepenetrationVelocity = 8;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Debug.Log(enSuelo);

		if (Input.GetKey (KeyCode.A)) {
			//r.AddForce (-cam.transform.right * fuerza, ForceMode.Impulse);
			//r.AddForce(-movHorizontal * fuerza, ForceMode.Impulse);
			float f = fuerzaMovimiento;
			if (!enSuelo)
				f = fuerzaMovimientoEnAire;

			AplicarFuerza(-movH, f);
		}

		if (Input.GetKey (KeyCode.D)) {
			//r.AddForce (cam.transform.right * fuerza, ForceMode.Impulse);
			//r.AddForce(movHorizontal * fuerza, ForceMode.Impulse);
			float f = fuerzaMovimiento;
			if (!enSuelo)
				f = fuerzaMovimientoEnAire;
			
			AplicarFuerza(movH, f);
		}

		if (Input.GetKey (KeyCode.W)) {
			//r.AddForce (cam.transform.up * fuerza, ForceMode.Impulse);
			float f = fuerzaMovimiento;
			if (!enSuelo)
				f = fuerzaMovimientoEnAire;
			AplicarFuerza(movV, f);
		}

		if (Input.GetKey (KeyCode.S)) {
			//r.AddForce (-cam.transform.up * fuerza, ForceMode.Impulse);
			float f = fuerzaMovimiento;
			if (!enSuelo)
				f = fuerzaMovimientoEnAire;

			AplicarFuerza(-movV, f);
		}

		if (enSuelo && Input.GetKeyDown (KeyCode.Space)) {
			//r.AddForce (movS * fuerzaSalto, ForceMode.Impulse);
			AplicarFuerzaSalto(movS, fuerzaSalto);
			enSuelo = false;
		}

		/*if (!enSuelo && chocandoGravedad.Count == 0){
			AplicarFuerza((planeta.transform.position - transform.position).normalized, fuerzaGravitatoriaCircular);
		}else{
			if (chocandoGravedad.Count > 0){
				Vector3 dir = chocandoGravedad[0].GetComponent<Gravedad>().direccion;
				AplicarFuerza(dir.normalized, fuerzaGravitatoriaCircular);
				AplicarFuerza((planeta.transform.position - transform.position).normalized, fuerzaGravitatoriaCircular/50);
			}else{
				AplicarFuerza((planeta.transform.position - transform.position).normalized, fuerzaGravitatoriaCircular/2);
				Debug.Log("otr");
			}
			
		}*/
		//Debug.Log(chocandoGravedad.Count);
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
/*
	void ComprobarGravedad(GameObject other){
		if (other.tag.Equals("gravedad")){
			if (!chocandoGravedad.Contains(other)){
				chocandoGravedad.Add(other);
				if (ultimaGravedad == null)
					ultimaGravedad = other;
			}
		}
	}
	void ComprobarGravedadSalida(GameObject other){
		if (other.tag.Equals("gravedad")){
			if (chocandoGravedad.Contains(other)){
				chocandoGravedad.Remove(other);
				if (chocandoGravedad.Count == 0){
					ultimaGravedad = null;
				}else{
					ultimaGravedad = other;
				}
			}
		}
	}*/

	void OnTriggerEnter(Collider other){
		//triggers++;
		ComprobarSuelo(other.gameObject);
		//ComprobarGravedad(other.gameObject);
	}
	void OnTriggerExit(Collider other){
		//triggers--;
		ComprobarSueloSalida(other.gameObject);
		//ComprobarGravedadSalida(other.gameObject);
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

	void AplicarFuerza (Vector3 mov, float f){
		r.AddForce (mov * f, ForceMode.Acceleration);
	}
	void AplicarFuerzaSalto (Vector3 mov, float f){
		r.AddForce (mov * f, ForceMode.VelocityChange);
	}	
}
