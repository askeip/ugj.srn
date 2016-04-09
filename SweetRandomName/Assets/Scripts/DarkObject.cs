using UnityEngine;
using System.Collections;

public class DarkObject : Changable {
	void Start() {
		base.PreStart();
		activeWorld = Worlds.DarkWorld;
	}
	

	void Update() {
		ChangeWorld();
	}
}
