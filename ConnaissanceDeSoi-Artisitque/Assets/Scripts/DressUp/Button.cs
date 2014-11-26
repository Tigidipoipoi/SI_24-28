using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    bool naming = false, over = false;
    NameIt nI;
    Color init = Color.gray, mouseOver = Color.blue, mouseClick = Color.green;


    void Start() {

        nI = GameObject.Find("CatName").GetComponent<NameIt>();
        renderer.material.color = init;

    }

    void OnMouseUpAsButton() {

        if (over) {
            // Game Over
        }
        else if (!naming) {
            renderer.material.color = mouseClick;
            nI.Naming();
            naming = true;
        }
        else {
            nI.Naming();
            over = true;
        }

    }

    void OnMouseEnter() { renderer.material.color = mouseOver; }

    void OnMouseExit() { renderer.material.color = init; }

    void OnMouseDown() { renderer.material.color = mouseClick; }

    void OnMouseUp() { renderer.material.color = mouseOver; }

}
