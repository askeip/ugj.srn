using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloudScript : WorldObject
{

    public float speed = 0.05f;
    private Rigidbody2D rigidbody2D;

    public GameObject rightBorder;
    
    // Use this for initialization
    void Start()
    {
        GeneralStart();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
    }

    void OnTriggerEnter2D(Component other)
    {
        if (other.tag == "CloudBorder")
            transform.position = new Vector3(rightBorder.transform.position.x, transform.position.y);
    }

}