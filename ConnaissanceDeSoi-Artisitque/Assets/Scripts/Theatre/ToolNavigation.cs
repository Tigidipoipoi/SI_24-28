using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToolNavigation : MonoBehaviour {
    #region Members
    public static readonly string c_LeftArrowName = "LeftArrow";
    public static readonly string c_RightArrowName = "RightArrow";

    const float c_SpaceBetweenSlots = 1.5f;
    const float c_MinXLeftSlotDisplay = -5.65f;
    const float c_MaxXLeftSlotDisplay = -1.15f;

    const float c_FixedYSlot = -4f;
    const float c_FixedZSlot = 0f;

    public List<GameObject> m_ToolSlots;
    #endregion

    void Start() {
        PopulateSlots();
    }

    void PopulateSlots() {
        m_ToolSlots = new List<GameObject>();
        GameObject toolsInitParent = GameObject.Find("ToolSlots");

        for (int i = 0; i < toolsInitParent.transform.childCount; ++i) {
            m_ToolSlots.Add(toolsInitParent.transform.GetChild(i).gameObject);
        }

        SetSlotsPosition(moveToRight: true, initializing: true);
    }

    public void DetermineSlotsDisplay() {
        for (int i = 0; i < m_ToolSlots.Count; ++i) {
            float currentXPosition = m_ToolSlots[i].transform.position.x;
            m_ToolSlots[i].SetActive((currentXPosition >= c_MinXLeftSlotDisplay
                                        && currentXPosition <= c_MaxXLeftSlotDisplay)
                                    || (currentXPosition <= -c_MinXLeftSlotDisplay
                                        && currentXPosition >= -c_MaxXLeftSlotDisplay));
        }
    }

    public void SetSlotsPosition(bool moveToRight, bool initializing = false) {
        Vector3 newPosition = initializing
            ? new Vector3(c_MinXLeftSlotDisplay - c_SpaceBetweenSlots, c_FixedYSlot, c_FixedZSlot)
            : m_ToolSlots[0].transform.position;
        int directionCoef = moveToRight ? 1 : -1;

        if (m_ToolSlots[0].transform.position.x > c_MinXLeftSlotDisplay - 0.1f
            && moveToRight
            && !initializing) {
            Debug.Log(string.Format("moveToRight : Nope ({0} > {1})", m_ToolSlots[0].transform.position.x, c_MinXLeftSlotDisplay - 0.1f));
        }
        else if (m_ToolSlots[m_ToolSlots.Count - 1].transform.position.x < -c_MinXLeftSlotDisplay + 0.1f
            && !moveToRight
            && !initializing) {
            Debug.Log(string.Format("moveToLeft : Nope ({0} < {1})", m_ToolSlots[m_ToolSlots.Count - 1].transform.position.x, -c_MinXLeftSlotDisplay + 0.1f));
        }
        else {
            for (int i = 0; i < m_ToolSlots.Count; ++i) {
                if (!initializing) {
                    newPosition.x = m_ToolSlots[i].transform.position.x;
                }

                // Handles the slot next to timer
                if (newPosition.x >= (directionCoef * c_MaxXLeftSlotDisplay) - 0.1f
                    && newPosition.x <= (directionCoef * c_MaxXLeftSlotDisplay) + 0.1f) {
                    newPosition.x = -directionCoef * c_MaxXLeftSlotDisplay;
                }
                // Handles the slot next to the slot next to timer
                else if (newPosition.x >= (directionCoef * c_MaxXLeftSlotDisplay) - c_SpaceBetweenSlots - 0.1f
                    && newPosition.x <= (directionCoef * c_MaxXLeftSlotDisplay) + c_SpaceBetweenSlots + 0.1f) {
                    newPosition.x = directionCoef * c_MaxXLeftSlotDisplay;
                }
                else {
                    newPosition.x += directionCoef * c_SpaceBetweenSlots;
                }

                m_ToolSlots[i].transform.position = newPosition;
            }

            DetermineSlotsDisplay();
        }

    }
}
