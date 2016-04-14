using UnityEngine;
using System.Collections;

public class DarkObject : Changable {
    private HeroScript heroScript;

	void Start() {
        PreStart();
	}

    protected override void PreStart()
    {
        base.PreStart();
        heroScript = FindObjectOfType<HeroScript>();
        activeWorld = Worlds.DarkWorld;
        gameObject.layer = (int)activeWorld;
    }
	

	void Update() {
		ChangeWorld();
	}

    protected override void ChangeWorld()
    {
        if (heroScript.HasGlasses)
            base.ChangeWorld();
        else
        {
            foreach (var sprite in sprites)
            {
                var color = sprite.color;
                color.a = 0f;
                sprite.color = color;
            }
        }
    }
}
