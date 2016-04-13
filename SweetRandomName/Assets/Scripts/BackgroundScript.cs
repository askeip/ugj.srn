using UnityEngine;
using System.Collections;

public class BackgroundScript : Changable
{   
    public GameObject player;
    private HeroScript playerScript;
    public Sprite[] worldSprites;

    void Start()
    {
        playerScript = player.GetComponent<HeroScript>();
        PreStart();
    }

    protected override void ChangeWorld()
    {
        sprites[0].sprite = worldSprites[(int)world.CurWorld - 8];
    }

    void Update()
    {
        var curSpeed = Vector3.Distance(player.transform.position, transform.position) * playerScript.xSpeed;
        var moveTemp = player.transform.position;
        moveTemp.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, moveTemp, curSpeed * Time.deltaTime);
        ChangeWorld();
    }
}
