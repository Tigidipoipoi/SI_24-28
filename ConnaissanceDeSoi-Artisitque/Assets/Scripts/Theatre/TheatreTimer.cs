﻿using UnityEngine;
using System.Collections;

public class TheatreTimer : MonoBehaviour {
    #region Members
    public int m_ElapsedTime = 0;
    public const int c_MaxTime = 2 * 60 + 1;

    TextMesh m_Display;

    string p_TimeToDisplay {
        get {
            int remainingTime = c_MaxTime - m_ElapsedTime;
            int remainingMinutes = remainingTime / 60;
            remainingTime -= remainingMinutes * 60;

            return string.Format("{0}:{1}", remainingMinutes.ToString(), remainingTime.ToString("00"));
        }
    }
    #endregion

    void Start() {
        m_Display = this.transform.FindChild("TimerDisplay").GetComponent<TextMesh>();
        this.StartCoroutine("TickTimer");
    }

    public IEnumerator TickTimer() {
        while (m_ElapsedTime < c_MaxTime) {
            ++m_ElapsedTime;
            m_Display.text = p_TimeToDisplay;

            yield return new WaitForSeconds(1.0f);
        }
    }
}
