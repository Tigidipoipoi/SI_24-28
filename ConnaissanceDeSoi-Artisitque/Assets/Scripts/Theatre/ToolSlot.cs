using UnityEngine;
using System.Collections;

public class ToolSlot : MonoBehaviour {
    public int m_MaxSimultaneousInstances = 3;
    [HideInInspector]
    public int m_SimultaneousInstances = 0;
    public GameObject m_ToolPrefab;

    Vector3 m_SpawnPosition {
        get {
            return new Vector3(this.transform.position.x, this.transform.position.y, -0.01f);
        }
    }

    void Start() {
        if (m_ToolPrefab == null) {
            m_ToolPrefab = Resources.Load("Prefabs/Theatre/ToolTypes/ToolTypeDefault") as GameObject;
        }
    }

    void OnMouseEnter() {
        if (m_SimultaneousInstances < m_MaxSimultaneousInstances) {
            GameObject newInstance = Instantiate(m_ToolPrefab, m_SpawnPosition, Quaternion.identity) as GameObject;
            newInstance.transform.parent = this.transform;
            ++m_SimultaneousInstances;
        }
    }
}
