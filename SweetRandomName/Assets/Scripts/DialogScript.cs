using UnityEngine;
using System.Collections;

public class DialogScript : WorldObject
{
    public string dialog;
    public float textShowingTime;
    public bool shouldOff;
    private bool active = true;

    void Start()
    {
        active = true;
        GeneralStart();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && active)
        {
            var playerScript = other.gameObject.GetComponent<HeroScript>();
            playerScript.text.text = dialog;
            playerScript.ShowText(textShowingTime);
            active = !shouldOff;
        }
    }

    public override void Reset()
    {
        active = true;
        base.Reset();
    }
}
