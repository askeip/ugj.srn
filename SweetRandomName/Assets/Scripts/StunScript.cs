using UnityEngine;
using System.Collections;

public class StunScript : WorldObject
{
    public float StunTime;
    private bool activeStun = true;
    private bool wasActiveStun;

    void Start()
    {
        GeneralStart();
    }

    public override void GeneralStart()
    {
        wasActiveStun = activeStun;
        base.GeneralStart();
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
        activeStun = wasActiveStun;
        base.Reset();
    }
}
