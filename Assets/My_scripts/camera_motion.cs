using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_motion : MonoBehaviour {

	public GameObject player;
	public float x_offset;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		if (player != null)
		{
			transform.position = new Vector3(player.transform.position.x-x_offset, transform.position.y, transform.position.z);
		}
	}
}
