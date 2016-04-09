using UnityEngine;
using System.Collections;

public enum Worlds {
	NormalWorld = 8,
	DarkWorld = 9,
}

public class World : MonoBehaviour {
	public Worlds CurWorld { get; private set; }

	void Start () {
		CurWorld = Worlds.NormalWorld;
        Physics2D.IgnoreLayerCollision((int)Worlds.NormalWorld, (int)Worlds.DarkWorld);
	}

	public void ChangeWorld() {
		if (CurWorld == Worlds.NormalWorld)
			CurWorld = Worlds.DarkWorld;
		else
			CurWorld = Worlds.NormalWorld;
	}

	public void Reset() {
		var objects = GameObject.FindObjectsOfType(typeof(WorldObject));
		foreach (var obj in objects) {
			(obj as WorldObject).Reset();
		}
	}

	void Update() {
		
	}
}
