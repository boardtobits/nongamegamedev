using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

	CharacterController cc;

	public float speed = 3f;

	float xMove;
	float zMove;

	void Awake () {
		cc = GetComponent<CharacterController> ();
	}

	void Update () {
		xMove = Input.GetAxisRaw("Horizontal");
		zMove = Input.GetAxisRaw("Vertical");
		if (xMove != 0 || zMove != 0) {
			cc.SimpleMove (new Vector3 (xMove, 0, zMove).normalized * speed);
		}
	}
}
