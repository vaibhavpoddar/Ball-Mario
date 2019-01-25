using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class button_control : MonoBehaviour
{

    public float directionX;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        directionX = CrossPlatformInputManager.GetAxis("Horizontal");
        if(directionX>0)
            rb.velocity = new Vector2( 10, 0);
        if (directionX < 0)
            rb.velocity = new Vector2(-10, 0);
    }
}
