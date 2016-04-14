using UnityEngine;
using System.Collections;
using System;

public class Monster : DarkObject {
    public int damage;
    private GameObject player;
    private Rigidbody2D body;
    public Vector3 playerPosition;
    public float maxSpeed;
    private bool facingRight;
    private float xSpeed;
    private int direction;
    public float followDistance = 2;
    public Transform frontGroundChecker;
    public float checkersRadius = 0.1f;
    public LayerMask DarkLayer;

    private Animator anim;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        direction = -1;
        anim = gameObject.GetComponent<Animator>();
        GeneralStart();
        body = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        ChangeWorld();
        MakeMove();
        anim.SetBool("Moving", xSpeed != 0);
        if (xSpeed > 0 && !facingRight)
            Flip();
        else if (xSpeed < 0 && facingRight)
            Flip();
        body.velocity = new Vector2(xSpeed, body.velocity.y);
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void MakeMove()
    {
        var frontGrounded = Physics2D.OverlapCircle(frontGroundChecker.position,
            checkersRadius,
            DarkLayer);
        if (!frontGrounded)
            direction *= -1;
        xSpeed = maxSpeed / 2 * direction; // constant
        if (isActive)
        {
            playerPosition = player.transform.position;
            float deltaY = player.transform.position.y - transform.position.y;
            float deltaX = player.transform.position.x - transform.position.x;
            if (Vector3.Distance(player.transform.position, transform.position) < followDistance && Math.Abs(deltaY) < 0.2 &&
                Math.Sign(deltaX) == direction) // TODO make global constant or calculate it
            {
                xSpeed = direction * maxSpeed;
            }
        }
    }
}
