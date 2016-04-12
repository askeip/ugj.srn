using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroScript : WorldObject 
{
    private Dictionary<Worlds, LayerMask> worldLayer;
	public float xSpeed;
	public float ySpeed;
	
	Rigidbody2D playerRigidbody2D;
	private bool facingRight;
	
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.02f;

    public LayerMask NormalLayer;
    public LayerMask DarkLayer;

    public int hp;
    //private Vector3 initPosition;
    //private Vector3 initVelocity;
	private World world;

    private Animator animator;
    public RuntimeAnimatorController[] animControllers;
    //public RuntimeAnimatorController normalAnimController;
    //public RuntimeAnimatorController darkAnimController;

    private bool checkpointHasGlasseValue;
    public bool HasGlasses;
	
	
	void Start()
	{
        GeneralStart();
        animator = gameObject.GetComponent<Animator>();
        hp = 1;
		world = GameObject.FindObjectsOfType(typeof(World))[0] as World;
		//initPosition = transform.position;
        //initVelocity = new Vector2(0, 0);
		playerRigidbody2D = GetComponent<Rigidbody2D>();
        CreateWorldLayerDict();
        checkpointHasGlasseValue = HasGlasses;
        Reset();
	}

    private void CreateWorldLayerDict()
    {
        worldLayer = new Dictionary<Worlds, LayerMask>();
        worldLayer.Add(Worlds.NormalWorld, NormalLayer);
        worldLayer.Add(Worlds.DarkWorld, DarkLayer);
    }

	void Update()
	{
        if (!HasGlasses)
            animator.runtimeAnimatorController = animControllers[0];
        else
            animator.runtimeAnimatorController = world.CurWorld == Worlds.NormalWorld ? animControllers[1] : animControllers[2];
		if (Input.GetKeyDown(KeyCode.Tab)) {
			world.ChangeWorld();
		}
        if (grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow))) 
		{
			playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, ySpeed);
		}
        animator.SetBool("Moving", playerRigidbody2D.velocity.x != 0);
	}
	
	void GameOver() {
		world.Reset();
	}

	public override void Reset() {
        base.Reset();
        HasGlasses = checkpointHasGlasseValue;
	}

	void FixedUpdate()
	{
        grounded = Physics2D.OverlapArea(new Vector2(groundCheck.position.x - groundRadius, groundCheck.position.y), new Vector2(groundCheck.position.x + groundRadius, groundCheck.position.y - groundRadius), worldLayer[world.CurWorld]);
		float xMove = Input.GetAxis("Horizontal");
		
        playerRigidbody2D.velocity = new Vector2 (xSpeed * xMove,playerRigidbody2D.velocity.y);
		
		if (xMove > 0 && !facingRight)
			Flip ();
		else if (xMove < 0 && facingRight)
			Flip ();
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Abyss") 
		{
			GameOver();
		}
        if (other.tag == "Monster")
        {
            var obj = other.gameObject.GetComponent<Monster>();
            hp -= obj.damage;
            if (hp <= 0)
                GameOver();
        }
	}
}