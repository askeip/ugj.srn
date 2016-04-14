using UnityEngine;
using System.Collections;

public class GunScript : WorldObject
{
    public Transform FirePoint;
    public GameObject Shot;
    private float timePast;
    public float cooldown;
    public float speed;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        GeneralStart();
        timePast = int.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Time", timePast / cooldown);
        timePast += Time.deltaTime;
        if (timePast >= cooldown)
        {
            timePast = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        var shot = (GameObject)Instantiate(Shot, FirePoint.position, FirePoint.rotation);
        shot.GetComponent<ShotScript>().speed = speed;
    }

    public override void Reset()
    {
        base.Reset();
        timePast = int.MaxValue;
    }
}
