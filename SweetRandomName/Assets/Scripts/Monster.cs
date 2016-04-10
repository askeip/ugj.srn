using UnityEngine;
using System.Collections;
using System;

public class Monster : DarkObject {
    public int damage;
    private Vector3 initPosition;
    public GameObject player;
    private Rigidbody2D body;
    public Vector3 playerPosition;
    public float maxSpeed;

	void Start () {
        initPosition = transform.position;
        PreStart();
        body = GetComponent<Rigidbody2D>();
	}

    public override void Reset()
    {
        transform.position = initPosition;
        body.velocity = new Vector2(0, 0);
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
        body.velocity = new Vector2(xSpeed, body.velocity.y);
	}
}
