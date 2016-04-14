using UnityEngine;
using System.Collections;

public class NormalObject : Changable {
	void Start() {
        GeneralStart();
	}

    public override void GeneralStart()
    {
        base.GeneralStart();
        activeWorld = Worlds.NormalWorld;
        gameObject.layer = (int)activeWorld;
    }

	void Update() {
		ChangeWorld();
	}
}
