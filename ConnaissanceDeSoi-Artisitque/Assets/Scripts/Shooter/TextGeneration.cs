using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextGeneration : MonoBehaviour {
    #region Members
    public static int s_DestroyedWord = 0;
    public static int s_DestroyedWordsToEnd = 21;

    public float c_TimeBetweenSpawns = 0.5f;
    public int c_MaxWordInALine = 3;

    Queue<GameObject> m_WordsQueue;
    GameObject m_InvokedWordsContainer;
    GameObject m_InactiveWordsContainer;
    #endregion

    void Start() {
        m_WordsQueue = new Queue<GameObject>(s_DestroyedWordsToEnd);
        m_InvokedWordsContainer = transform.FindChild("Spawn").gameObject;
        m_InactiveWordsContainer = transform.FindChild("Queue").gameObject;

        for (int i = 0; i < s_DestroyedWordsToEnd; ++i) {
            Object prefab = Resources.Load("Prefabs/Shooter/WordToShoot");
            GameObject wordToShoot = GameObject.Instantiate(prefab) as GameObject;

            wordToShoot.GetComponent<TextLife>().m_Text = "Azerty";
            wordToShoot.transform.parent = m_InactiveWordsContainer.transform;
            wordToShoot.transform.position = m_InactiveWordsContainer.transform.position;
            wordToShoot.SetActive(false);

            m_WordsQueue.Enqueue(wordToShoot);
        }

        this.StartCoroutine("InvokeWords");
    }

    IEnumerator InvokeWords() {
        while (s_DestroyedWord < s_DestroyedWordsToEnd) {
            if (m_InvokedWordsContainer.transform.childCount < c_MaxWordInALine) {
                GameObject invokedWord = m_WordsQueue.Dequeue();
                invokedWord.transform.parent = m_InvokedWordsContainer.transform;
                invokedWord.SetActive(true);
                TextLife invokedWordScript = invokedWord.GetComponent<TextLife>();

                // Waiting for invokedWordScript to be set
                yield return null;
                
                float timeToWait = invokedWordScript.GetTimeToWait(c_TimeBetweenSpawns);
                yield return new WaitForSeconds(timeToWait);
            }

            yield return null;
        }

        // Launch GameOver
    }

    public void ReturnToQueue(GameObject wordToReturn) {
        m_WordsQueue.Enqueue(wordToReturn);
        wordToReturn.transform.parent = m_InactiveWordsContainer.transform;
        wordToReturn.transform.position = m_InactiveWordsContainer.transform.position;
        wordToReturn.SetActive(false);
    }
}
