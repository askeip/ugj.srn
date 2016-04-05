using UnityEngine;
using System.Collections;

public class HeroScript : MonoBehaviour 
{
	public float xSpeed;
	public float ySpeed;

	Rigidbody2D playerRigidbody2D;
	bool facingRight;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;

	bool gameOver;

	void Start()
	{
		playerRigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (gameOver) 
		{
			return;
		}
		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, ySpeed);
		}
	}



	void FixedUpdate()
	{
		if (gameOver) 
		{
			playerRigidbody2D.gravityScale = -1;
			playerRigidbody2D.velocity = new Vector2 (0, 0);
			return;
		}//grounded = Physics2D.OverlapCircle (groundCheck.position,groundRadius, whatIsGround);

		grounded = Physics2D.OverlapArea (groundCheck.position, new Vector2(groundCheck.position.x + 0.01f, groundCheck.position.y - groundRadius), whatIsGround);//, groundRadius, whatIsGround);

		float xMove = Input.GetAxis ("Horizontal");

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
			gameOver = true;
		}
	}
}
