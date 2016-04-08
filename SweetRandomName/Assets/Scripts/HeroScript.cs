﻿using UnityEngine;
using System.Collections;

public class HeroScript : WorldObject 
{
	public float xSpeed;
	public float ySpeed;
	
	Rigidbody2D playerRigidbody2D;
	bool facingRight;
	
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	private Vector3 initPosition;
	private World world;
	
	
	void Start()
	{
		world = GameObject.FindObjectsOfType(typeof(World))[0] as World;
		initPosition = transform.position;
		playerRigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab)) {
			world.ChangeWorld();
		}
		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, ySpeed);
		}
	}
	
	void GameOver() {
		world.Reset();
	}

	public override void Reset() {
		transform.position = initPosition;
	}
	
	void FixedUpdate()
	{
		
		grounded = Physics2D.OverlapArea (new Vector2(groundCheck.position.x - groundRadius / 2, groundCheck.position.y), new Vector2(groundCheck.position.x + groundRadius / 2, groundCheck.position.y - groundRadius), whatIsGround);//, groundRadius, whatIsGround);
		
		float xMove = Input.GetAxis("Horizontal");
		
		playerRigidbody2D.velocity = new Vector2 (xSpeed * xMove,playerRigidbody2D.velocity.y);
		
		if (xMove > 0 && !facingRight)
			Flip ();
		else if (xMove < 0 && facingRight)
			Flip ();
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Abyss") 
		{
			GameOver();
		}
	}
}