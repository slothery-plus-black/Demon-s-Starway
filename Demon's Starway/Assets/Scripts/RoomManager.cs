using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

	string typeName = "com.Slothery.DemonsStarway";
	string gameName = "default";

	private HostData[] hostList;
 

 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartServer()
	{
		Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}

	void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
		SpawnPlayer();
	}

	public void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}

	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
	}

	public void JoinServer(HostData hostData)
	{
		Network.Connect(hostData);
	}
 
	void OnConnectedToServer()
	{
		Debug.Log("Server Joined");
		SpawnPlayer();
	}

	private void SpawnPlayer()
	{
		Debug.Log("spawn");
		//Network.Instantiate(playerPrefab, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
	}

	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer)
		{
			if (GUI.Button(new Rect(100, 100, 250, 100), "Crear"))
				StartServer();
	
			if (GUI.Button(new Rect(100, 250, 250, 100), "Actualizar salas"))
				RefreshHostList();
	
			if (hostList != null)
			{
				for (int i = 0; i < hostList.Length; i++)
				{
					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
						JoinServer(hostList[i]);
				}
			}
		}
	}
	
	
}
