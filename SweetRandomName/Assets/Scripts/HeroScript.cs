using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HeroScript : WorldObject 
{
    public Canvas canvas;
    private CanvasScript canvasScript;
    public Text text;

    private Dictionary<Worlds, LayerMask> worldLayer;
	public float xSpeed;
	public float ySpeed;
	
	private bool facingRight;
	
	public bool grounded = false;
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
    public float stunTime;
	
    public Vector2 additionalVelocity;
	
	void Start()
	{
        text.text = "kek";
        canvasScript = canvas.GetComponent<CanvasScript>();
        GeneralStart();
        animator = gameObject.GetComponent<Animator>();
        hp = 1;
		world = GameObject.FindObjectsOfType(typeof(World))[0] as World;
		//initPosition = transform.position;
        //initVelocity = new Vector2(0, 0);
		//playerRigidbody2D = GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.Tab) && HasGlasses) {
			world.ChangeWorld();
		}
        animator.SetBool("Moving", objRigidbody2D.velocity.x != additionalVelocity.x && objRigidbody2D.velocity.x != 0);
        animator.SetBool("Jumping", !grounded);

        if (stunTime <= 0 && grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow))) 
        {
            objRigidbody2D.velocity = new Vector2(objRigidbody2D.velocity.x, ySpeed);
        }
	}
	
	void GameOver() {
		world.Reset();
	}

	public override void Reset() {
        base.Reset();
        HasGlasses = checkpointHasGlasseValue;
	}

    public void ShowText(float time)
    {
        canvas.enabled = true;
        canvasScript.ShowText(time);
    }

	void FixedUpdate()
	{
        if (stunTime <= 0)
        {
            grounded = Physics2D.OverlapArea(new Vector2(groundCheck.position.x - groundRadius, groundCheck.position.y), new Vector2(groundCheck.position.x + groundRadius, groundCheck.position.y - groundRadius), worldLayer[world.CurWorld]);
            float xMove = Input.GetAxis("Horizontal");
		
            objRigidbody2D.velocity = new Vector2(xSpeed * xMove, objRigidbody2D.velocity.y);

            if (xMove > 0 && !facingRight)
                Flip();
            else if (xMove < 0 && facingRight)
                Flip();
        }
        else
        {
            stunTime -= Time.fixedDeltaTime;
            objRigidbody2D.velocity = new Vector2(0, objRigidbody2D.velocity.y);
        }
        objRigidbody2D.velocity += additionalVelocity;
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
        if (other.tag == "Abyss" || other.tag == "Spikes" || other.tag == "Shot") 
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