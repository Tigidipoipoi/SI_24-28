using UnityEngine;
using System.Collections;

public class DragClamp : MonoBehaviour {
    #region Methods
    private bool dragging = false;
    private float distance;
    public string description = "";
    int[] m_DepthMasks = new int[4];
    float[] m_ClampedYPosition = new float[4];
    #endregion

    void Start() {
        for (int i = 0; i < 4; ++i) {
            m_DepthMasks[i] = LayerMask.GetMask("TheatreDepth" + (i + 1).ToString());
        }

        m_ClampedYPosition[0] = -2.23f;
        m_ClampedYPosition[1] = -0.23f;
        m_ClampedYPosition[2] = 1.78f;
        m_ClampedYPosition[3] = 4.2f;
    }

    void OnMouseDown() {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        dragging = true;
    }

    void OnMouseUp() {
        dragging = false;

        if (transform.position.y < m_ClampedYPosition[0])
            Destroy(this.gameObject);
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
                }
            }

            transform.position = rayPoint;
        }
    }
}
