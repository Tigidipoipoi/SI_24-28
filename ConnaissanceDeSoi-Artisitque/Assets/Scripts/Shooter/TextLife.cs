using UnityEngine;
using System.Collections;

public class TextLife : MonoBehaviour {
    #region Members
    public float m_WordSpeed = 1.5f;
    public string m_Text;

    TextMesh m_TextMesh;
    float m_ColliderXSize;

    float m_MaxXRightComputed {
        get {
            return c_MaxXRight + m_ColliderXSize;
        }
    }
    const float c_MaxXRight = 7.0f;
    const float c_MinXLeft = -6.5f;
    Vector3 m_ResetPosition;

    TextGeneration m_ParentGenerator;
    #endregion

    void Start() {
        m_TextMesh = this.GetComponent<TextMesh>();
        this.StartCoroutine("Move");
        m_TextMesh.text = m_Text;
        this.gameObject.AddComponent<BoxCollider2D>();
        m_ResetPosition = new Vector3(c_MinXLeft, this.transform.position.y, this.transform.position.z);
        m_ColliderXSize = this.GetComponent<BoxCollider2D>().size.x;

        m_ParentGenerator = this.transform.parent.parent.gameObject.GetComponent<TextGeneration>();
    }

    IEnumerator Move() {
        while (true) {
            if (this.transform.position.x > m_MaxXRightComputed) {
                m_ParentGenerator.ReturnToQueue(this.gameObject);
                this.transform.position = m_ResetPosition;
            }

            this.transform.Translate(new Vector3(m_WordSpeed, 0, 0) * Time.deltaTime);
            yield return null;
        }
    }

    void OnMouseDown() {
        GameObject.Destroy(this.gameObject);
        ++TextGeneration.s_DestroyedWord;
    }

    public float GetTimeToWait(float timeBetweenSpawns) {
        float timeToWait = m_ColliderXSize / m_WordSpeed + timeBetweenSpawns;

        return timeToWait;
    }
}
