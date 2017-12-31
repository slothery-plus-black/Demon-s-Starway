using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoquesJugador : MonoBehaviour {

	PuntasEstrella puntas = new PuntasEstrella();

	int vidas = 3;
	Vector3 posInicial;
	Vector3 posInicialCamara;
	Quaternion posInicialRotation;

	ReproductorSonidos sonidos;
	
	//public GameObject salida;
	public GameObject PS_Salida;

	GameObject pivot;
	GameObject RenderVidas;

	// Use this for initialization
	void Awake () {
		posInicial = transform.position;
		
		pivot = GameObject.Find("pivot camara");

		posInicialCamara = pivot.transform.position;
		posInicialRotation = pivot.transform.rotation;

		RenderVidas = GameObject.Find("ControlDeVidas");

		sonidos = GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>();
	}
	
	// Update is called once per frame
	void Update () {
		//print(posInicialCamara.position);
	}

	void ComprobarEnemigo(GameObject other){
		if (other.tag.ToLower().Equals("enemigo")){
			
			vidas --;
			RenderVidas.transform.GetChild(vidas).gameObject.SetActive(false);
			if (vidas <= 0){
				sonidos.ReproducirSonidoMuerte();
				RenderVidas.transform.GetChild(3).gameObject.SetActive(true);
				//DeshabilidarMovimientos

				//CargadorEscenas.CargaEscenaAsync("Menu");
				
			}else{
				sonidos.ReproducirSonidoDanio();
				pivot.transform.position = posInicialCamara;
				pivot.transform.rotation = posInicialRotation;

				transform.position = posInicial;
				sonidos.ReproducirSonidoSpawn();
			}
		}
	}

	void OnTriggerEnter(Collider other){
		
		if (puntas.GetPuntas() >= 5 && other.gameObject.tag.ToLower().Equals("salida")){
			CargadorEscenas.CargaEscenaAsync("Menu");
		}

		if (other.gameObject.tag.ToLower().Equals("punta")){
			sonidos.ReproducirPuntaEstrella(puntas.GetPuntas());
			puntas.SumarPunta();
			Destroy(other.gameObject);
			if (puntas.GetPuntas() >= 5){
				sonidos.ReproducirSonidoSalida();
				//salida.SetActive(true);
				PS_Salida.SetActive(true);
			}
		}

		ComprobarEnemigo(other.gameObject);
	}

	void OnCollisionEnter(Collision other){
		ComprobarEnemigo(other.gameObject);
	}
}
