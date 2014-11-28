using UnityEngine;
using System.Collections;

public class SceneData {
    #region Members
    public int m_ToolCount;

    public int m_StartTime;
    public int m_EndTime;
    public int p_CreationTime {
        get {
            if (m_EndTime < m_StartTime) {
                return m_StartTime - m_EndTime;
            }
            else {
                Debug.LogError(string.Format("SceneData::p_CreationTime => shouldn't be called ! {0} / {1}", m_EndTime, m_StartTime));
                return -1;
            }
        }
    }
    #endregion

    public SceneData()
        : this(0) { }

    public SceneData(int startTime) {
        m_StartTime = startTime;
    }

    public int ComputeScore() {
        int score = 0;

        score += m_ToolCount > 14
            ? m_ToolCount > 15
                ? m_ToolCount > 17
                    ? 20
                    : 10
                : 5
            : 0;

        score += p_CreationTime > 15
            ? p_CreationTime > 30
                ? p_CreationTime > 60
                    ? 15
                    : 10
                : 5
            : 0;

        return score;
    }
}
