using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VidasMulti : NetworkBehaviour {

	[SyncVar]
	PuntasEstrella puntas;
	[SyncVar]
	private int vidas = 3;

	ReproductorSonidos sonidos;
	GameObject salida;

	// Use this for initialization
	void Start () {

		if (GameObject.FindGameObjectsWithTag("vidas").Length <= 1){
			DontDestroyOnLoad(gameObject);
		}
		else{
			VidasMulti temp = GameObject.FindGameObjectsWithTag("vidas")[0].GetComponent<VidasMulti>();
			temp.Reset();
			Destroy(gameObject);
		}
		//sonidos = GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>();
		//salida = GameObject.FindGameObjectWithTag("salida");
		//salida.SetActive(false);
		//print(salida);

		puntas = new PuntasEstrella();
        sonidos = GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>();
		//salida = GameObject.FindGameObjectWithTag("salida");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset(){
		puntas = new PuntasEstrella();
		vidas = 3;
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

	public void CogerPunta(GameObject punta){

		sonidos.ReproducirPuntaEstrella(puntas.GetPuntas());

		Destroy(punta);
		puntas.SumarPunta();

		if (puntas.GetPuntas() >= 5){
			sonidos.ReproducirSonidoSalida();
			salida.SetActive(true);
			//return true;
		}

		//return false;
	}

	public void BuscarSalida(){
		salida = GameObject.FindGameObjectWithTag("salida");
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
