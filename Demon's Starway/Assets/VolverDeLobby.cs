﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VolverDeLobby : MonoBehaviour {

	public NetworkLobbyManager manager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		//Destroy(manager);
            //NetworkManager.Shutdown();
			//Network.Disconnect();
			manager.StopHost();
		/*manager.StopMatchMaker();
		manager.StopClient();
		manager.StopHost();
		Destroy(manager.gameObject.GetComponent<NetworkManager>());*/
		//CargadorEscenas.CargaEscenaAsync("Menu");
		
	}
}