using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneValidation : MonoBehaviour {
    #region Members
    public int c_MinimumToolsToValidate = 5;

    List<ToolSlot> m_ToolSlots = new List<ToolSlot>();
    #endregion

    void Start() {
        GameObject toolSlotContainer = GameObject.Find("ToolSlots");
        int toolSlotCount = toolSlotContainer.transform.childCount;

        for (int i = 0; i < toolSlotCount; ++i) {
            m_ToolSlots.Add(toolSlotContainer.transform.GetChild(i).GetComponent<ToolSlot>());
        }
    }

    void OnMouseDown() {
        ValidateScene();
    }

    void ValidateScene() {
        int toolInstances = 0;
        for (int i = 0; i < m_ToolSlots.Count; ++i) {
            toolInstances += m_ToolSlots[i].m_SimultaneousInstances;
        }

        if (toolInstances >= c_MinimumToolsToValidate) {
            Debug.Log("Valider");
        }
        else {
            Debug.Log(toolInstances.ToString());
        }
    }
}
