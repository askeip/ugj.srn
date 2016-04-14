using UnityEngine;
using System.Collections;

public class StunScript : WorldObject
{
    private Collider2D stunCollider;
    public float StunTime;
    private bool activeStun = true;

    void Start()
    {
        GeneralStart();
        stunCollider = gameObject.GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (activeStun && other.tag == "Player")
        {
            var heroScript = other.GetComponent<HeroScript>();
            heroScript.stunTime = StunTime;
            activeStun = false;
        }
    }

    public override void Reset()
    {
        activeStun = true;
        base.Reset();
    }
}
