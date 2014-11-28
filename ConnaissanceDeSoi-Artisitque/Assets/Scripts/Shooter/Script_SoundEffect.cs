using UnityEngine;
using System.Collections;

public class Script_SoundEffect : MonoBehaviour {

    public bool soundplay = true;

	void Start () {
	
	}
	
	void Update () {

        if (GetComponent<AudioSource>().isPlaying == false && soundplay)
        {
            soundplay = false;
            Sound.Manager.Soundprefabs.Add(transform);
        }
	
	}
}
