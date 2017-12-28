using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLevel_B : MonoBehaviour {
	GameObject CM_Level;
	CMl_Script cMl_Script;
	

	void Awake(){
		CM_Level = GameObject.Find("CM_level");
		cMl_Script = CM_Level.GetComponent<CMl_Script>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if(cMl_Script.GetLevel()){
		cMl_Script.SetBoolMov();
		}
	}
}
