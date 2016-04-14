using UnityEngine;
using System.Collections;

public class CheckpointScript : WorldObject
{
    void Start()
    {
        GeneralStart();
    }

    void OnTriggerEnter2D(Component other)
    {
        if (other.tag == "Player")
        {
            var objects = GameObject.FindObjectsOfType(typeof(WorldObject));
            foreach (var obj in objects)
            {
                (obj as WorldObject).GeneralStart();
            }
        }        
    }
}
