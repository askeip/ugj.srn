using UnityEngine;
using System.Collections;
using System;

public class CameraMovingScript : WorldObject
{
    public GameObject player;
    private HeroScript playerScript;

    private const float normalOffset = 0.5f;
    private Vector3 baseOffset;

    public void Start()
    {
        playerScript = player.GetComponent<HeroScript>();
        baseOffset = transform.position - player.transform.position;
    }

    void Update()
    {
        var curSpeed = Vector3.Distance(player.transform.position, transform.position) / normalOffset * playerScript.xSpeed;
        var moveTemp = player.transform.position;
        moveTemp.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, moveTemp, curSpeed * Time.deltaTime);
    }

    public override void Reset()
    {
        transform.position = player.transform.position + baseOffset;
    }
}
