using System.Collections;
using UnityEngine;

class DragNDrop : MonoBehaviour {
    private bool dragging = false;
    private float distance;
    public string description = "";
    public GameObject particules;
    private Button model;

    void Start() {
        if (particules == null) {
            Debug.LogError("Particules non associées");
            particules = new GameObject();
        }
    }

    void OnMouseDown() {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        dragging = true;

        transform.localScale = new Vector3(1, 1, 1);
        Instantiate(particules, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

    void OnMouseUp() {
        dragging = false;

        if (model == null)
			model = GameObject.Find("BoutonValider").GetComponent<Button>();
        if (transform.position.x > -1)
            Destroy(this.gameObject);
        else
            model.ElementDroped(this.gameObject);
    }

    void Update() {
        if (dragging) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = transform.position.z;

            transform.position = rayPoint;
        }
    }
}
