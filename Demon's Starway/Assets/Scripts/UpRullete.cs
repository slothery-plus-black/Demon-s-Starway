using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpRullete : MonoBehaviour {
	GameObject roullete;
	RoulletePos roulleteP;
	GameObject roulleteL;
	RoulletePos roulletePL;
	CMl_Script cMl_Script;

	// Use this for initialization
	void Start () {
		roullete = GameObject.Find ("Roullete");
		roulleteP = roullete.GetComponent<RoulletePos> ();
		roulleteL = GameObject.Find ("RuletaNiveles");
		roulletePL = roulleteL.GetComponent<RoulletePos> ();
		cMl_Script = GameObject.Find("CM_level").GetComponent<CMl_Script>();
	}

	// Update is called once per frame
	void Update () {
	}

	void OnMouseUp(){
		transform.parent.transform.Translate(0,2,0);
		if(!cMl_Script.GetLevel()){
			//print ("ButtoDownP");
			roulleteP.SetBoolUp ();
		}else{
			//print ("ButtoDownPL");
			roulletePL.SetBoolUp ();
		}
		
	}

	void OnMouseDown(){
		transform.parent.transform.Translate(0,-2,0);
	}

}