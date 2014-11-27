using UnityEngine;
using System.Collections;

public class ToolSlot : MonoBehaviour {
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
        Instantiate(m_ToolPrefab, m_SpawnPosition, Quaternion.identity);
    }
}
