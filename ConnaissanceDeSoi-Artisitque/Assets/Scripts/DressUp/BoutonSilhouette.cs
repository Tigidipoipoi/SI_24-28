using UnityEngine;
using System.Collections;



public class BoutonSilhouette : MonoBehaviour {

	public GameObject BoutonOK;
	public GameObject Silhouette;

	void OnMouseDown() {

	if (renderer.enabled == false) {
			BoutonOK.renderer.enabled = false;
			renderer.enabled = true;
			Silhouette.renderer.enabled = true;
		}
		else
		{
			BoutonOK.renderer.enabled = true;
			renderer.enabled = false;
			Silhouette.renderer.enabled = false;
		}
	}
}
