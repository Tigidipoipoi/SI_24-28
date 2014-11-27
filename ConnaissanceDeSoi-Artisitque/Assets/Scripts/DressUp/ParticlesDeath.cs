using UnityEngine;
using System.Collections;

public class ParticlesDeath : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		if (!gameObject.particleSystem.isPlaying) {
			Destroy(this.gameObject);
		}

	
	}
}
