using UnityEngine;
using System.Collections;

public class BulleTexteAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(0.1f,0.1f,0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale != new Vector3(1,1,1)){
			transform.localScale = new Vector3(transform.localScale.x + ((1 - transform.localScale.x)/6), transform.localScale.y + ((1 - transform.localScale.y)/6), transform.localScale.z + ((1 - transform.localScale.x)/6));
		}
	}
}
