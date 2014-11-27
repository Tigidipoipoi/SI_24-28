using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour {

    public GameObject myType;

    void OnMouseEnter() {

        Instantiate(myType, new Vector3(transform.position.x, transform.position.y, (transform.position.z - 2f)), transform.rotation);

    }

}
