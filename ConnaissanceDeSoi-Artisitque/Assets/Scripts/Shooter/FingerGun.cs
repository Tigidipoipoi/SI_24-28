using UnityEngine;
using System.Collections;

public class FingerGun : MonoBehaviour {
    const float c_FixedZPosition = -3f;
    public float m_XOffset = 0f;
    public float m_YOffset = 0f;
    public Texture2D m_CursorTexture;
    public CursorMode m_CursorMode = CursorMode.Auto;

    void Update() {
        Vector3 mousePositionFixed = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePositionFixed.x += m_XOffset;
        mousePositionFixed.y -= m_YOffset;
        mousePositionFixed.z = c_FixedZPosition;
        this.transform.position = mousePositionFixed;
    }
}
