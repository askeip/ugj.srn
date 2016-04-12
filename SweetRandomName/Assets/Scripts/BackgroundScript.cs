using UnityEngine;
using System.Collections;

public class BackgroundScript : Changable
{   
    public GameObject player;
    private HeroScript heroScript;
    public Sprite[] worldSprites;

    void Start()
    {
        heroScript = player.GetComponent<HeroScript>();
        PreStart();
    }

    protected override void ChangeWorld()
    {
        sprites[0].sprite = worldSprites[(int)world.CurWorld - 8];
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, heroScript.xSpeed * Time.deltaTime);
        ChangeWorld();
    }
}
