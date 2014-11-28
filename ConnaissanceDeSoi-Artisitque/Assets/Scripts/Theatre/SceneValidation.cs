using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SceneValidation : MonoBehaviour {
    #region Members
    const int c_MinimumToolsToValidate = 5;

    [HideInInspector]
    public int m_ToolInstanceCount = 0;
    [HideInInspector]
    public int m_ValidatedSceneCount = 0;

    int m_HiddenScore = 0;

    List<ToolSlot> m_ToolSlots = new List<ToolSlot>();
    public List<SceneData> m_SceneDataList = new List<SceneData>();
    
    TheatreTimer m_TimerScript;
    ThemeIndic m_ThemeIndic;
    #endregion

    void Start() {
        GameObject toolSlotContainer = GameObject.Find("ToolSlots");
        int toolSlotCount = toolSlotContainer.transform.childCount;

        for (int i = 0; i < toolSlotCount; ++i) {
            m_ToolSlots.Add(toolSlotContainer.transform.GetChild(i).GetComponent<ToolSlot>());
        }

        m_TimerScript = this.GetComponent<TheatreTimer>();

        m_SceneDataList.Add(new SceneData(0));

        m_ThemeIndic = GameObject.Find("ThemeIndic").GetComponent<ThemeIndic>();
    }

    void OnMouseDown() {
        ValidateScene();
    }

    public void ValidateScene() {
        if (m_ToolInstanceCount >= c_MinimumToolsToValidate) {
            Debug.Log("Valider");
            ++m_ValidatedSceneCount;

            if (m_TimerScript.m_ElapsedTime < TheatreTimer.c_MaxTime) {
                CleanScene();
            }
            else {
                ComputeHiddenScore();
            }
        }
    }

    void CleanScene() {
        for (int i = 0; i < m_ToolSlots.Count; ++i) {
            int instanceCount = m_ToolSlots[i].m_InstanciatedObjects.Count;
            SceneData validatedScene = m_SceneDataList.Last();
            validatedScene.m_ToolCount = instanceCount;
            validatedScene.m_EndTime = m_TimerScript.m_ElapsedTime;

            for (int j = 0; j < instanceCount; ++j) {
                m_ToolSlots[i].m_InstanciatedObjects[0].SelfDestroy();
            }
        }
        Debug.Log(m_TimerScript.m_ElapsedTime.ToString());
        m_SceneDataList.Add(new SceneData(m_TimerScript.m_ElapsedTime));

        m_ThemeIndic.SetTheme("Azerty");
        m_ThemeIndic.StartCoroutine("HandleDisplay");
    }

    void ComputeHiddenScore() {
        foreach (SceneData scene in m_SceneDataList) {
            m_HiddenScore += scene.ComputeScore();
        }

        m_HiddenScore += m_SceneDataList.Count > 2
            ? m_SceneDataList.Count > 5
                ? m_SceneDataList.Count > 8
                    ? 30
                    : 20
                : 10
            : 0;

        Debug.Log(string.Format("Gameover : {0}", m_HiddenScore.ToString()));
    }
}
