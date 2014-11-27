using UnityEngine;
using System.Collections;

public class Bandeau : MonoBehaviour {
	private float Acceleration = 1f;
	private Vector3 Coordonnees;
	// Use this for initialization
	void Start () {
	Coordonnees = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		transform.position =  new Vector3(Coordonnees.x,Coordonnees.y+3.5f,Coordonnees.z);
	
	}
	
	// Update is called once per frame
	void Update () {

		Acceleration = (Coordonnees.y-transform.position.y)/10;
		transform.position = new Vector3(transform.position.x, transform.position.y+Acceleration, transform.position.z);
	
	}
}
