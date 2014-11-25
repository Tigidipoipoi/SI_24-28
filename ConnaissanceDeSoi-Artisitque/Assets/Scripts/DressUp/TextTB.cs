using UnityEngine;
using System.Collections;

public class TextTB : MonoBehaviour {

    TextMesh tm;
    string text;

    void Start() {

        tm = (TextMesh)this.GetComponent(typeof(TextMesh));
        text = "créé ton chat !";

    }

    public void ChangeText(string s) {

        text = s;

    }

    void Update() {

        tm.text = text;

    }
}
