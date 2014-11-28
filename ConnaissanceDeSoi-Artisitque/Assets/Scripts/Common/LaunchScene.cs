using UnityEngine;
using System.Collections;

public class LaunchScene : MonoBehaviour {


	public void LoadScene(string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
}
