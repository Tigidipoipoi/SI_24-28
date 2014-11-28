using UnityEngine;
using System.Collections;

public class CurtainTransition : MonoBehaviour {
    #region Members
    readonly Vector3 c_HiddenPosition = new Vector3(-0.2f, 9.1f, 0f);
    readonly Vector3 c_VisiblePosition = new Vector3(-0.2f, 1f, 0f);
    const float c_FadeTime = 0.75f;
    const float c_DisplayTime = 0.5f;
    bool m_IsVisible;
    #endregion

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            this.StartCoroutine("HandleDisplay");
        }
    }

    public IEnumerator HandleDisplay() {
        int elapsedTime = 0;
        while (Vector3.Distance(this.transform.position, c_VisiblePosition) > 0f + 0.00001f) {
            this.transform.position = elapsedTime >= c_FadeTime * 1000
                ? c_VisiblePosition
                : Vector3.Lerp(this.transform.position, c_VisiblePosition, 3f / c_FadeTime * Time.deltaTime);

            elapsedTime += (int)(Time.deltaTime * 1000);

            yield return null;
        }

        yield return new WaitForSeconds(c_DisplayTime);

        elapsedTime = 0;
        while (Vector3.Distance(this.transform.position, c_HiddenPosition) > 0f + 0.00001f) {
            this.transform.position = elapsedTime >= c_FadeTime * 1000
                ? c_HiddenPosition
                : Vector3.Lerp(this.transform.position, c_HiddenPosition, 3f / c_FadeTime * Time.deltaTime);

            elapsedTime += (int)(Time.deltaTime * 1000);

            yield return null;
        }
    }
}
