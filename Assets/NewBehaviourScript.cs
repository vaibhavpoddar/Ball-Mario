using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class NewBehaviourScript : MonoBehaviour {

	float directionX;
	private Rigidbody2D rb;
	private float movespeed;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		movespeed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		/*directionX = CrossPlatformInputManager.GetAxis("Horizontal");
		if(directionX>0)
    		rb.velocity = new Vector2( 10, 0);
		if (directionX < 0)
            rb.velocity = new Vector2(-10, 0);
	    */

		if(Input.touchCount>0){
			Touch touch = Input.GetTouch(0);
			switch (touch.phase){
				case TouchPhase.Began:
					if (touch.position.x < Screen.width / 2)
						rb.velocity = new Vector2(-movespeed, 0f);
					if (touch.position.x > Screen.width / 2)
                        rb.velocity = new Vector2(movespeed, 0f);
					break;

				case TouchPhase.Ended:
					rb.velocity = new Vector2(0f, 0f);
					break;
			}
		}
	}
}
