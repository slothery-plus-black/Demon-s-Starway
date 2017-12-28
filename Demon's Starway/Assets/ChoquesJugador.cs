using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoquesJugador : MonoBehaviour {

	PuntasEstrella puntas = new PuntasEstrella();

	public ReproductorSonidos sonidos;
	public AudioClip sonidoPunta;
	public GameObject salida;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		
		if (puntas.GetPuntas() >= 5 && other.gameObject.tag.ToLower().Equals("salida")){
			CargadorEscenas.CargaEscenaAsync("mundo1");
		}

		if (other.gameObject.tag.ToLower().Equals("punta")){
			sonidos.ReproducirSonido(sonidoPunta);
			puntas.SumarPunta();
			Destroy(other.gameObject);
			if (puntas.GetPuntas() >= 5){
				salida.SetActive(true);
			}
		}

		if (other.gameObject.tag.ToLower().Equals("enemigo")){
			//Se le quita una vida o muere
			CargadorEscenas.CargaEscenaAsync("mundo1");
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag.ToLower().Equals("enemigo")){
			//Se le quita una vida o muere
			CargadorEscenas.CargaEscenaAsync("mundo1");
		}
	}
}
