using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TextGenerationMaster : MonoBehaviour {
    public int m_DestroyedWordCount = 0;
    public int m_DestroyedWordsToEnd = 20;
    public float m_RNGInitTime = 3f;
    int m_HiddenScore = 0;

    public void ComputeHiddenScore() {
        if (m_HiddenScore > 0)
            return;

        List<Word> remainingWordsList = GetRemainingWords();
        float remainingArtisticWords = remainingWordsList.Where(x => x.m_IsArtRelated).Count();

        m_HiddenScore = Mathf.RoundToInt(remainingArtisticWords / remainingWordsList.Count * 100);
        Debug.Log(string.Format("GameOver : {0}", m_HiddenScore.ToString()));
    }

    List<Word> GetRemainingWords() {
        List<Word> remainingWords = new List<Word>();
        int shootingLinesCount = this.transform.childCount;

        for (int i = 0; i < shootingLinesCount; ++i) {
            Transform child = this.transform.GetChild(i);

            if (child.name == "ShootingLine") {
                remainingWords.AddRange(child
                    .GetComponent<TextGeneration>().m_WordsQueue
                    .Select(x => x.GetComponent<TextLife>().m_Word));
            }
        }

        return remainingWords;
    }
}
