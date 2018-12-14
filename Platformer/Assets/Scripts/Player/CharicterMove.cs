using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharicterMove : MonoBehaviour
{

    //assign sprites
    private SpriteRenderer spriteRenderer;
    public Sprite standing;
    public Sprite running0;
    public Sprite running1;
    public Sprite running2;
    public Sprite running3;
    public Sprite running4;
    public Sprite running5;
    public Sprite runngun0;
    public Sprite runngun1;
    public Sprite runngun2;
    public Sprite runngun3;
    public Sprite runngun4;
    public Sprite runngun5;
    public Sprite falling;
    public Sprite jumping;
    public Sprite sprNone;
    public Sprite dying;
    public Sprite respawn1;
    public Sprite respawn2;
    public Sprite respawn3;
    public Sprite respawn4;
    public Sprite respawn5;
    public Sprite respawn6;
    public Sprite StandShoot;
    public Sprite fallshoot;
    public Sprite jumpshoot;
    public Sprite slide;

    //initiate constants
    public int MoveSpeed;
    public float frict;
    public float MFrict;
    public float JumpHeight;
    public int MaxMoveSpeed;
    public float AirSpeed;
    public float slideSpeed;
    public float climbSpeed;
    public float wallCheckRadius;
    public float groundCheckRadius;
    public int animSpeed;
    public int cSpriteIndex;
    public float grav;
    public float respawnTime;
    public float MaxHP;
    public int ShootTime;
    private int ShootTime2;
    public int slideDuration;
    public GameObject DeathPart;
    public GameObject Projectile;
    public Transform FirePoint;

    //keybinds
    public KeyCode buttonSlide;

    //initiate variables
    public Transform groundCheck;
    public Transform WallCheckL;
    public Transform WallCheckR;
    public LayerMask whatIsGround;
    public bool grounded;
    public bool isWallL;
    public bool isWallR;
    private float scale;
    private float rsptm;
    public bool Shooting;
    public float Mhspd;
    public float Ehspd;
    public float KBhspd;
    public float hspd;
    public float SlideSpeedBonus;
    public float HP;
    public float gravcache;
    public bool Dead;
    public bool Dead2;
    private int slideDuration2;
    public Transform CurrentCheckPoint;
    public string state = "normal";
    int tick;




    // Use this for initialization
    void Start()
    {
        CurrentCheckPoint = transform;
        scale = transform.localScale.x;
        Dead2 = false;
        HP = MaxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = standing;
        }
        if (tick == 0)
        {
            tick = animSpeed;
        }
        Dead = false;
    }


    void FixedUpdate()
    {
        //checks to see if there is ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, wallCheckRadius, whatIsGround);

        //checks for wall on left
        isWallL = Physics2D.OverlapArea(new Vector2(transform.localPosition.x - .11f, transform.localPosition.y + .07f), new Vector2(transform.localPosition.x - .1f, transform.localPosition.y - .08f), whatIsGround);


        //checks for wall on right
        isWallR = Physics2D.OverlapArea(new Vector2(transform.localPosition.x + .11f, transform.localPosition.y + .07f), new Vector2(transform.localPosition.x + .1f, transform.localPosition.y - .08f), whatIsGround);


    }

    // Update is called once per frame
    void Update()
    {
        //check for button press

        ShootTime2 -= 1;

        if (ShootTime2 < 0)
        {
            Shooting = false;
        }

        if (HP <= 0)
        {
            Dead = true;
        }

        if (state == "sliding")
        {
            Slide();
        }

        else if (state == "climbing")
        {
            Climb();
        }

        else if (state == "normal")
        {
            if (Dead == false && Dead2 == false)
            {
                //jump method
                Jump();
                //move method
                Move();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //shooting
                    Shoot();
                }
            }
            else if (Dead)
            {
                //die
                Die();
            }
            if (Dead == false)
            {
                //change sprites
                ChangeSprite();
            }
            if (Input.GetKey(buttonSlide))
            {
                Slide();
                state = "sliding";
                slideDuration2 = slideDuration;
            }
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            HP = 0;
        }
        if (HP < 0)
        {
            HP = 0;
        }
    }

    //actually jump


    public void Jump()
    {

        //if player is on ground and space is hit player jumps
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
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
                            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -slideSpeed);
                        }
                        //wall jump
                        if (Input.GetKeyDown(KeyCode.W))
                        {
                            GetComponent<Rigidbody2D>().velocity = new Vector2(0, JumpHeight);
                            Mhspd = MaxMoveSpeed;
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
                        if (Input.GetKeyDown(KeyCode.W))
                        {
                            GetComponent<Rigidbody2D>().velocity = new Vector2(0, JumpHeight);
                            Mhspd = -MaxMoveSpeed;
                        }
                    }
                }
            }
        }
    }




    public void Move()
    {

        //ground friction
        if (grounded)
        {
            if (Mhspd != 0)
            {
                if (Mhspd > frict)
                {
                    Mhspd -= frict;
                }
                else if (Mhspd < -frict)
                {
                    Mhspd += frict;
                }
                else
                {
                    Mhspd = 0;
                }
            }
        }
        //environment friction
        //ground friction
        if (grounded)
        {
            if (KBhspd != 0)
            {
                if (KBhspd > frict*1.5f)
                {
                    KBhspd -= frict*1.5f;
                }
                else if (KBhspd < -frict*1.5f)
                {
                    KBhspd += frict*1.5f;
                }
                else
                {
                    KBhspd = 0;
                }
            }
        }

        //dont stick to wall on left
        if (isWallL)
        {
            if (Mhspd < 0)
            {
                Mhspd = 0;
            }
        }
        //don't stick to wall on right
        if (isWallR)
        {
            if (Mhspd > 0)
            {
                Mhspd = 0;
            }
        }
        //if you hit left move left
        if (Input.GetKey(KeyCode.A))
        {
            //if you are on the ground move this fast
            if (grounded)
            {
                Mhspd -= MoveSpeed;
            }
            //if you are in the air move this fast
            if (grounded == false)
            {
                Mhspd -= AirSpeed;
            }
        }
        //if you hit right move right
        if (Input.GetKey(KeyCode.D))
        {
            //if you are on the ground move this fast
            if (grounded)
            {
                Mhspd += MoveSpeed;
            }
            //if you are in the air move this fast
            if (grounded == false)
            {
                Mhspd += AirSpeed;
            }
        }



        if (Mathf.Abs(Mhspd) > MaxMoveSpeed)
        {
            Mhspd = MaxMoveSpeed * Mathf.Sign(Mhspd);
        }

        hspd = Mhspd + Ehspd + KBhspd;

        GetComponent<Rigidbody2D>().velocity = new Vector2(hspd, GetComponent<Rigidbody2D>().velocity.y);
        if (grounded)
        {
            Ehspd = 0;
        }
    }

    public void ChangeSprite()
    {
        if (grounded)
        {
            if (Mhspd == 0)
            {
                if (Shooting == false)
                {
                    spriteRenderer.sprite = standing;
                }
                else
                {
                    spriteRenderer.sprite = StandShoot;
                }
            }
            if (Mhspd != 0)
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
                if (Shooting == false)
                {
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
                else
                {
                    switch (cSpriteIndex)
                    {
                        case 0:
                            spriteRenderer.sprite = runngun0;
                            break;
                        case 1:
                            spriteRenderer.sprite = runngun1;
                            break;
                        case 2:
                            spriteRenderer.sprite = runngun2;
                            break;
                        case 3:
                            spriteRenderer.sprite = runngun3;
                            break;
                        case 4:
                            spriteRenderer.sprite = runngun4;
                            break;
                        case 5:
                            spriteRenderer.sprite = runngun5;
                            break;
                        default:
                            spriteRenderer.sprite = standing;
                            break;
                    }
                }
            }
        }



        if (grounded == false)
        {
            if (GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                if (Shooting == false)
                {
                    spriteRenderer.sprite = falling;
                }
                else
                {
                    spriteRenderer.sprite = fallshoot;
                }
            }
            if (GetComponent<Rigidbody2D>().velocity.y >= 0)
            {
                if (Shooting == false)
                {
                    spriteRenderer.sprite = jumping;
                }
                else
                {
                    spriteRenderer.sprite = jumpshoot;
                }
            }
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) == false)
        {
            transform.localScale = new Vector3(-scale, scale, 1);
        }
        else if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(scale, scale, 1);
        }

        if (Dead2 && Dead == false)
        {
            if (grounded == false)
            {

                spriteRenderer.sprite = respawn1;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -12f);
            }
            else
            {
                tick--;
                if (tick <= 0)
                {
                    cSpriteIndex += 1;
                    tick = animSpeed / 2;
                }



                switch (cSpriteIndex)
                {
                    case 0:
                        spriteRenderer.sprite = respawn2;
                        break;
                    case 1:
                        spriteRenderer.sprite = respawn3;
                        break;
                    case 2:
                        spriteRenderer.sprite = respawn4;
                        break;
                    case 3:
                        spriteRenderer.sprite = respawn5;
                        break;
                    case 4:
                        spriteRenderer.sprite = respawn6;
                        break;
                    default:
                        spriteRenderer.sprite = standing;
                        Dead2 = false;
                        GetComponent<Rigidbody2D>().gravityScale = grav;
                        break;
                }
            }
        }

    }

    public void Shoot()
    {
        Instantiate(Projectile, FirePoint.transform.position, FirePoint.transform.rotation);
        ShootTime2 = ShootTime;
        Shooting = true;
    }

    public void Die()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        cSpriteIndex = 0;
        spriteRenderer.sprite = dying;

        Mhspd = 0;
        if (Dead2 == false)
        {
            rsptm = respawnTime;
        }

        Dead2 = true;


        rsptm -= 1;

        if (rsptm <= 0 && Dead2)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector2(CurrentCheckPoint.transform.position.x, CurrentCheckPoint.transform.position.y + 10);
            spriteRenderer.sprite = sprNone;
            HP = MaxHP;
            Dead = false;
        }
    }

    public void Slide()
    {
        state = "sliding";
        if (Input.GetKey(KeyCode.Space))
        {
            state = "normal";
            return;
        }
        slideDuration2--;
        if (slideDuration2 <= 0)
        {
            state = "normal";
            return;
        }

        if (isWallL || isWallR)
        {
            state = "normal";
            return;
        }

        spriteRenderer.sprite = slide;
        Mhspd = Mathf.Sign(transform.localScale.x) * MaxMoveSpeed + SlideSpeedBonus * Mathf.Sign(transform.localScale.x);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "ladder")
        {
            if (state == "normal")
            {
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
                {
                    state = "climbing";
                    gravcache = GetComponent<Rigidbody2D>().gravityScale;
                    GetComponent<Rigidbody2D>().gravityScale = 0;
                }
            }
        }
    }
    public void Climb()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().position = new Vector2(GetComponent<Rigidbody2D>().position.x,GetComponent<Rigidbody2D>().position.y + climbSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().position = new Vector2(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y - climbSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            state = "normal";
            GetComponent<Rigidbody2D>().gravityScale = gravcache;
        }
    }
}