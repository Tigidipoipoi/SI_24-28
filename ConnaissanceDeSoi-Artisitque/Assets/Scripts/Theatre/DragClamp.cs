using UnityEngine;
using System.Collections;

public class DragClamp : MonoBehaviour {
    #region Methods
    private bool dragging = false;
    private float distance;
    public string description = "";
    int[] m_DepthMasks = new int[4];
    float[] m_ClampedYPosition = new float[4];
    ToolType m_ToolType;
    float m_RendererSizeY;
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
    }

    void OnMouseDown() {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        dragging = true;
    }

    void OnMouseUp() {
        dragging = false;

        if (transform.position.y < m_ClampedYPosition[0]) {
            Destroy(this.gameObject);
        }

        if (!m_ToolType.m_IsCeilingStuff) {
            if (transform.position.y > m_ClampedYPosition[3] - 0.1f
                && transform.position.y < m_ClampedYPosition[3] + 0.1f) {
                Destroy(this.gameObject);
            }
        }
        else {
            if (transform.position.y <= m_ClampedYPosition[3] - 0.1f) {
                Destroy(this.gameObject);
            }
        }
    }

    void OnMouseExit() {
        if (!dragging
            && transform.position.y < m_ClampedYPosition[0])
            Destroy(this.gameObject);
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

            transform.position = rayPoint;
        }
    }
}
