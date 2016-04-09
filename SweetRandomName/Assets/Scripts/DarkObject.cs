using UnityEngine;
using System.Collections;

public class DarkObject : Changable {
    private Transform anotherWorldObject;

	void Start() {
		base.PreStart();
		activeWorld = Worlds.DarkWorld;
        gameObject.layer = (int)activeWorld;
	}
	

	void Update() {
		ChangeWorld();
	}
}
