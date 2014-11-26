using UnityEngine;
using System.Collections;

public class ToolType {
    public enum e_DestinationDepths {
        FIRST_DEPTH = 0,
        SECOND_DEPTH,
        THIRD_DEPTH,
        FOURTH_DEPTH,

        COUNT
    }

    #region Members
    public e_DestinationDepths m_DestinationDepth;
    public string m_RessourceName;
    #endregion
}
