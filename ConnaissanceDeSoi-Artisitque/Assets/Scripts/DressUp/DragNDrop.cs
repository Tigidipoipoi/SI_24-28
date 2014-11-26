using System.Collections;
using UnityEngine;

class DragNDrop : MonoBehaviour {

    private bool dragging = false;
    private float distance;
    private TextTB ttb;
    public string description = "";

    void Start() {
        ttb = GameObject.Find("TextTB").GetComponent<TextTB>();

    }

    void OnMouseEnter() {

        if (ttb == null) ttb = GameObject.Find("TextTB").GetComponent<TextTB>();
        ttb.ChangeText(description);

    }
    void OnMouseExit() {

        ttb.ChangeText("créé ton chat !");

    }

    void OnMouseDown() {

        distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        dragging = true;

    }

    void OnMouseUp() {

        dragging = false;

        if (transform.position.x > 2.5) Destroy(this.gameObject);

    }

    void Update() {

        if (dragging) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = 0;

            transform.position = rayPoint;

        }

    }

}
