using UnityEngine;
using System.Collections;

public class DragClamp : MonoBehaviour {
    #region Methods
    private bool dragging = false;
    private float distance;
    public string description = "";
    int[] m_DepthMasks = new int[4];
    float[] m_ClampedYPosition = new float[4];
    float m_RendererSizeY;

    ToolType m_ToolType;
    ToolSlot m_ParentScript;
    #endregion

    void Start() {
        for (int i = 0; i < 4; ++i) {
            m_DepthMasks[i] = LayerMask.GetMask("TheatreDepth" + (i + 1).ToString());
        }

        m_RendererSizeY = this.GetComponent<MeshRenderer>().bounds.size.y / 2;

        m_ClampedYPosition[0] = -3f + m_RendererSizeY;
        m_ClampedYPosition[1] = -1.73f + m_RendererSizeY;
        m_ClampedYPosition[2] = -0.49f + m_RendererSizeY;
        m_ClampedYPosition[3] = 5f - m_RendererSizeY;

        m_ToolType = this.GetComponent<ToolType>();
        m_ParentScript = this.transform.parent.GetComponent<ToolSlot>();
    }

    void OnMouseDown() {
        distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);

        dragging = true;
    }

    void OnMouseUp() {
        dragging = false;

        if (this.transform.position.y < m_ClampedYPosition[0] - 0.1f) {
            SelfDestroy();
        }

        if (!m_ToolType.m_IsCeilingStuff) {
            if (this.transform.position.y > m_ClampedYPosition[3] - 0.1f
                && this.transform.position.y < m_ClampedYPosition[3] + 0.1f) {
                SelfDestroy();
            }
        }
        else {
            if (this.transform.position.y <= m_ClampedYPosition[3] - 0.1f) {
                SelfDestroy();
            }
        }
    }

    void OnMouseExit() {
        if (!dragging
            && this.transform.position.y < m_ClampedYPosition[0] - 0.1f) {
            SelfDestroy();
        }
    }

    void Update() {
        if (dragging) {
            Ray ray = new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(0f, 0f, 1f));
            RaycastHit hit;

            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = 0;

            for (int i = 0; i < 4; ++i) {
                if (Physics.Raycast(ray, out hit, distance, m_DepthMasks[i])) {
                    rayPoint.y = m_ClampedYPosition[i];

                    if (!m_ToolType.m_IsCeilingStuff
                        && i == 3) {
                        // Add red filter
                    }
                }
            }

            this.transform.position = rayPoint;
        }
    }

    void SelfDestroy() {
        Destroy(this.gameObject);
        --m_ParentScript.m_SimultaneousInstances;
    }
}
