using UnityEngine;
using System.Collections;

public class DialogScript : WorldObject
{
    public string dialog;
    public float textShowingTime;
    public bool shouldOff;
    private bool active = true;
    private bool wasActive;

    void Start()
    {
        GeneralStart();
    }

    public override void GeneralStart()
    {
        wasActive = active;
        base.GeneralStart();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && active)
        {
            var playerScript = other.gameObject.GetComponent<HeroScript>();
            playerScript.text.text = dialog;
            playerScript.ShowText(textShowingTime);
        }
    }

    void OnTriggerExit2D(Component other)
    {
        if (other.tag == "Player" && shouldOff)
            active = false;
    }

    public override void Reset()
    {
        base.Reset();
        active = wasActive;
    }
}
