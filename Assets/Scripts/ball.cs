using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle; 
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;



	// Use this for initialization
	void Start () {
		//AudioSource audiottt = GetComponent<AudioSource>();
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		//audiottt.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse press to launch.
			if (Input.GetMouseButtonDown(0)) {
				print ("Mouse clicked, launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);

			}

		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource audiottt = GetComponent<AudioSource>();
		Rigidbody2D rigidBodyyy = GetComponent<Rigidbody2D>();
		// Here we give the ball a tiny ammount of random velocity to keep the ball from becoing stuck in a back and forth loop
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarted) {
			audiottt.Play();
			rigidBodyyy.velocity += tweak;
		}

		
	}
}
