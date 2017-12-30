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
		//vidas = GameObject.Find("VidasMulti").GetComponent<VidasMulti>();
	}

	/*public override void OnStartLocalPlayer()
	{
        vidas = GameObject.Find("VidasMulti").GetComponent<VidasMulti>();
    }*/

	void Start(){
		posInicial = transform.position;
		
		pivot = GameObject.Find("pivot camara");

		posInicialCamara = pivot.transform.position;
		posInicialRotation = pivot.transform.rotation;

		vidas = GameObject.Find("VidasMulti").GetComponent<VidasMulti>();

		vidas.BuscarSalida();
	}
	
	void OnPlayerConnected(NetworkPlayer player) {
        
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
			}else{
				CargadorEscenas.CargaEscenaAsync("Menu");
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

	void OnTriggerEnter(Collider other){
		//print(vidas.GetPuntas());
		if (other.gameObject.tag.ToLower().Equals("salida")){
			if (vidas.GetPuntas() >= 5){
				CargadorEscenas.CargaEscenaAsync("Menu");
			}
		}

		if (other.gameObject.tag.ToLower().Equals("punta")){

			//Si se tienen las 5
			
			//Debug.Log(vidas);
			vidas.CogerPunta(other.gameObject);

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
