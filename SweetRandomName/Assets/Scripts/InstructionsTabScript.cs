using UnityEngine;
using System.Collections;

public class InstructionsTabScript : WorldObject 
{
    public GameObject player;
    public GameObject panel;
    private HeroScript heroScript;

	void Start () {
        GeneralStart();
        heroScript = player.GetComponent<HeroScript>();
	}
	
	void Update () {
        panel.SetActive(heroScript.HasGlasses);
	}
}
