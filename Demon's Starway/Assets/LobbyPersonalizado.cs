using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyPersonalizado : NetworkLobbyManager {

	// Use this for initialization
	void Start () {
		MMStart();
		MMListMatches();
	}

	void MMStart(){
		print("start");

		this.StartMatchMaker();
	}

	void MMListMatches(){
		print("list");

		this.matchMaker.ListMatches(0,20,"",true,0,0,OnMatchList);
	}

	public override void OnMatchList(bool success, string extendedInfo, List<UnityEngine.Networking.Match.MatchInfoSnapshot> matchList){
		print("matchlist");
		
		base.OnMatchList(success,extendedInfo,matchList);

		//if 
	}

	void MMJoinMatch(){
		print("join");
	}

	void MMCreateMatch(){
		print("create");
	}
}
