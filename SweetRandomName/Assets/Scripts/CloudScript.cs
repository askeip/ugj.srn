using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloudScript : WorldObject
{

    public float speed = 0.05f;

    public GameObject rightBorder;
    
    // Use this for initialization
    void Start()
    {
        GeneralStart();
    }

    // Update is called once per frame
    void Update()
    {
        objRigidbody2D.velocity = new Vector2(-speed, objRigidbody2D.velocity.y);
    }

    void OnTriggerEnter2D(Component other)
    {
        if (other.tag == "CloudBorder")
            transform.position = new Vector3(rightBorder.transform.position.x, transform.position.y);
    }

}