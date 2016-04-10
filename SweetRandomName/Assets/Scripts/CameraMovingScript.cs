using UnityEngine;
using System.Collections;
using System;

public class CameraMovingScript : WorldObject
{
    public GameObject player;
    private HeroScript playerScript;

    private Vector3 offset;

    private const float maxDifX = 0.3f;
    private const float maxDifY = 0.3f;

    public void Start()
    {
        playerScript = player.GetComponent<HeroScript>();
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        var xDif = Math.Abs(player.transform.position.x - transform.position.x);
        var yDif = Math.Abs(player.transform.position.y - transform.position.y);
        if (xDif > maxDifX || yDif > maxDifY)
        {
            var moveTemp = player.transform.position;
            moveTemp.z = transform.position.z;
            //moveTemp.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, moveTemp, playerScript.xSpeed * Time.deltaTime);
        }
    }

    public override void Reset()
    {
        transform.position = player.transform.position + offset;
    }
}
