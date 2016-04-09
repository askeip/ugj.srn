using UnityEngine;
using System.Collections;

public enum Worlds {
	NormalWorld = 8,
	DarkWorld = 9
}
        

public class World : MonoBehaviour {
    const int playerLayer = 11;
	public Worlds CurWorld { get; private set; }

	void Start() {
        DefaultValues();
	}

    private void DefaultValues()
    {
        CurWorld = Worlds.NormalWorld;
        Physics2D.IgnoreLayerCollision((int)Worlds.NormalWorld, (int)Worlds.DarkWorld);
        Physics2D.IgnoreLayerCollision((int)Worlds.DarkWorld, playerLayer);
        Physics2D.IgnoreLayerCollision((int)Worlds.NormalWorld, playerLayer, false);
    }

	public void ChangeWorld() {
        if (CurWorld == Worlds.NormalWorld)
        {
            Physics2D.IgnoreLayerCollision((int)Worlds.NormalWorld, playerLayer);
            Physics2D.IgnoreLayerCollision((int)Worlds.DarkWorld, playerLayer, false);
            CurWorld = Worlds.DarkWorld;
        }
        else
        {
            Physics2D.IgnoreLayerCollision((int)Worlds.DarkWorld, playerLayer);
            Physics2D.IgnoreLayerCollision((int)Worlds.NormalWorld, playerLayer, false);
            CurWorld = Worlds.NormalWorld;
        }
	}

	public void Reset() {
        DefaultValues();
		var objects = GameObject.FindObjectsOfType(typeof(WorldObject));
		foreach (var obj in objects) {
			(obj as WorldObject).Reset();
		}
	}

	void Update() {
		
	}
}
