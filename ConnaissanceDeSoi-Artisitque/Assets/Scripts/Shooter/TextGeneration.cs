using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextGeneration : MonoBehaviour {
    #region Members
    [HideInInspector]
    public TextGenerationMaster m_StaticAttributes;
    float c_TimeBetweenSpawns = 0.7f;
    int c_MaxWordInALine = 3;

    public Queue<GameObject> m_WordsQueue;
    GameObject m_InvokedWordsContainer;
    GameObject m_InactiveWordsContainer;
    List<Word> m_WordList;
    #endregion

    void Start() {
        // Tweeking
        m_StaticAttributes = this.transform.parent.GetComponent<TextGenerationMaster>();

        PopulateWordList();

        m_WordsQueue = new Queue<GameObject>(m_StaticAttributes.m_DestroyedWordsToEnd);
        m_InvokedWordsContainer = transform.FindChild("Spawn").gameObject;
        m_InactiveWordsContainer = transform.FindChild("Queue").gameObject;

        for (int i = 0; i < m_WordList.Count; ++i) {
            string resourceToLoad = "Prefabs/Shooter/WordsToShoot/";
            switch (m_WordList[i].m_Category) {
                case Word.e_WordCategories.SHORT_WORD:
                    resourceToLoad += "SmallWordToShoot";
                    break;
                case Word.e_WordCategories.MEDIUM_WORD:
                    resourceToLoad += "MediumWordToShoot";
                    break;
                case Word.e_WordCategories.LONG_WORD:
                    resourceToLoad += "LongWordToShoot";
                    break;
            }

            Object prefab = Resources.Load(resourceToLoad);
            GameObject wordToShoot = GameObject.Instantiate(prefab) as GameObject;

            wordToShoot.GetComponent<TextLife>().m_Word = m_WordList[i];
            wordToShoot.transform.parent = m_InactiveWordsContainer.transform;
            wordToShoot.transform.position = m_InactiveWordsContainer.transform.position;
            wordToShoot.SetActive(false);

            m_WordsQueue.Enqueue(wordToShoot);
        }

        this.StartCoroutine("InvokeWords");
    }

    void PopulateWordList() {
        WordList.PopulateWords();
        m_WordList = new List<Word>();
        for (int i = 0; i < 13; ++i) {
            Word rngWord = WordList.GetAWord();
            if (rngWord != null)
                m_WordList.Add(rngWord);
        }
    }

    IEnumerator InvokeWords() {
        // Shift 1st spawn
        float rngInitWait = Random.Range(0f, m_StaticAttributes.m_RNGInitTime);
        yield return new WaitForSeconds(rngInitWait);

        while (m_StaticAttributes.m_DestroyedWordCount < m_StaticAttributes.m_DestroyedWordsToEnd) {
            if (m_InvokedWordsContainer.transform.childCount < c_MaxWordInALine) {
                GameObject invokedWord = m_WordsQueue.Dequeue();
                TextLife invokedWordScript = invokedWord.GetComponent<TextLife>();
                invokedWord.transform.parent = m_InvokedWordsContainer.transform;
                invokedWord.SetActive(true);

                // Waiting for invokedWordScript to be set
                yield return null;

                invokedWordScript.StartCoroutine("Move");
                float timeToWait = invokedWordScript.GetTimeToWait(c_TimeBetweenSpawns);
                yield return new WaitForSeconds(timeToWait);
            }

            yield return null;
        }

        // Launch GameOver
        m_StaticAttributes.ComputeHiddenScore();
    }

    public void ReturnToQueue(GameObject wordToReturn) {
        m_WordsQueue.Enqueue(wordToReturn);
        wordToReturn.transform.parent = m_InactiveWordsContainer.transform;
        wordToReturn.SetActive(false);
    }
}
