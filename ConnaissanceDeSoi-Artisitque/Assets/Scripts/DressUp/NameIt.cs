using UnityEngine;
using System.Collections;

public class NameIt : MonoBehaviour {

    TextMesh tm;
    string catName = "donne un nom à ton chat";
    bool naming = false, named = false;

    void Start() {

        tm = (TextMesh)this.GetComponent(typeof(TextMesh));

    }

    void Update() {

        if (named) tm.text = catName;

    }

    public void Naming() { naming = !naming; }

    void OnGUI() {

        if (naming) catName = GUI.TextField(new Rect(700, 480, 200, 20), catName, 25);

    }

    public string GetName() {

        named = true;
        return catName;

    }

}
