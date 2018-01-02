using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorMovil : MonoBehaviour {

	// Use this for initialization
	void Awake () {

		

		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL || UNITY_FACEBOOK
			Debug.Log("Escritorio");
			gameObject.SetActive(false);
		#endif


		#if UNITY_IPHONE || UNITY_ANDROID
			Debug.Log("Movil");
			gameObject.SetActive(true);
		#endif
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
