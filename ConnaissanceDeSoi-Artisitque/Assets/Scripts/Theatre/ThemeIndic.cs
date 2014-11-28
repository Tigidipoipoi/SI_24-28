using UnityEngine;
using System.Collections;

public class ThemeIndic : MonoBehaviour {
    #region Members
    TextMesh m_TextMesh;
    readonly Vector3 c_HiddenPosition = new Vector3(0f, 6.5f, 0f);
    readonly Vector3 c_VisiblePosition = new Vector3(0f, 2.95f, 0f);
    const float c_FadeTime = 1f;
    const float c_DisplayTime = 2f;
    bool m_IsVisible;
    #endregion

    void Start() {
        m_TextMesh = this.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>();

        this.StartCoroutine("HandleDisplay");
    }

    public IEnumerator HandleDisplay() {
        this.SetTheme(ThemeList.GetATheme());

        int elapsedTime = 0;
        while (elapsedTime < c_FadeTime * 1000) {
            this.transform.position = Vector3.Lerp(this.transform.position, c_VisiblePosition, 3f / c_FadeTime * Time.deltaTime);

            elapsedTime += (int)(Time.deltaTime * 1000);

            yield return null;
        }

        yield return new WaitForSeconds(c_DisplayTime);

        elapsedTime = 0;
        while (elapsedTime < c_FadeTime * 1000) {
            this.transform.position = Vector3.Lerp(this.transform.position, c_HiddenPosition, 3f / c_FadeTime * Time.deltaTime);

            elapsedTime += (int)(Time.deltaTime * 1000);

            yield return null;
        }
    }

    public void SetTheme(string theme) {
        m_TextMesh.text = theme;
    }
}
