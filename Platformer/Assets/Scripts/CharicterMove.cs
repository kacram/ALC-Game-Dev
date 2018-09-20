using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharicterMove : MonoBehaviour {

    //assign sprites
    private SpriteRenderer spriteRenderer;
    public Sprite standing;
    public Sprite running0;
    public Sprite running1;
    public Sprite running2;
    public Sprite running3;
    public Sprite running4;
    public Sprite running5;
    public Sprite falling;
    public Sprite jumping;
    
	//constants
	public int MoveSpeed;
    public float frict;
	public float JumpHeight;
    public int MaxSpeed;
    public float AirSpeed;
    public float slideSpeed;
    public float wallCheckRadius;
    public float groundCheckRadius;
    public int animSpeed;
    public int cSpriteIndex;

    //initiate grounded variables
    public Transform groundCheck;
    public Transform WallCheckL;
    public Transform WallCheckR;
	public LayerMask whatIsGround;
	public bool grounded;
    public bool isWallL;
    public bool isWallR;
	public float hspd;

    //changing vars
    int tick;
    



	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = standing;
        }
        if (tick == 0)
        {
            tick = animSpeed;
        }
    }
	
	
	void FixedUpdate () {
        //checks to see if there is ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //checks for wall on left
        isWallL = Physics2D.OverlapCircle(WallCheckL.position, wallCheckRadius, whatIsGround);


        //checks for wall on right
        isWallR = Physics2D.OverlapCircle(WallCheckR.position, wallCheckRadius, whatIsGround);


	}
	
	// Update is called once per frame
	void Update () {
		//check for button press
		//jump method
		Jump();
        //move method
        Move();
        //change sprites
        ChangeSprite();
	}
	
	//actually jump
	
	
	public void Jump (){

        //if player is on ground and space is hit player jumps
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
        }

        //if there is no ground
        if (grounded == false)
        {
            //if there is a wall on the left
            if (isWallL)
            {
                //if player is moving left
                if (GetComponent<Rigidbody2D>().velocity.x <= 0)
                {
                    //if hitting a (left)
                    if (Input.GetKey(KeyCode.A))
                    {
                        //slide down the wall slowly
                        if (GetComponent<Rigidbody2D>().velocity.y < -slideSpeed)
                        {
                            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,-slideSpeed);
                        }
                        //wall jump
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            GetComponent<Rigidbody2D>().velocity = new Vector2(0, JumpHeight);
                            hspd = MaxSpeed;
                        }
                    }
                }
            }
            //if there is a wall on the right
            if (isWallR)
            {
                // if you are moving right
                if (GetComponent<Rigidbody2D>().velocity.x >= 0)
                {
                    //if you are hitting d (right)
                    if (Input.GetKey(KeyCode.D))
                    {
                        //slide down wall slowly
                        if (GetComponent<Rigidbody2D>().velocity.y < -slideSpeed)
                        {
                            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -slideSpeed);
                        }
                        //wall jump
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            GetComponent<Rigidbody2D>().velocity = new Vector2(0, JumpHeight);
                            hspd = -MaxSpeed;
                        }
                    }
                }
            }
        }
	}
    



    public void Move ()
	{
        //ground friction
        if (grounded)
        {
            if (hspd != 0)
            {
                if (hspd > frict)
                {
                    hspd -= frict;
                }
                else if (hspd < -frict)
                {
                    hspd += frict;
                }
                else
                {
                    hspd = 0;
                }
            }
        }
        //dont stick to wall on left
        if (isWallL)
        {
            if (hspd < 0)
            {
                hspd = 0;
            }
        }
        //don't stick to wall on right
        if (isWallR)
        {
            if (hspd > 0)
            {
                hspd = 0;
            }
        }
        //if you hit left move left
		if(Input.GetKey(KeyCode.A))
		{
            //if you are on the ground move this fast
            if (grounded)
            {
                hspd -= MoveSpeed;
            }
            //if you are in the air move this fast
            if (grounded == false)
            {
                hspd -= AirSpeed;
            }
		}
	    //if you hit right move right
		if (Input.GetKey(KeyCode.D))
		{
            //if you are on the ground move this fast
            if (grounded)
            {
                hspd += MoveSpeed;
            }
            //if you are in the air move this fast
            if (grounded == false)
            {
                hspd += AirSpeed;
            }
		}



		if (Mathf.Abs(hspd) > MaxSpeed)
        {
            hspd = Mathf.Sign(hspd)*MaxSpeed;
        }


		GetComponent<Rigidbody2D>().velocity = new Vector2(hspd ,GetComponent<Rigidbody2D>().velocity.y);
	}

    public void ChangeSprite()
    {
        if (grounded)
        {
            if (hspd == 0)
            {
                spriteRenderer.sprite = standing;
            }
            if (hspd != 0)
            {
                tick--;
                if (tick <= 0)
                {
                    cSpriteIndex += 1;
                    tick = animSpeed;
                }
                if (cSpriteIndex > 5)
                {
                    cSpriteIndex = 0;
                }

                switch (cSpriteIndex)
                {
                    case 0:
                        spriteRenderer.sprite = running0;
                        break;
                    case 1:
                        spriteRenderer.sprite = running1;
                        break;
                    case 2:
                        spriteRenderer.sprite = running2;
                        break;
                    case 3:
                        spriteRenderer.sprite = running3;
                        break;
                    case 4:
                        spriteRenderer.sprite = running4;
                        break;
                    case 5:
                        spriteRenderer.sprite = running5;
                        break;
                    default:
                        spriteRenderer.sprite = standing;
                        break;
                }
            }
        }

        if (grounded == false)
        {
            if (GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                spriteRenderer.sprite = falling;
            }
            if (GetComponent<Rigidbody2D>().velocity.y >= 0)
            {
                spriteRenderer.sprite = jumping;
            }
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}