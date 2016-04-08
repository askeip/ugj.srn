using UnityEngine;
using System.Collections;

public enum Worlds {
	NormalWorld,
	DarkWorld,
}

public class World : MonoBehaviour {
	public Worlds CurWorld { get; private set; }

	void Start () {
		CurWorld = Worlds.NormalWorld;
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
