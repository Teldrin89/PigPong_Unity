using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePaddle : MonoBehaviour {

	public float speed = 30;

	// Use this for fixed update
	void FixedUpdate(){

		float vertPress = Input.GetAxisRaw ("Vertical");

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, vertPress) * speed;


	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
