using UnityEngine;
using System.Collections;

public class NormalObject : Changable {
	void Start() {
		PreStart();
	}

    protected override void PreStart()
    {
        base.PreStart();
        activeWorld = Worlds.NormalWorld;
        gameObject.layer = (int)activeWorld;
    }

	void Update() {
		ChangeWorld();
	}
}
