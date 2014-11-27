using UnityEngine;
using System.Collections;

public class Nuages : MonoBehaviour {

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.x > -10) {
			transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);		
				} else {
			transform.position = new Vector3(1, transform.position.y, transform.position.z);
				}


	}
}
