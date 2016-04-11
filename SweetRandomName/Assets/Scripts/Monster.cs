using UnityEngine;
using System.Collections;
using System;

public class Monster : DarkObject {
    public int damage;
    //private Vector3 initPosition;
    public GameObject player;
    private Rigidbody2D body;
    public Vector3 playerPosition;
    public float maxSpeed;
    private bool facingRight;

    private Animator anim;

	void Start () {
        anim = gameObject.GetComponent<Animator>();
        //initPosition = transform.position;
        PreStart();
        body = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        ChangeWorld();
        float xSpeed = 0;
        if (isActive)
        {
            playerPosition = player.transform.position;
            int dir = Math.Sign(player.transform.position.x - transform.position.x);
            if (Vector3.Distance(player.transform.position, transform.position) < 1)
                xSpeed = dir * maxSpeed;
        }
        else
        {
            xSpeed = 0;
        }
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
}
