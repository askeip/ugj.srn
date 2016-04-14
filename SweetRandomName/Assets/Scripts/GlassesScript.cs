using UnityEngine;
using System.Collections;

public class GlassesScript : WorldObject 
{
    private SpriteRenderer spriteRenderer;
    private Collider2D[] colliders;

    public GameObject player;
    private HeroScript heroScript;

    private bool checkpointActive;

    void Start()
    {
        GeneralStart();
        heroScript = player.GetComponent<HeroScript>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        colliders = gameObject.GetComponents<Collider2D>();
    }

    public override void GeneralStart()
    {
        base.GeneralStart();
        checkpointActive = true;
    }

    void Update()
    {
        if (heroScript.stunTime > 0)
            objRigidbody2D.gravityScale = 0.1f;
        else
            objRigidbody2D.gravityScale = 0f;
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
