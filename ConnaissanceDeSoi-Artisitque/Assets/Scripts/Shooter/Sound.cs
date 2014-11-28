using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SoundEffect
{
    public AudioClip mysound;

    public void Play()
    {
        Sound.Manager.Play(mysound, 1f);
    }

    public void Play(float pitch)
    {
        Sound.Manager.Play(mysound, pitch);
    }
}

[System.Serializable]
public class SoundEffectCluster
{
    public AudioClip[] mysound;

    public void Play()
    {
        Sound.Manager.Play(mysound[Random.Range(0,mysound.Length)], 1f);
    }

    public void Play(float pitch)
    {
        Sound.Manager.Play(mysound[Random.Range(0, mysound.Length)], pitch);
    }
}


public class Sound : MonoBehaviour {

    public static Sound Manager = null;

    public Transform SoundPrefab;

    [HideInInspector]
    public List<Transform> Soundprefabs = new List<Transform>();

    public SoundEffect Shooter_Hit, Shooter_Shoot;
    public SoundEffectCluster Explosions;
	void Start () 
    {

        if (Manager == null) Manager = this;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play(AudioClip mysound,float pitchou)
    {
        Transform o;
        if (Sound.Manager.Soundprefabs.Count <= 0)
        {
            o = (Transform)Instantiate(Sound.Manager.SoundPrefab);
        }
        else
        {
            o = Sound.Manager.Soundprefabs[0];
            Sound.Manager.Soundprefabs.RemoveAt(0);
        }

        o.position = Vector3.zero;
        o.GetComponent<Script_SoundEffect>().soundplay = true;
        o.GetComponent<AudioSource>().clip = mysound;
        o.GetComponent<AudioSource>().Play();
        o.GetComponent<AudioSource>().pitch = pitchou;
    }
}
