using UnityEngine;
using System.Collections;

public class EffectControl : MonoBehaviour {
	public GameObject shot_effect;
	

    void ShotEffect (){
		Vector3 m_mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Instantiate(shot_effect, m_mousePos, transform.rotation);
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Sound.Manager.Shooter_Shoot.Play (Random.Range (0.95f, 1.05f));
			ShotEffect();
		}
	}
	
}
