using UnityEngine;
using System.Collections;

public class MovablePlatform : WorldObject {
    private int direction = 1;
    public float speed = 1;
    public Transform leftBorder, rightBorder;

	void Start () {
        GeneralStart();
	}
	
	void Update () {
        var xSpeed = speed * direction;
        objRigidbody2D.velocity = new Vector2(xSpeed, objRigidbody2D.velocity.y);
	}


    void OnTriggerEnter2D(Component other) {
        if (other.transform == leftBorder)
            direction = 1;
        if (other.transform == rightBorder)
            direction = -1;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var heroScript = other.gameObject.GetComponent<HeroScript>();
            heroScript.additionalVelocity = objRigidbody2D.velocity;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var heroScript = other.gameObject.GetComponent<HeroScript>();
            heroScript.additionalVelocity = new Vector2(0, 0);
        }
    }
}
