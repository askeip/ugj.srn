using UnityEngine;
using System.Collections;

public class CanvasScript : WorldObject
{
    public GameObject player;

    private Vector3 baseOffset;

    public void Start()
    {
        baseOffset = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position;;
    }

    public override void Reset()
    {
        transform.localPosition = player.transform.position + baseOffset;
    }
}
