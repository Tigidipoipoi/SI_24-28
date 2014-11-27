using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	public float c_Duration = 0.3f;
	public float m_Magnitude = 0.1f;

    public void ScreenShake() {
		StartCoroutine("Shake");
	}

	IEnumerator Shake() {
		float m_elapsed = 0.0f;
		Vector3 m_originalCamPos = Camera.main.transform.position;

		while (m_elapsed < c_Duration) {
			m_elapsed += Time.deltaTime;

			float m_percentComplete = m_elapsed/c_Duration;
			float m_damper = 1.0f - Mathf.Clamp(4.0f * m_percentComplete - 3.0f, 0.0f, 1.0f);

			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= m_Magnitude * m_damper;
			y *= m_Magnitude * m_damper;

			Camera.main.transform.position = new Vector3(x,y, m_originalCamPos.z);

			yield return null;
		}

		Camera.main.transform.position = m_originalCamPos;
	}
}
