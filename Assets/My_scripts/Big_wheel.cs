using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_wheel : MonoBehaviour {

    private Rigidbody2D rb;
	private Vector2 init_pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		init_pos = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {    
    }
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "DEATH_LINE")
		{
			rb.transform.position = init_pos;
			rb.velocity = new Vector2(0f, 0f);
		}
	}

}
