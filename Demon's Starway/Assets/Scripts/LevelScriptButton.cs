using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScriptButton : MonoBehaviour {
	GameObject CM_Level;
	CMl_Script cMl_Script;
	RoulletePos RoulletePos;
	

	void Awake(){
		CM_Level = GameObject.Find("CM_level");
		cMl_Script = CM_Level.GetComponent<CMl_Script>();
		RoulletePos = GameObject.Find("Roullete").GetComponent<RoulletePos>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if(!cMl_Script.GetLevel()){
			//print("pulsado");
			if((int)RoulletePos.GetAnlge()==0){;
				cMl_Script.SetBoolMov();
			}
		}
	}
}
