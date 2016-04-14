﻿using UnityEngine;
using System.Collections;

public class Changable : WorldObject {
	protected Worlds activeWorld;
	protected World world;
    protected SpriteRenderer[] sprites;
    protected bool isActive;

	protected virtual void PreStart() {
		sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
		world = GameObject.FindObjectsOfType(typeof(World))[0] as World;
        GeneralStart();
	}

    protected virtual void ChangeWorld() {
        isActive = world.CurWorld == activeWorld;
		foreach (var sprite in sprites)
		{
			var color = sprite.color;
			if (isActive)
                color.a = 1f;
			else
                color.a = 0.25f;
			sprite.color = color;
		}
	}
}