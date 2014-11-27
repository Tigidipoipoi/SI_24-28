using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigationArrow : MonoBehaviour {
    #region Members
    ToolNavigation m_NavigationScript;
    #endregion

    void Start() {
        m_NavigationScript = this.transform.parent.parent.GetComponent<ToolNavigation>();
    }

    void OnMouseDown() {
        // TODO : 
        if (this.name == ToolNavigation.c_LeftArrowName) {
            m_NavigationScript.SetSlotsPosition(moveToRight: true);
        }
        else if (this.name == ToolNavigation.c_RightArrowName) {
            m_NavigationScript.SetSlotsPosition(moveToRight: false);
        }
        else {
            Debug.LogError("NavigationArrow::OnMouseDown => Shoudln't be called now !");
        }
    }
}
