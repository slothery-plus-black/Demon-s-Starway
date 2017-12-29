using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasMulti : MonoBehaviour {

	PuntasEstrella puntas = new PuntasEstrella();
	private int vidas = 3;

	ReproductorSonidos sonidos;
	GameObject salida;

	// Use this for initialization
	void Start () {
		sonidos = GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>();
		salida = GameObject.FindGameObjectWithTag("salida");
		salida.SetActive(false);
		//print(salida);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool Restar(){
		vidas--;

		if (vidas <= 0){
			sonidos.ReproducirSonidoMuerte();
			return true;
		}else{
			sonidos.ReproducirSonidoSpawn();
		}

		return false;
	}

	public bool CogerPunta(GameObject punta){
		sonidos.ReproducirPuntaEstrella(puntas.GetPuntas());
		Destroy(punta);

		puntas.SumarPunta();

		if (puntas.GetPuntas() >= 5){
			sonidos.ReproducirSonidoSalida();
			salida.SetActive(true);
			return true;
		}

		return false;
	}

	public int GetPuntas(){
		return puntas.GetPuntas();
	}

	/*public void ComprobarEnemigo(){
		if (vidas <= 0){
			sonidos.ReproducirSonidoMuerte();
			//CargadorEscenas.CargaEscenaAsync("Menu");
			
		}else{
			sonidos.ReproducirSonidoDanio();
			pivot.transform.position = posInicialCamara;
			pivot.transform.rotation = posInicialRotation;

			RpcRespawn();
			
			sonidos.ReproducirSonidoSpawn();
		}
	}*/
}
