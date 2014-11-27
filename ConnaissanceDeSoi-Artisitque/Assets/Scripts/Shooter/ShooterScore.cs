using UnityEngine;
using System.Collections;

public class ShooterScore : MonoBehaviour {
    int m_Score = 0;
    int p_Score {
        get {
            return m_Score;
        }
        set {
            m_Score = value;
            m_TextMesh.text = (30 - m_Score).ToString("000");
        }
    }
    TextMesh m_TextMesh;
    TextGenerationMaster m_GeneratorsStaticAttributes;

    void Start() {
        m_GeneratorsStaticAttributes = GameObject.Find("ShootingLines").GetComponent<TextGenerationMaster>();
        m_TextMesh = this.GetComponent<TextMesh>();
        p_Score = 0;
    }

    void Update() {
        p_Score = m_GeneratorsStaticAttributes.m_DestroyedWordCount;
    }
}
