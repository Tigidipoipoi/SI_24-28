using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ToolSlot : MonoBehaviour {
    #region Members
    public int m_MaxSimultaneousInstances = 3;
    public GameObject m_ToolPrefab;

    int m_SimultaneousInstances = 0;
    public int p_SimultaneousInstances {
        get {
            return m_SimultaneousInstances;
        }
        set {
            if (m_SceneValidationScript != null) {
                if (value > m_SimultaneousInstances) {
                    ++m_SceneValidationScript.m_ToolInstanceCount;
                }
                else {
                    --m_SceneValidationScript.m_ToolInstanceCount;
                }
            }

            m_SimultaneousInstances = value;
        }
    }

    Vector3 m_SpawnPosition {
        get {
            return new Vector3(this.transform.position.x, this.transform.position.y, 2f);
        }
    }
    SceneValidation m_SceneValidationScript;

    [HideInInspector]
    public List<DragNClamp> m_InstanciatedObjects = new List<DragNClamp>();
    #endregion

    void Start() {
        if (m_ToolPrefab == null) {
            m_ToolPrefab = Resources.Load("Prefabs/Theatre/ToolTypes/ToolTypeDefault") as GameObject;
        }

        m_SceneValidationScript = GameObject.Find("Timer").GetComponent<SceneValidation>();
    }

    void OnMouseEnter() {
        if (p_SimultaneousInstances < m_MaxSimultaneousInstances) {
            GameObject newInstance = Instantiate(m_ToolPrefab, m_SpawnPosition, Quaternion.identity) as GameObject;
            m_InstanciatedObjects.Add(newInstance.GetComponent<DragNClamp>());
            newInstance.GetComponent<DragNClamp>().m_SlotScript = this;
            ++p_SimultaneousInstances;
        }
    }

    void OnMouseDown() {
        DragNClamp lastInstance;
        if (m_InstanciatedObjects.Count > 0
            && (lastInstance = m_InstanciatedObjects.Last()) != null) {
            if (lastInstance.transform.position.y < lastInstance.GetThresholdPosY() - 0.1f) {
                lastInstance.InitDrag();
            }
        }
    }

    void OnMouseUp() {
        DragNClamp lastInstance;
        if (m_InstanciatedObjects.Count > 0
            && (lastInstance = m_InstanciatedObjects.Last()) != null) {
            lastInstance.ExitDrag();
        }
    }
}
