using UnityEngine;
using System.Collections;

public class ToolSlot : MonoBehaviour {
    public GameObject m_ToolType;
    Vector3 m_SpawnPosition {
        get {
            return new Vector3(this.transform.position.x, this.transform.position.y, -0.01f);
        }
    }

    void OnMouseEnter() {
        Instantiate(m_ToolType, m_SpawnPosition, Quaternion.identity);
    }
}
