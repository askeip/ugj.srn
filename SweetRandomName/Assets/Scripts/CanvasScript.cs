using UnityEngine;
using System.Collections;

public class CanvasScript : WorldObject
{
    public GameObject player;

    private float timeLeft;

    private Vector3 baseOffset;

    public void Start()
    {
        GeneralStart();
    }

    public override void GeneralStart()
    {
        baseOffset = transform.position - player.transform.position;
        base.GeneralStart();
    }
    void Update()
    {
        transform.position = player.transform.position;
        if (timeLeft <= 0)
            gameObject.SetActive(false);
        timeLeft -= Time.deltaTime;
    }

    public override void Reset()
    {
        transform.localPosition = player.transform.position + baseOffset;
    }

    public void ShowText(float time)
    {
        gameObject.SetActive(true);
        timeLeft = time;
    }
}
