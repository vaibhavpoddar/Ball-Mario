using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Line : MonoBehaviour {

	public GameObject player;
	public int offset;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x,transform.position.y, player.transform.position.z);
        }
    }
}
