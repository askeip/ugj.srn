using UnityEngine;
using System.Collections;

public class MovableWorldObject : WorldObject 
{
    protected Rigidbody2D objRigidbody2D;
    protected Vector3 initVelocity;

    protected override void GeneralStart()
    {
        base.GeneralStart();
        objRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        initVelocity = objRigidbody2D.velocity;
    }

    public override void Reset()
    {
        base.Reset();
        objRigidbody2D.velocity = initVelocity;
    }
}
