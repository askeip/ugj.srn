using UnityEngine;
using System.Collections;

public class GlassesScript : WorldObject 
{
    private SpriteRenderer spriteRenderer;
    private Collider2D[] colliders;

    private bool checkpointActive;

    void Start()
    {
        GeneralStart();
        checkpointActive = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        colliders = gameObject.GetComponents<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            var heroScript = other.gameObject.GetComponent<HeroScript>();
            heroScript.HasGlasses = true;
            spriteRenderer.enabled = false;
            foreach (var clider in colliders)
                clider.enabled = false;
        }
    }

    public override void Reset()
    {
        spriteRenderer.enabled = checkpointActive;
        foreach (var clider in colliders)
            clider.enabled = checkpointActive;
        base.Reset();
    }
}
