using UnityEngine;
using System.Collections;
using System;

public class Monster : DarkObject {
    public int damage;
    private GameObject player;
    public Vector3 playerPosition;
    public float maxSpeed;
    private bool facingRight;
    private float xSpeed;
    private int direction;
    public float followDistance = 2;
    public Transform frontGroundChecker;
    public float checkersRadius = 0.1f;
    public LayerMask DarkLayer;

    public Vector2 additionalVelocity;

    private Animator anim;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        direction = -1;
        anim = gameObject.GetComponent<Animator>();
        GeneralStart();
        objRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        ChangeWorld();
        MakeMove();
        anim.SetBool("Moving", xSpeed != 0);
        if (xSpeed > 0 && !facingRight)
            Flip();
        else if (xSpeed < 0 && facingRight)
            Flip();
        objRigidbody2D.velocity = new Vector2(xSpeed, objRigidbody2D.velocity.y);
        objRigidbody2D.velocity += additionalVelocity;
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
        var colls = Physics2D.OverlapCircleAll(frontGroundChecker.position,
            checkersRadius,
            DarkLayer);
        
        var frontGrounded = false;
        if (colls.Length == 0)
            frontGrounded = false;
        foreach (var coll in colls)
        {
            frontGrounded = !coll.isTrigger;
            if (frontGrounded)
                break;
        }
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
