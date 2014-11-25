using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour {

    private TextTB ttb;
    public string description = "";

    void OnMouseEnter() {

        if (ttb == null) ttb = GameObject.Find("TextTB").GetComponent<TextTB>();
        ttb.ChangeText(description);

    }
    void OnMouseExit() {

        ttb.ChangeText("créé ton chat !");

    }

}
