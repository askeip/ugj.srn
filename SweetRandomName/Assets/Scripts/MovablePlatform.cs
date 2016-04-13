using UnityEngine;
using System.Collections;

public class MovablePlatform : MonoBehaviour {
    private int direction = 1;
    public float speed = 1;
    public Transform leftBorder, rightBorder;

	void Start () {
        
	}
	
	void Update () {
        var xSpeed = speed * direction;
        var body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(xSpeed, body.velocity.y);
	}

    void FixUpdate() {
        
    }

    void OnTriggerEnter2D(Component other) {
        if (other.transform == leftBorder)
            direction = 1;
        if (other.transform == rightBorder)
            direction = -1;
    }
}
