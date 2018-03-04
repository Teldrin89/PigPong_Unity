using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public float speed = 30;

	private Rigidbody2D rigidBody;

	private AudioSource audioSource;



	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = Vector2.right * speed;



	}

	// Used for collisions of ball
	void OnCollisionEnter2D(Collision2D col)
	{
		//Left or right paddle
		if ((col.gameObject.name == "LeftPaddle") ||
		    (col.gameObject.name == "RightPaddle")) 
		{

			handlePaddleHit (col);


		}
			
		//Top or bottom wall
		if ((col.gameObject.name == "WallTop") ||
		    (col.gameObject.name == "BottomWall")) 
		{
			SoundManager.Instance.PlayOneShot (SoundManager.Instance.WallBloop);

		}

		//Left or right goal
		if ((col.gameObject.name == "RightGoal") ||
			(col.gameObject.name == "LeftGoal")) 
		{
			SoundManager.Instance.PlayOneShot (SoundManager.Instance.GoalBloop);
		
			if (col.gameObject.name == "LeftGoal") 
			{
				IncreaseTextUIScore ("RightScoreUI");
			}

			if (col.gameObject.name == "RightGoal") 
			{
				IncreaseTextUIScore ("LeftScoreUI");
			}

			//Move the ball to center of the screen after goal

			transform.position = new Vector2(0, 0);

		}
			
	}

	// Function to handdle the paddle-ball collision
	void handlePaddleHit(Collision2D col)
	{
		float y = ballHitPaddleWhere (transform.position,
			          col.transform.position,
			          col.collider.bounds.size.y);

		Vector2 dir = new Vector2 ();

		if (col.gameObject.name == "LeftPaddle") 
		{
			dir = new Vector2 (1, y).normalized;
		}

		if (col.gameObject.name == "RightPaddle") 
		{
			dir = new Vector2 (-1, y).normalized;
		}

		rigidBody.velocity = dir * speed;

		SoundManager.Instance.PlayOneShot (SoundManager.Instance.HitPaddleBloop);

	}


	float ballHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
	{
		return(ball.y - paddle.y) / paddleHeight;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void IncreaseTextUIScore(string textUIName)
	{
		var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();

		int score = int.Parse(textUIComp.text);

		score++;

		textUIComp.text = score.ToString();
		
	}
}
