using UnityEngine;
using System.Collections;

public class Changable : WorldObject {
	protected Worlds activeWorld;
	protected World world;
	private Collider2D collider;
	private SpriteRenderer[] sprites;

	protected void PreStart() {
		collider = gameObject.GetComponent<Collider2D>();
		sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
		world = GameObject.FindObjectsOfType(typeof(World))[0] as World;
	}

	protected void ChangeWorld() {
		foreach (var sprite in sprites)
		{
			var color = sprite.color;
			if (world.CurWorld != activeWorld)
				color.a = 0.4f;
			else
				color.a = 1f;
			sprite.color = color;
		}
	}
}