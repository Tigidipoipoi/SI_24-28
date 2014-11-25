using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour {

    public GameObject myType;

    void OnMouseEnter() {

        Instantiate(myType, transform.position, Quaternion.identity);

    }

}
