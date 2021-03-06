﻿using UnityEngine;
using System.Collections;

public class TextLife : MonoBehaviour {
    #region Members
    [HideInInspector]
    public Word m_Word;

    TextMesh m_TextMesh;

    Vector3 m_ResetPosition;

    TextGeneration m_ParentGenerator;
    bool m_SpwanRight;
    #endregion

    void Start() {
        m_ParentGenerator = this.transform.parent.parent.gameObject.GetComponent<TextGeneration>();

        m_SpwanRight = m_ParentGenerator.c_WordSpeed < 0f;

        m_TextMesh = this.transform.FindChild("Text").GetComponent<TextMesh>();
        m_TextMesh.text = m_Word.m_Text;

        float spawnXPosition = 0f;
        int spawnCoef = m_SpwanRight ? -1 : 1;
        switch (m_Word.m_Category) {
            case Word.e_WordCategories.SHORT_WORD:
                spawnXPosition = spawnCoef * Word.c_MinXLeftShort;
                break;
            case Word.e_WordCategories.MEDIUM_WORD:
                spawnXPosition = spawnCoef * Word.c_MinXLeftMedium;
                break;
            case Word.e_WordCategories.LONG_WORD:
                spawnXPosition = spawnCoef * Word.c_MinXLeftLong;
                break;
        }
        m_ResetPosition = new Vector3(spawnXPosition, this.transform.position.y, this.transform.position.z);
        this.transform.position = m_ResetPosition;
    }

    public IEnumerator Move() {
        float desappearXPosition = 0f;
        int spawnCoef = m_SpwanRight ? 1 : -1;

        switch (m_Word.m_Category) {
            case Word.e_WordCategories.SHORT_WORD:
                desappearXPosition = spawnCoef * Word.c_MinXLeftShort;
                break;
            case Word.e_WordCategories.MEDIUM_WORD:
                desappearXPosition = spawnCoef * Word.c_MinXLeftMedium;
                break;
            case Word.e_WordCategories.LONG_WORD:
                desappearXPosition = spawnCoef * Word.c_MinXLeftLong;
                break;
        }

        while ((!m_SpwanRight
                    && this.transform.position.x <= desappearXPosition)
                || (m_SpwanRight
                    && this.transform.position.x >= desappearXPosition)) {
            this.transform.Translate(new Vector3(m_ParentGenerator.c_WordSpeed, 0, 0) * Time.deltaTime);
            yield return null;
        }

        m_ParentGenerator.ReturnToQueue(this.gameObject);
        this.transform.position = m_ResetPosition;
    }

    void OnMouseDown() {
        GameObject.Destroy(this.gameObject);
        ++m_ParentGenerator.m_StaticAttributes.m_DestroyedWordCount;

        Camera.main.GetComponent<CameraShake>().ScreenShake();
    }

    public float GetTimeToWait(float timeBetweenSpawns) {
        float size = 0f;
        switch (m_Word.m_Category) {
            case Word.e_WordCategories.SHORT_WORD:
                size = Word.c_ShortSize;
                break;
            case Word.e_WordCategories.MEDIUM_WORD:
                size = Word.c_MediumSize;
                break;
            case Word.e_WordCategories.LONG_WORD:
                size = Word.c_LongSize;
                break;
        }
        float timeToWait = size / Mathf.Abs(m_ParentGenerator.c_WordSpeed) + timeBetweenSpawns;

        return timeToWait;
    }
}
