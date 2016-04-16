using UnityEngine;
using System.Collections;

public class ShotScript : NormalObject
{
    public float speed;
    public float timer;

	// Use this for initialization
	void Start ()
	{
        GeneralStart();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer < 0)
            Destroy(gameObject);
	    objRigidbody2D.velocity = new Vector2(speed, objRigidbody2D.velocity.y);
        timer -= Time.deltaTime;
	}

    public override void Reset()
    {
        Destroy(gameObject);
        //base.Reset();
        //objRigidbody2D.velocity = new Vector2(0, 0);
    }

    void OnTriggerEnter2D(Component other)
    {
        if (other.tag != "Dialog" && other.tag != "Cloud")
            Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}