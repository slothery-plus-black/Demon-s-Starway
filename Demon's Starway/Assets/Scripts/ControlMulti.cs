using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class ControlMulti : NetworkBehaviour {

	ReproductorSonidos sonidos = null;
	//public AudioClip sonidoSalto;

	List<GameObject> chocando = new List<GameObject>();

	//List<GameObject> chocandoGravedad = new List<GameObject>();
	//GameObject ultimaGravedad = null;
	//public float fuerzaGravitatoriaCircular = 10f;
	public Transform planeta = null;
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

	Vector3 fuerzaTotal = Vector3.zero;

	void Start () {
		r = GetComponent<Rigidbody> ();
		cam = Camera.main;

		r.maxAngularVelocity = 8;
		r.maxDepenetrationVelocity = 8;

		if (isLocalPlayer){
			Renderer rend = GetComponent<Renderer>();
			rend.material.shader = Shader.Find("LowPolyShaders/LowPolyPBRShader");
			rend.material.SetColor("_Color", Color.red);
		}

		sonidos = GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>();
		sonidos.ReproducirSonidoSpawn();

		planeta = GameObject.Find("planeta").transform;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//OnStartLocalPlayer();
		//ComprobarVariables();
		if (!isLocalPlayer)
		{
			return;
		}

		bool tecla = false;

		if (Input.GetKey (KeyCode.A)) {
			//r.AddForce (-cam.transform.right * fuerza, ForceMode.Impulse);
			//r.AddForce(-movHorizontal * fuerza, ForceMode.Impulse);

			AplicarFuerza(-movH);

			tecla = true;
		}

		if (Input.GetKey (KeyCode.D)) {
			//r.AddForce (cam.transform.right * fuerza, ForceMode.Impulse);
			//r.AddForce(movHorizontal * fuerza, ForceMode.Impulse);
			
			AplicarFuerza(movH);

			tecla = true;
		}

		if (Input.GetKey (KeyCode.W)) {
			//r.AddForce (cam.transform.up * fuerza, ForceMode.Impulse);
			AplicarFuerza(movV);

			tecla = true;
		}

		if (Input.GetKey (KeyCode.S)) {
			//r.AddForce (-cam.transform.up * fuerza, ForceMode.Impulse);

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
}
