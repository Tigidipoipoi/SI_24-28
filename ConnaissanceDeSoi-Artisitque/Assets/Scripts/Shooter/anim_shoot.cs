using UnityEngine;
using System.Collections;

public class anim_shoot : MonoBehaviour {
	public Animator animator;
	private bool isAttacking;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			animator.SetBool("Shoot", true);
			//	transform.animation.Play("handshoot_1");
		}

		else {
			animator.SetBool("Shoot", false);
		}
	}
}
