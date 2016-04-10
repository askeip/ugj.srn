using UnityEngine;
using System.Collections;

public class Changable : WorldObject {
	protected Worlds activeWorld;
	protected World world;
	private Collider2D collider;
	private SpriteRenderer[] sprites;
    protected bool isActive;

	protected void PreStart() {
		collider = gameObject.GetComponent<Collider2D>();
		sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
		world = GameObject.FindObjectsOfType(typeof(World))[0] as World;
	}

	protected void ChangeWorld() {
        isActive = world.CurWorld == activeWorld;
		foreach (var sprite in sprites)
		{
			var color = sprite.color;
			if (isActive)
                color.a = 1f;
			else
                color.a = 0.4f;
			sprite.color = color;
		}
	}
}