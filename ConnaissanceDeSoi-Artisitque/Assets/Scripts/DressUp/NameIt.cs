using UnityEngine;
using System.Collections;

public class NameIt : MonoBehaviour {

    TextMesh tm;
    string catName = "";
    bool naming = false, named = false;

    void Start() {

        tm = (TextMesh)this.GetComponent(typeof(TextMesh));

    }

    void Update() {

        if (named) tm.text = catName;

    }

    public void Naming() { naming = !naming; }

    void OnGUI() {

        if (naming) catName = GUI.TextField(new Rect(Screen.width/1.63f, Screen.height/3f, Screen.width/5, Screen.height/12), catName, 25);

    }

    public string GetName() {

        named = true;
        return catName;

    }

}
