﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneValidation : MonoBehaviour {
    #region Members
    public int c_MinimumToolsToValidate = 5;

    //[HideInInspector]
    public int m_ToolInstanceCount = 0;

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

    public void ValidateScene() {
        if (m_ToolInstanceCount >= c_MinimumToolsToValidate) {
            Debug.Log("Valider");

            CleanScene();
        }
    }

    void CleanScene() {
        for (int i = 0; i < m_ToolSlots.Count; ++i) {
            int instanceCount = m_ToolSlots[i].m_InstanciatedObjects.Count;
            for (int j = 0; j < instanceCount; ++j) {
                m_ToolSlots[i].m_InstanciatedObjects[0].SelfDestroy();
            }
        }
    }
}
