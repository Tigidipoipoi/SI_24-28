using UnityEngine;
using System.Collections;

public class Word {
    public enum e_WordCategories {
        SHORT_WORD = 0,
        MEDIUM_WORD,
        LONG_WORD,

        COUNT
    }

    public static readonly float c_MinXLeftShort = -7.1f;
    public static readonly float c_MinXLeftMedium = -7.4f;
    public static readonly float c_MinXLeftLong = -8f;
    public static readonly float c_ShortSize = 2f;
    public static readonly float c_MediumSize = 2.6f;
    public static readonly float c_LongSize = 3.75f;

    public string m_Text;
    public e_WordCategories m_Category;
    public bool m_IsArtRelated;

    public Word(string text, e_WordCategories category, bool isArtRelated) {
        m_Text = text;
        m_Category = category == e_WordCategories.COUNT
            ? e_WordCategories.LONG_WORD
            : category;
        m_IsArtRelated = isArtRelated;
    }
}
