using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class rocket : MonoBehaviour {
	Rigidbody2D rb;
	int counter;
	float x;
	double b;

	public float speed;
	public float amplitude;
	public float ang_freq;
	public float adjust_rocket_x;
	private Vector2 v;
	public float max_height;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		counter = 0;
		v = rb.transform.position;
	}
	

	void Update () {
		counter++;
		b = (counter * (Math.PI)) / 180;
		rb.velocity = new Vector2((float)(amplitude*ang_freq * (Math.Cos(ang_freq*b))), speed);
		transform.position = new Vector2((float)(amplitude * (Math.Sin(ang_freq * b)))+adjust_rocket_x, transform.position.y);
		if (transform.position.y > max_height)
		{ 
			transform.position = v;
			rb.velocity = new Vector2(0f, 0f);
		}
	}
}
