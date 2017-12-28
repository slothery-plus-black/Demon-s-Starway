using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngelRecto : MonoBehaviour {

	public Transform[] points;
	public float velocidad;
	int curPoint;
	bool doPatrol = true;
	Vector3 target;
	Vector3 direccion;
	Vector3 vel;
	
	private Rigidbody r;

	void Start () {
		r = GetComponent<Rigidbody>();
	}

	void Update () {
		if (curPoint < points.Length){
			target = points[curPoint].position;
			direccion = target - transform.position;
			vel = r.velocity;

			if (direccion.magnitude < 1){
				curPoint++;
			}else{
				vel = direccion.normalized * velocidad;
			}
		}else{
			if (doPatrol){
				curPoint = 0;
			}else{
				vel = Vector3.zero;
			}
		}

		r.velocity = vel;

		var targetRotation = Quaternion.LookRotation(target - transform.position);
       
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, velocidad * Time.deltaTime);
	}
}
