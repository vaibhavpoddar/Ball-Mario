using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_fly : MonoBehaviour {

	public float bird_velocity;
	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(bird_velocity, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
