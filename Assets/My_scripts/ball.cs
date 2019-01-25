using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI; //for text

public class ball : MonoBehaviour
{
	private int score;
	private int lives;
	public float max;
	float directionX;
	private Rigidbody2D rb;

	public AudioSource coin_collect;
	public AudioSource game_over;
	public AudioSource background;
	public AudioSource victory;
	public AudioSource player_explosion;

	public float jumpspeed;
	public float movespeed;
    
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
		lives = 5;
		rb = GetComponent<Rigidbody2D>();
		score = 0;
		background.Play();
		score_text.text = "Score:0";
		Lives_text.text = "Lives:5";
		inital_pos = rb.transform.position;
		GameOver_text.text = "";
	}


	void Update()
	{
		istouching = Physics2D.OverlapCircle(reference_point.position, delta_radius, frontlayer);
		Debug.Log(istouching);
		directionY = CrossPlatformInputManager.GetAxis("Vertical");
		directionX = CrossPlatformInputManager.GetAxis("Horizontal");
		if (directionX > 0 )
		{   if (directionX > max) { directionX = max; }
			rb.velocity = new Vector2(directionX*movespeed*Time.deltaTime, rb.velocity.y);
			Debug.Log(directionX);
		}
		if (directionX < 0 )
		{	if (directionX > max) { directionX = max; }
			rb.velocity = new Vector2(directionX*movespeed*Time.deltaTime, rb.velocity.y);
	    }
		if(directionY==2 && istouching){
			rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
		}
    }

    //Triggering / Colliding Actions ..................
	void OnTriggerEnter2D(Collider2D other)
	{   if (lives > 0)
		{
			if (other.tag == "BOMB")
			{
				coin_collect.Stop();
				player_explosion.Play();
				Destroy(other.gameObject);
				rb.transform.position = inital_pos;
				rb.velocity = new Vector2(0f, 0f);
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
			else if (other.tag == "DEATH_LINE" || other.tag == "ROCKET" || other.tag=="BIRD_BOMB")
			{
				coin_collect.Stop();
				player_explosion.Play();
				rb.transform.position = inital_pos;            
				rb.velocity = new Vector2(0f, 0f);
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
				GameOver_text.text = "Congrats!! Level 1 Passed!";
				//Destroy(gameObject);

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
