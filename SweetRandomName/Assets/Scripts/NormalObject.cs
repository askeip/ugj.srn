using UnityEngine;
using System.Collections;

public class NormalObject : Changable {
	void Start() {
		base.PreStart();
		activeWorld = Worlds.NormalWorld;
	}

	void Update() {
		ChangeWorld();
	}
}
