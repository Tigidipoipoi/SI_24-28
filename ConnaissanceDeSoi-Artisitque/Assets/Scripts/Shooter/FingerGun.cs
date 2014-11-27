using UnityEngine;
using System.Collections;

public class FingerGun : MonoBehaviour {
    const float c_FixedZPosition = -3f;
    public float m_XOffset = 0f;
    public float m_YOffset = 0f;
    public Texture2D m_CursorTexture;
    public CursorMode m_CursorMode = CursorMode.Auto;

    void Start() {
        if (m_CursorTexture == null)
            m_CursorTexture = Resources.Load("Textures/Shooter/Dayum") as Texture2D;
        Cursor.SetCursor(m_CursorTexture, Vector2.zero, m_CursorMode);

        Vector3 rendererBounds = this.GetComponent<Renderer>().bounds.size;
        m_XOffset = rendererBounds.x / 2 + 0.1f;
        m_YOffset = rendererBounds.y / 2 + 0.1f;


    }

    void Update() {
        Vector3 mousePositionFixed = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePositionFixed.x += m_XOffset;
        mousePositionFixed.y -= m_YOffset;
        mousePositionFixed.z = c_FixedZPosition;
        this.transform.position = mousePositionFixed;
    }
}
