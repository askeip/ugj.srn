using UnityEngine;
using System.Collections;

public class DialogScript : WorldObject
{
    public string dialog;
    public float time;

    void Start()
    {
        GeneralStart();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var playerScript = other.gameObject.GetComponent<HeroScript>();
            playerScript.text.text = dialog;
            playerScript.ShowText(time);
        }
    }
}
