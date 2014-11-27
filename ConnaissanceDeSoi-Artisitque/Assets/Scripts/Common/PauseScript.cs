using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
    bool m_GamePaused;

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (m_GamePaused) {
                this.UnPause();
            }
            else {
                this.Pause();
            }
        }
    }

    void Pause() {
        Time.timeScale = 0.0f;
        m_GamePaused = true;
    }

    void UnPause() {
        Time.timeScale = 1.0f;
        m_GamePaused = false;
    }
}
