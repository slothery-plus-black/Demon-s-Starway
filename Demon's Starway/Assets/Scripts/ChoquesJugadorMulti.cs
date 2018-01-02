using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class ChoquesJugadorMulti : NetworkBehaviour {

	public static short clientID = 123;
	//PuntasEstrella puntas = new PuntasEstrella();
	//VidasMulti vidas;

	PuntasEstrella puntas;
	ReproductorSonidos sonidos;

	/*[SyncVar]
	int vidas = 3;*/
	Vector3 posInicial;
	Vector3 posInicialCamara;
	Quaternion posInicialRotation;

	public GameObject salida;

	NetworkLobbyManager manager;

	GameObject[] jugadores;
	bool cargaJugadores = false;

	//ReproductorSonidos sonidos;
	
	//public GameObject salida;

	GameObject pivot;

	// Use this for initialization
	void Awake () {
		manager = GameObject.Find("LobbyManager").GetComponent<NetworkLobbyManager>();

		puntas = new PuntasEstrella();
		posInicial = transform.position;
		
		pivot = GameObject.Find("pivot camara");

		posInicialCamara = pivot.transform.position;
		posInicialRotation = pivot.transform.rotation;

		sonidos = GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>();
	}

	void Start(){
		posInicial = transform.position;
		
		pivot = GameObject.Find("pivot camara");

		posInicialCamara = pivot.transform.position;
		posInicialRotation = pivot.transform.rotation;

		//vidas = GameObject.Find("VidasMulti").GetComponent<VidasMulti>();

		//vidas.BuscarSalida();

		salida = GameObject.FindGameObjectWithTag("salida");
		for (int i=0; i < salida.transform.childCount;i++){
			salida.transform.GetChild(i).gameObject.SetActive(false);
		}
		
	}
	

	// Update is called once per frame
	void Update () {
		//print(vidas.GetPuntas());
		//print(posInicialCamara.position);
		if (Input.GetKeyDown("f")){
			CargadorEscenas.CargaEscenaAsync("multiFinal");
			//Network.Disconnect ();
			
			Destroy(GameObject.Find("LobbyPlayer(Clone)").gameObject);
			Destroy (manager.gameObject);
			//manager.StopHost();
			//manager.StopAllCoroutines();

			//CargadorEscenas.CargaEscenaAsync("multiFinal");
		}

		jugadores = GameObject.FindGameObjectsWithTag("Player");
		//print("Jugadores: "+jugadores);

		if (jugadores.Length >= 2){
			cargaJugadores = true;
		}
		/*if (cargaJugadores && jugadores < 2){
			Desconectar(0);
		}*/
	}

	void ComprobarEnemigo(GameObject other){
		if (isLocalPlayer && other.tag.ToLower().Equals("enemigo")){
			
			//if (!vidas.Restar()){
				pivot.transform.position = posInicialCamara;
				pivot.transform.rotation = posInicialRotation;
				transform.position = posInicial;
			//}else{
				//CargadorEscenas.CargaEscenaAsync("Menu");
			//}
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
		if (isLocalPlayer){
				//print(vidas.GetPuntas());
			if (other.gameObject.tag.ToLower().Equals("salida")){
				if (puntas.GetPuntas() >= 5){
					/*MessageBase message;
					NetworkMessage msg = new NetworkMessage();

					msg.msgType = clientID;
					msg.

					NetworkServer.SendToAll(clientID,)*/

					CargadorEscenas.CargaEscenaAsync("LobbyMultijugador");
					Network.Disconnect();

					/*sonidos.SetGanador(1);
					foreach (GameObject o in jugadores){
						o.GetComponent<ChoquesJugadorMulti>().Desconectar();
					}*/
					//Desconectar(1);
				}
			}

			if (other.gameObject.tag.ToLower().Equals("punta")){

				//Si se tienen las 5
				
				//Debug.Log(vidas);
				//vidas.CogerPunta(other.gameObject);
				sonidos.ReproducirPuntaEstrella(puntas.GetPuntas());
				puntas.SumarPunta();
				Destroy(other.gameObject);

				if (puntas.GetPuntas()>=5){
					sonidos.ReproducirSonidoSalida();
					for (int i=0; i < salida.transform.childCount;i++){
						salida.transform.GetChild(i).gameObject.SetActive(true);
					}
				}

			}

			ComprobarEnemigo(other.gameObject);
		}
		
	}

	/*void Desconectar(int n){
		sonidos.SetGanador(n);
		
		//Network.Disconnect ();
		foreach (GameObject o in GameObject.FindObjectsOfType(typeof (NetworkLobbyPlayer))){
			Destroy(o);
		}
		Destroy (manager.gameObject);
		gameObject.tag = "Untagged";

		CargadorEscenas.CargaEscenaAsync("multiFinal");
	}

	void Desconectar(){
		//sonidos.SetGanador(n);
		
		//Network.Disconnect ();
		foreach (NetworkLobbyPlayer o in GameObject.FindObjectsOfType(typeof (NetworkLobbyPlayer))){
			Destroy(o.gameObject);
		}
		Destroy (manager.gameObject);
		//gameObject.tag = "Untagged";

		CargadorEscenas.CargaEscenaAsync("multiFinal");
	}*/
	const short MyBeginMsg = 1002;

    NetworkClient m_client;

    public void SendReadyToBeginMessage(int myId)
    {
        var msg = new IntegerMessage(myId);
        m_client.Send(MyBeginMsg, msg);
    }

    public void Init(NetworkClient client)
    {
        m_client = client;
        NetworkServer.RegisterHandler(MyBeginMsg, OnServerReadyToBeginMessage);
    }

    void OnServerReadyToBeginMessage(NetworkMessage netMsg)
    {
        var beginMessage = netMsg.ReadMessage<IntegerMessage>();
        Debug.Log("received OnServerReadyToBeginMessage " + beginMessage.value);
    }

	void OnCollisionEnter(Collision other){
		ComprobarEnemigo(other.gameObject);
	}
}
