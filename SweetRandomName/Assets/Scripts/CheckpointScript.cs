using UnityEngine;
using System.Collections;

public class CheckpointScript : WorldObject
{
    private bool active = true;
    World world;

    void Start()
    {
        world = FindObjectOfType<World>();
        GeneralStart();
    }

    void OnTriggerEnter2D(Component other)
    {
        if (other.tag == "Player" && active)
        {
            var objects = GameObject.FindObjectsOfType(typeof(WorldObject));
            foreach (var obj in objects)
            {
                (obj as WorldObject).GeneralStart();
            }
            active = false;
            world.InitWorld = world.CurWorld;
        }        
    }
}
