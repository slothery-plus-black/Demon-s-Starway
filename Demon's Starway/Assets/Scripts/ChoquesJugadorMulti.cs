using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChoquesJugadorMulti : NetworkBehaviour {

	//PuntasEstrella puntas = new PuntasEstrella();
	VidasMulti vidas;

	/*[SyncVar]
	int vidas = 3;*/
	Vector3 posInicial;
	Vector3 posInicialCamara;
	Quaternion posInicialRotation;

	//ReproductorSonidos sonidos;
	
	//public GameObject salida;

	GameObject pivot;

	// Use this for initialization
	void Awake () {
		posInicial = transform.position;
		
		pivot = GameObject.Find("pivot camara");

		posInicialCamara = pivot.transform.position;
		posInicialRotation = pivot.transform.rotation;

		//sonidos = GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>();
		vidas = GameObject.Find("Vidas").GetComponent<VidasMulti>();
	}
	
	// Update is called once per frame
	void Update () {
		//print(vidas.GetPuntas());
		//print(posInicialCamara.position);
	}

	void ComprobarEnemigo(GameObject other){
		if (other.tag.ToLower().Equals("enemigo")){
			
			if (!vidas.Restar()){
				pivot.transform.position = posInicialCamara;
				pivot.transform.rotation = posInicialRotation;
				transform.position = posInicial;
				//RpcRespawn();
			}
			//vidas --;

			/*if (vidas <= 0){
				sonidos.ReproducirSonidoMuerte();
				//CargadorEscenas.CargaEscenaAsync("Menu");
				
			}else{
				sonidos.ReproducirSonidoDanio();
				pivot.transform.position = posInicialCamara;
				pivot.transform.rotation = posInicialRotation;

				RpcRespawn();
				
				sonidos.ReproducirSonidoSpawn();
			}*/
		}
	}

	[ClientRpc]
	void RpcRespawn()
	{
		if (isLocalPlayer)
		{
			// move back to zero location
			transform.position = posInicial;
		}
	}

	void OnTriggerEnter(Collider other){
		
		if (vidas.GetPuntas() >= 5 && other.gameObject.tag.ToLower().Equals("salida")){
			CargadorEscenas.CargaEscenaAsync("Menu");
		}

		if (other.gameObject.tag.ToLower().Equals("punta")){

			//Si se tienen las 5
			if (vidas.CogerPunta(other.gameObject)){
				
			}

			//sonidos.ReproducirPuntaEstrella(puntas.GetPuntas());
			//puntas.SumarPunta();
			//Destroy(other.gameObject);
			/*if (puntas.GetPuntas() >= 5){
				sonidos.ReproducirSonidoSalida();
				salida.SetActive(true);
			}*/
		}

		ComprobarEnemigo(other.gameObject);
	}

	void OnCollisionEnter(Collision other){
		ComprobarEnemigo(other.gameObject);
	}
}
