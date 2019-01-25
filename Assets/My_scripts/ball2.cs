using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI; //for text

public class ball2 : MonoBehaviour
{
	private int score;
	private int lives;

	float directionX;
	private Rigidbody2D rb;
	float movespeed;

	public AudioSource coin_collect;
	public AudioSource game_over;
	public AudioSource background;
	public AudioSource victory;
	public AudioSource player_explosion;

	public float jumpspeed;
	float directionY;

	public Text score_text;
	public Text Lives_text;
	public Text GameOver_text;

	private Vector2 inital_pos;

	public LayerMask frontlayer;
	private bool istouching;
	public Transform reference_point;//of ball
	public float delta_radius;
	void Start()
	{
		lives = 3;
		rb = GetComponent<Rigidbody2D>();
		movespeed = 6f;
		score = 0;
		background.Play();
		score_text.text = "Score:0";
		Lives_text.text = "Lives:3";
		inital_pos = rb.transform.position;
		GameOver_text.text = "";
	}

    void Update()
    {
        istouching = Physics2D.OverlapCircle(reference_point.position, delta_radius, frontlayer);
		if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x < Screen.width / 2 && touch.position.y < Screen.height / 2)
                    {
                        directionX = movespeed;
                        rb.velocity = new Vector2(-directionX, rb.velocity.y);
                    }
                    else if (touch.position.x > Screen.width / 2 && touch.position.y < Screen.height / 2)
                    {
                        rb.velocity = new Vector2(movespeed, 0f);
                    }
                    else if (touch.position.y > Screen.height / 2 && istouching)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, directionY * jumpspeed);
                    }
                    break;

                case TouchPhase.Ended:
                    rb.velocity = new Vector2(0f, 0f);
                    break;
            }
        }
    }

    //Triggering / Colliding Actions ..................
    void OnTriggerEnter2D(Collider2D other)
    {
        if (lives > 0)
        {
            if (other.tag == "BOMB")
            {
                coin_collect.Stop();
                player_explosion.Play();
                Destroy(other.gameObject);
                rb.transform.position = inital_pos;

                lives--;
                Lives_text.text = "Lives:" + lives.ToString();
                if (lives == 0)
                {
                    Destroy(gameObject);
                    background.Stop();
                    game_over.Play();
                    GameOver_text.text = "GAME OVER";
                }
                Debug.Log(score);
            }
            else if (other.tag == "DEATH_LINE" || other.tag == "ROCKET")
            {
                coin_collect.Stop();
                player_explosion.Play();
                rb.transform.position = inital_pos;

                lives--;
                Lives_text.text = "Lives:" + lives.ToString();
                if (lives == 0)
                {
                    Destroy(gameObject);
                    background.Stop();
                    game_over.Play();
                    GameOver_text.text = "GAME OVER";
                    Debug.Log(score);
                }
            }
            else if (other.tag == "COIN")
            {
                coin_collect.Play();
                Destroy(other.gameObject);
                score++;
                Debug.Log(score);
                score_text.text = "Score:" + score.ToString();
            }
            else if (other.tag == "FINISH")
            {
                background.Stop();
                coin_collect.Stop();
                game_over.Stop();
                victory.Play();
            }
        }
        Debug.Log("OUT!!");
    }

    //Respawning........
    /*void Respawn(){
        rb.transform.position = inital_pos;
        Debug.Log("RESPAWNED!!");
    }*/

    /*IEnumerator respawning(float time){
        yield return new WaitForSeconds(time);
        Respawn();
    }*/

}
