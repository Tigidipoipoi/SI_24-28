using UnityEngine;
using System.Collections;

public class handMove : MonoBehaviour {
	// Use this for initialization
	public float m_handspeed = 1f;
	public float m_handspeed2 = 1f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 m_mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 m_diff = m_mousePos - transform.position;
		m_diff = new Vector3 (m_diff.x, m_diff.y, 0);
		transform.position += m_diff/ m_handspeed;


		Vector3 m_diff2 = GameObject.FindGameObjectWithTag ("handAnchor").transform.position - transform.position;
		m_diff2 = new Vector3 (m_diff2.x, m_diff2.y, 0);
		transform.position += m_diff2/ m_handspeed2;


//		Vector3 diff=GameObject.FindGameObjectWithTag ("turretplace").transform.position - transform.position;
//		diff=new Vector3(diff.x,0f,diff.z);
//		transform.position += (diff) / turretspeed;
	}
}
