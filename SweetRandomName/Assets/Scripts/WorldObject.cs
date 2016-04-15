using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {
    protected Vector3 initPosition;
    protected Rigidbody2D objRigidbody2D;
    protected Vector3 initVelocity;
    public bool ShouldnotReset;

    public virtual void GeneralStart()
    {
        initPosition = transform.position;
        objRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        initVelocity = objRigidbody2D == null ? new Vector2(0, 0) : objRigidbody2D.velocity;
    }

    public virtual void Reset() {
        if (!ShouldnotReset)
        {
            transform.position = initPosition;
            if (objRigidbody2D != null)
                objRigidbody2D.velocity = initVelocity;
        }
    }
}
