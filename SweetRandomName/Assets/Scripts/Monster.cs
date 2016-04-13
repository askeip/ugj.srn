using UnityEngine;
using System.Collections;
using System;

public class Monster : DarkObject {
    public int damage;
    //private Vector3 initPosition;
    private GameObject player;
    private Rigidbody2D body;
    public Vector3 playerPosition;
    public float maxSpeed;
    private bool facingRight;
    private float xSpeed;
    private int dir;

    private Animator anim;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        dir = -1;
        anim = gameObject.GetComponent<Animator>();
        //initPosition = transform.position;
        PreStart();
        body = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        ChangeWorld();
        MakeMove();
        anim.SetBool("Moving", xSpeed != 0);
        if (xSpeed > 0 && !facingRight)
            Flip ();
        else if (xSpeed < 0 && facingRight)
            Flip ();
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
        xSpeed = 0;
        if (isActive)
        {
            playerPosition = player.transform.position;
            float deltaY = player.transform.position.y - transform.position.y;
            if (Vector3.Distance(player.transform.position, transform.position) < 1 && Math.Abs(deltaY) < 0.2) // TODO make global constant or count it
            {
                dir = Math.Sign(player.transform.position.x - transform.position.x);
                xSpeed = dir * maxSpeed;
            } else {
                xSpeed = maxSpeed / 2 * dir;
            }
        }
        else
        {
            xSpeed = maxSpeed / 2 * dir;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MonsterBorder")
            dir *= -1;
    }
}
