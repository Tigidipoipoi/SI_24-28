using UnityEngine;
using System.Collections;

public class DragNClamp : MonoBehaviour {
    #region Methods
    public int c_ToolsToAutoValidate = 15;
    public string description = "";

    bool m_Dragging = false;
    float distance;
    int[] m_DepthMasks = new int[4];
    float[] m_ClampedYPosition = new float[4];
    float m_RendererSizeY;

    [HideInInspector]
    public ToolSlot m_SlotScript;
    ToolType m_ToolType;
    SceneValidation m_SceneValidationScript;

    Renderer m_Renderer;
    #endregion

    void Start() {
        for (int i = 0; i < 4; ++i) {
            m_DepthMasks[i] = LayerMask.GetMask("TheatreDepth" + (i + 1).ToString());
        }

        m_RendererSizeY = this.GetComponent<Renderer>().bounds.size.y / 2;

        m_ClampedYPosition[0] = -3f + m_RendererSizeY;
        m_ClampedYPosition[1] = -1.73f + m_RendererSizeY;
        m_ClampedYPosition[2] = -0.49f + m_RendererSizeY;
        m_ClampedYPosition[3] = 5f - m_RendererSizeY;

        m_ToolType = this.GetComponent<ToolType>();
        m_SceneValidationScript = GameObject.Find("Timer").GetComponent<SceneValidation>();

        m_Renderer = this.GetComponent<Renderer>();
    }

    void OnMouseDown() {
        InitDrag();
    }

    void OnMouseUp() {
        ExitDrag();
    }


    public void InitDrag() {
        distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);

        m_Dragging = true;
    }

    public void ExitDrag() {
        m_Dragging = false;

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

        if (m_SceneValidationScript.m_ToolInstanceCount >= c_ToolsToAutoValidate) {
            m_SceneValidationScript.ValidateScene();
        }
    }

    void OnMouseExit() {
        if (!m_Dragging
            && this.transform.position.y < m_ClampedYPosition[0] - 0.1f) {
            SelfDestroy();
        }
    }

    void Update() {
        DisplayHandling();

        if (m_Dragging) {
            Ray ray = new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(0f, 0f, 1f));
            RaycastHit hit;

            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = 0;

            for (int i = 0; i < 4; ++i) {
                if (Physics.Raycast(ray, out hit, distance, m_DepthMasks[i])) {
                    rayPoint.y = m_ClampedYPosition[i];
                }
            }

            this.transform.position = rayPoint;
        }
    }

    public void SelfDestroy() {
        Destroy(this.gameObject);
        m_SlotScript.m_InstanciatedObjects.Remove(this);
        --m_SlotScript.p_SimultaneousInstances;
    }

    void DisplayHandling() {
        m_Renderer.enabled = this.transform.position.y >= m_ClampedYPosition[0] - 0.1f;
    }

    public float GetThresholdPosY() {
        return m_ClampedYPosition[0];
    }
}
